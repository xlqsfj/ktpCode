using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.Dto;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Search.Extensions;
using KtpAcsMiddleware.Infrastructure.Search.Paging;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.Domain.WorkerAuths
{
    internal class WorkerAuthRepository : AbstractRepository, IWorkerAuthRepository
    {
        public IList<WorkerAuthCollectionDto> FindTopOneThousandNews()
        {
            var result = new List<WorkerAuthCollectionDto>();
            var cmdText =
                "select top 1000 tworker.Id as WorkerId,tworker.TeamId as TeamId " +
                ",tteam.[Name] as TeamName,tfacedevice.IsCheckIn as IsCheckIn,t.* " +
                "from [ZmskAuthentication] t " +
                "left join [WorkerIdentity] tworkerIdentity on tworkerIdentity.Code=t.IdNumber " +
                "left join [Worker] tworker on tworker.IdentityId= tworkerIdentity.Id " +
                "left join [Team] tteam on tteam.Id=tworker.TeamId " +
                "left join [FaceDevice] tfacedevice on tfacedevice.Code=t.DeviceNumber " +
                "where tworker.IsDelete=0 and tfacedevice.IsCheckIn is not null and tfacedevice.IsDelete=0 " +
                "and t.Id not in(select [AuthId] from [WorkerAuth]) order by t.CreateTime";
            using (var conn = new SqlConnection(ConfigHelper.Conn))
            {
                var reader = SqlHelper.ExecuteReader(conn, cmdText, CommandType.Text, null);
                while (reader.Read())
                {
                    result.Add(WorkerAuthCollectionDataMap.Mapping(reader));
                }
                if (result.Count == 0)
                {
                    return null;
                }
                return result;
            }
        }

        public string Add(WorkerAuth dto)
        {
            if (string.IsNullOrEmpty(dto.Id))
            {
                dto.Id = ConfigHelper.NewGuid;
            }
            dto.CreateTime = DateTime.Now;
            using (var dataContext = DataContext)
            {
                dataContext.WorkerAuths.InsertOnSubmit(dto);
                dataContext.SubmitChanges();
                return dto.Id;
            }
        }

        public void ClearAuthClockPics()
        {
            var authIds = new List<string>();
            var cmdText =
                "select top 1000 t.Id from ZmskAuthentication t " +
                "left join ZmskAuthenticationSync tsync on tsync.Id=t.Id " +
                "left join WorkerAuth tworkerAuth on tworkerAuth.AuthId=t.Id " +
                "where tsync.[Status]=0 and tworkerAuth.ClockPicId is not null and t.Avatar!=tworkerAuth.ClockPicId  order by t.CreateTime";
            using (var conn = new SqlConnection(ConfigHelper.Conn))
            {
                var reader = SqlHelper.ExecuteReader(conn, cmdText, CommandType.Text, null);
                while (reader.Read())
                {
                    authIds.Add(reader["Id"].ToString());
                }
            }
            if (authIds.Count == 0)
            {
                return;
            }
            using (var dataContext = DataContext)
            {
                foreach (var authId in authIds)
                {
                    var workerAuth =
                        dataContext.WorkerAuths.FirstOrDefault(t => t.AuthId != null && t.AuthId == authId);
                    if (workerAuth == null)
                    {
                        continue;
                    }
                    dataContext.ZmskAuthentications.First(t => t.Id == authId).Avatar = workerAuth.ClockPicId;
                }
                dataContext.SubmitChanges();
            }
            //清理数据为1000，代表还有需要清理的数据，通过递归的方式每次清理一千条数据
            if (authIds.Count == 1000)
            {
                ClearAuthClockPics();
            }
        }

        public PagedResult<WorkerAuth> FindPaged(SearchCriteria<WorkerAuth> searchCriteria)
        {
            searchCriteria.AddFilterCriteria(t => t.IsPass);
            var count = DataContext.WorkerAuths.FilterBy(searchCriteria.FilterCriterias).Count();
            var entities = DataContext.WorkerAuths.SearchBy(searchCriteria);
            return new PagedResult<WorkerAuth>(count, entities);
        }

        public IList<WorkerAuth> FindCycle(string workerId, DateTime beginTime, DateTime endTime)
        {
            if (beginTime.Date == endTime.Date)
            {
                //起始日期相同时，获取的数据应为所选日期的出现的打卡记录
                endTime = beginTime.Date.AddDays(1);
            }
            var result = DataContext.WorkerAuths.Where(
                t => t.WorkerId == workerId
                     && t.ClockTime >= beginTime && t.ClockTime < endTime).ToList();
            return result.Where(i => i.IsPass).ToList();
        }

        public WorkerAuth FindDatePreviousOne(string workerId, DateTime date)
        {
            return DataContext.WorkerAuths.OrderByDescending(t => t.ClockTime)
                .FirstOrDefault(t => t.WorkerId == workerId && t.IsPass && t.ClockTime < date.Date);
        }

        public WorkerAuth FindDateLatterOne(string workerId, DateTime date)
        {
            return DataContext.WorkerAuths.OrderBy(t => t.ClockTime)
                .FirstOrDefault(t => t.WorkerId == workerId && t.IsPass && t.ClockTime >= date.Date.AddDays(1));
        }

        public WorkerAuth FindLast(string workerId)
        {
            return DataContext.WorkerAuths.OrderByDescending(t => t.ClockTime)
                .FirstOrDefault(t => t.WorkerId == workerId);
        }

        public IList<string> FindNewClearAuthIds()
        {
            var notCollectionAuthIds = FindNotCollectionAuthId();
            using (var dataContext = DataContext)
            {
                IQueryable<ZmskAuthentication> auths = dataContext.ZmskAuthentications;
                if (notCollectionAuthIds != null && notCollectionAuthIds.Count > 0)
                {
                    auths = auths.Where(t => !notCollectionAuthIds.ToArray().Contains(t.Id));
                }
                return (from t in auths
                    join tworker in dataContext.Workers on t.IdNumber equals tworker.WorkerIdentity.Code
                    join tfacedevice in dataContext.FaceDevices on t.DeviceNumber equals tfacedevice.Code
                    where t.ZmskAuthenticationSync != null
                          && t.ZmskAuthenticationSync.Status == (int) KtpSyncState.Success
                    select t.Id).ToList();
            }
        }

        /// <summary>
        ///     获取未采集的原始考勤数据ID
        /// </summary>
        /// <returns></returns>
        private IList<string> FindNotCollectionAuthId()
        {
            var result = new List<string>();
            var cmdText = "select [Id] from [ZmskAuthentication] where [Id] not in (select [AuthId] from [WorkerAuth])";
            using (var conn = new SqlConnection(ConfigHelper.Conn))
            {
                var reader = SqlHelper.ExecuteReader(conn, cmdText, CommandType.Text, null);
                while (reader.Read())
                {
                    result.Add(reader["Id"].ToString());
                }
                return result;
            }
        }
    }
}