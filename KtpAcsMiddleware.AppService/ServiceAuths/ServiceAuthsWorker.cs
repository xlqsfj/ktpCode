using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KtpAcsMiddleware.AppService.ServiceModel;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.DomainWorkers;
using KtpAcsMiddleware.Domain.FaceRecognition;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Domain.Teams;
using KtpAcsMiddleware.Domain.WorkerAuths;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Search.Paging;
using KtpAcsMiddleware.Infrastructure.Search.Sort;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.AppService.ServiceAuths
{
    public class ServiceAuthsWorker : IServiceAuthsWorker
    {
        private readonly IAuthenticationSyncRepository _repository;
        private readonly IFaceDeviceRepository _faceDeviceRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IDomainWorkersRepository _workersRepository;
        public ServiceAuthsWorker(
        IAuthenticationSyncRepository repository,
        IFaceDeviceRepository faceDeviceRepository, ITeamRepository teamRepository, IDomainWorkersRepository workersRepository)
        {
            _repository = repository;
            _faceDeviceRepository = faceDeviceRepository;
            _teamRepository = teamRepository;
            _workersRepository = workersRepository;       }
        /// <summary>
        /// 查询考勤数据
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">总页数</param>
        /// <param name="keywords">模糊查询</param>
        /// <param name="deviceCode">设备号</param>
        /// <param name="beginDate">查询开始时间</param>
        /// <param name="endDate">查询结束时间</param>
        /// <param name="isBePresent">是否在场</param>
        /// <returns>AuthsDto</returns>
        public PagedResult<AuthsDto> GetPaged(int pageIndex, int pageSize, string keywords, string deviceCode, string beginDate, string endDate, bool isBePresent)
        {
            var searchCriteria = new SearchCriteria<ZmskAuthentication>();
            //设备号不为空时
            if (!string.IsNullOrEmpty(deviceCode))
            {
                searchCriteria.AddFilterCriteria(t => t.DeviceNumber == deviceCode);
            }
            //是否包含数据
            if (!string.IsNullOrEmpty(keywords))
            {
                searchCriteria.AddFilterCriteria(
                    t => t.Name.Contains(keywords) || t.IdNumber.Contains(keywords));
            }
            //查询开始不为空时
            if (!string.IsNullOrEmpty(beginDate))
            {
                searchCriteria.AddFilterCriteria(t => t.CreateTime >= FormatHelper.StringToDateTime(beginDate));
            }
            //查询结束时间不为空
            if (!string.IsNullOrEmpty(endDate))
            {
                searchCriteria.AddFilterCriteria(t => t.CreateTime <= FormatHelper.StringToDateTime(endDate));
            }
            //排序按创建时间排序
            searchCriteria.AddSortCriteria(
           new ExpressionSortCriteria<ZmskAuthentication, DateTime>(s => s.CreateTime, SortDirection.Descending));
            //分页
            searchCriteria.PagingCriteria = new PagingCriteria(pageIndex, pageSize);
            var pagedResult = _repository.FindPaged(searchCriteria);
            //查询设备信息
            var allDevices = _faceDeviceRepository.FindAll();
            var authWorkers = _workersRepository.FindAuthWorkers(pagedResult.Entities.ToList(), isBePresent);
            //查询工人信息
            //var authWorkers = _repository.FindAuthWorkers(pagedResult.Entities.ToList()); 

            //var team = _teamRepository.FindAll();
            if (authWorkers == null)
            {
                List<AuthsDto> authsDto = new List<AuthsDto>();
                return new PagedResult<AuthsDto>(pagedResult.Count, authsDto);
            }

            IList<AuthsDto> authenticationSyncPagedDtos = (from z in pagedResult.Entities
                          // join w in authWorkers on new { w=z.Name,w1=z.IdNumber } equals new { w=w.Name, w1=w.WorkerIdentity.Code }
                      join w in authWorkers on  z.Name equals w.Name
                      join d in allDevices on z.DeviceNumber equals d.Code 
                      select new AuthsDto { Id = z.Id, WorkerName = z.Name, IdentityCode = z.IdNumber, TeamName=w.BankCardCode,
                          State = z.ZmskAuthenticationSync == null ? (int)KtpSyncState.NewAdd : z.ZmskAuthenticationSync.Status,
                          ClockType = d.IsCheckIn == true ? (int)WorkerAuthClockType.JinZhaji : (int)WorkerAuthClockType.ChuZhaji,
                          DeviceCode = z.DeviceNumber,
                          AuthTimeStamp=z.AuthTimeStamp
                           
                      }).ToList();
            //IList <AuthsDto> authenticationSyncPagedDtos = pagedResult.Entities
            //    .Join(allDevices, d => d.DeviceNumber, o => o.Code, (d, o) => new { d, o })
            //.Select(t => new AuthsDto
            //{
            //    Id = t.d.Id,
            //    WorkerName = t.d.Name,
            //    IdentityCode = t.d.IdNumber,
            //    DeviceCode = t.d.DeviceNumber,
            //    ClockType = t.o.IsCheckIn == true ? (int)WorkerAuthClockType.JinZhaji : (int)WorkerAuthClockType.ChuZhaji,
            //    AuthTimeStamp = t.d.AuthTimeStamp,
            //    ClockState = t.d.Result,
            //    //同步开太平的状态
            //    State = t.d.ZmskAuthenticationSync == null ? (int)KtpSyncState.NewAdd : t.d.ZmskAuthenticationSync.Status,
            //    //返回的code，调用开太平接口后的返回值中的code
            //    FeedbackCode = t.d.ZmskAuthenticationSync == null ? null : t.d.ZmskAuthenticationSync.FeedbackCode,
            //    //返回信息，调用开太平接口后的返回值的信息
            //    Feedback = t.d.ZmskAuthenticationSync == null ? string.Empty : t.d.ZmskAuthenticationSync.Feedback ?? string.Empty
            //}).ToList();

            //for (int i = 0; i < authenticationSyncPagedDtos.Count - 1;)
            //{

            //    if (authWorkers == null || authWorkers.Count == 0)
            //    {
            //        continue;
            //    }
            //    var authWorker = authWorkers.Where(a=>a.IsDelete== isBePresent).FirstOrDefault(a=> a.Name == authenticationSyncPagedDtos[i].WorkerName);
            //    if (authWorker == null)
            //    {
            //        authenticationSyncPagedDtos.Remove(authenticationSyncPagedDtos[i]);
            //        i++;
            //        continue;
            //    }
            //    authenticationSyncPagedDtos[i].WorkerId = authWorker.Id;
            //    authenticationSyncPagedDtos[i].TeamName = team.FirstOrDefault(a => a.Id == authWorker.TeamId).Name;
            //}
            return new PagedResult<AuthsDto>(authenticationSyncPagedDtos.Count, authenticationSyncPagedDtos);
        }
    }
}
