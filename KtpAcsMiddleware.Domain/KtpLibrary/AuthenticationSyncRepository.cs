using System;
using System.Collections.Generic;
using System.Linq;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.Dto;
using KtpAcsMiddleware.Domain.WorkerAuths;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Search.Extensions;
using KtpAcsMiddleware.Infrastructure.Search.Paging;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.Domain.KtpLibrary
{
    internal class AuthenticationSyncRepository : AbstractRepository, IAuthenticationSyncRepository
    {
        public ZmskAuthenticationSync FirstOrDefault(string id)
        {
            return DataContext.ZmskAuthenticationSyncs.FirstOrDefault(t => t.Id == id);
        }

        public PagedResult<ZmskAuthentication> FindPaged(SearchCriteria<ZmskAuthentication> searchCriteria)
        {
            var count = DataContext.ZmskAuthentications.FilterBy(searchCriteria.FilterCriterias).Count();
            var entities = DataContext.ZmskAuthentications.SearchBy(searchCriteria);
            return new PagedResult<ZmskAuthentication>(count, entities);
        }

        public IList<Worker> FindAuthWorkers(IList<ZmskAuthentication> auths)
        {
            if (auths == null || auths.Count == 0)
            {
                return null;
            }
            IList<Worker> authWorkers = new List<Worker>();
            using (var dataContext = DataContext)
            {
                foreach (var auth in auths)
                {
             
                    if (string.IsNullOrEmpty(auth.Name))
                    {
                        continue;
                    }
                    if (string.IsNullOrEmpty(auth.IdNumber))
                    {
                        continue;
                    }
                    if (string.IsNullOrEmpty(auth.AuthTimeStamp))
                    {
                        continue;
                    }
                    var authTime = FormatHelper.GetDateTimeFromStampIgnoreEx(auth.AuthTimeStamp);
                    if (authTime != null)
                    {
                        //var authWorkera = dataContext.Workers.Where(t => t.Name == auth.Name).ToList();
                        //authWorkera = authWorkera.Where(t => t.WorkerIdentity.Code == auth.IdNumber).ToList();
                        //authWorkera = authWorkera.Where(t => t.InTime <= authTime).ToList();
                        //authWorkera = authWorkera.Where(t => t.OutTime == null || authTime <= t.OutTime).ToList();
                        //authWorkers.Add(authWorkera[0]);
                        //--------------------------------------------
                        var authWorker = dataContext.Workers.FirstOrDefault(
                            t => t.Name == auth.Name && t.WorkerIdentity.Code == auth.IdNumber
                                 && t.InTime <= authTime && (t.OutTime == null || authTime <= t.OutTime));
                        if (authWorker != null)
                        {
                            authWorkers.Add(authWorker);
                        }
                    }
                }
                return authWorkers;
            }
        }

        public WorkerAuthCollectionDto FindNew(string authId)
        {
            using (var dataContext = DataContext)
            {
                var authentication = from t in dataContext.ZmskAuthentications
                    join tworker in dataContext.Workers on t.IdNumber equals tworker.WorkerIdentity.Code
                    join tfacedevice in dataContext.FaceDevices on t.DeviceNumber equals tfacedevice.Code
                    where (t.Id == authId)
                          && tfacedevice.IsCheckIn != null
                          && tworker.WorkerSync != null && tworker.WorkerSync.ThirdPartyId > 0
                    select new WorkerAuthCollectionDto
                    {
                        AuthId = t.Id,
                        WorkerId = tworker.Id,
                        TeamId = tworker.TeamId,
                        TeamName = tworker.Team.Name,
                        ClockType = tfacedevice.IsCheckIn == true
                            ? (int) WorkerAuthClockType.JinZhaji
                            : (int) WorkerAuthClockType.ChuZhaji,
                        ClockTime = FormatHelper.GetDateTimeFromStamp(t.AuthTimeStamp),
                        ClockPic = t.Avatar,
                        SimilarDegree = FormatHelper.GetDecimal(t.SimilarDegree),
                        IsPass = t.Result == 1, //认证结果 0：未通过 1：通过
                        ClientCode = t.DeviceNumber,
                        ThirdPartyWorkerId = tworker.WorkerSync.ThirdPartyId
                    };
                return authentication.FirstOrDefault();
            }
        }

        public IList<WorkerAuthCollectionDto> FindTopOneThousandNews(out int selectCount)
        {
            using (var dataContext = DataContext)
            {
                var authentications = (from t in dataContext.ZmskAuthentications
                    join tworker in dataContext.Workers on t.IdNumber equals tworker.WorkerIdentity.Code
                    join tfacedevice in dataContext.FaceDevices on t.DeviceNumber equals tfacedevice.Code
                    where (t.ZmskAuthenticationSync == null ||
                           t.ZmskAuthenticationSync.Status == (int) KtpSyncState.NewAdd ||
                           t.ZmskAuthenticationSync.Status == (int) KtpSyncState.Fail)
                          && tfacedevice.IsCheckIn != null
                          && tworker.IsDelete == false && tworker.WorkerSync != null &&
                          tworker.WorkerSync.ThirdPartyId > 0
                    orderby t.CreateTime
                    select new WorkerAuthCollectionDto
                    {
                        AuthId = t.Id,
                        WorkerId = tworker.Id,
                        TeamId = tworker.TeamId,
                        TeamName = tworker.Team.Name,
                        ClockType = tfacedevice.IsCheckIn == true
                            ? (int) WorkerAuthClockType.JinZhaji
                            : (int) WorkerAuthClockType.ChuZhaji,
                        ClockTime = FormatHelper.GetDateTimeFromStamp(t.AuthTimeStamp),
                        ClockPic = t.Avatar,
                        SimilarDegree = FormatHelper.GetDecimal(t.SimilarDegree),
                        IsPass = t.Result == 1, //认证结果 0：未通过 1：通过
                        ClientCode = t.DeviceNumber,
                        ThirdPartyWorkerId = tworker.WorkerSync.ThirdPartyId,
                        WorkerIsDelete = tworker.IsDelete
                    }).Take(1000).ToList();
                //过滤重复
                var result = new List<WorkerAuthCollectionDto>();
                foreach (var authentication in authentications)
                {
                    var resultAuth = result.FirstOrDefault(i => i.AuthId == authentication.AuthId);
                    if (resultAuth != null)
                    {
                        if (resultAuth.WorkerIsDelete) //查询语句添加删除筛选后，此处判断仅作保留，几乎不起实际作用
                        {
                            result.Remove(resultAuth);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    result.Add(authentication);
                }
                selectCount = authentications.Count;
                return result;
            }
        }

        public void Save(ZmskAuthenticationSync dto)
        {
            using (var dataContext = DataContext)
            {
                var sync = dataContext.ZmskAuthenticationSyncs.FirstOrDefault(t => t.Id == dto.Id);
                if (sync == null)
                {
                    dataContext.ZmskAuthenticationSyncs.InsertOnSubmit(dto);
                }
                else
                {
                    sync.Status = dto.Status;
                    sync.FeedbackCode = dto.FeedbackCode;
                    sync.Feedback = dto.Feedback;
                    sync.ModifiedTime = DateTime.Now;
                }
                dataContext.SubmitChanges();
            }
        }

        public void ModifyState(string id, KtpSyncState state)
        {
            using (var dataContext = DataContext)
            {
                var teamSync = dataContext.ZmskAuthenticationSyncs.First(t => t.Id == id);
                teamSync.Status = (int) state;
                teamSync.ModifiedTime = DateTime.Now;
                dataContext.SubmitChanges();
            }
        }
    }
}