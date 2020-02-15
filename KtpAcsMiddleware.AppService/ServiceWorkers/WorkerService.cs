using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.AppService.ServiceModel;
using KtpAcsMiddleware.Domain.Base;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.FaceRecognition;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Domain.Workers;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Search.Paging;
using KtpAcsMiddleware.Infrastructure.Search.Sort;
using KtpAcsMiddleware.Infrastructure.Serialization;

namespace KtpAcsMiddleware.AppService.ServiceWorkers
{
    class WorkerService : IWorkerService
    {
        private readonly IFileMapRepository _fileRepository;
        private readonly IWorkerQueryRepository _workerRepository;
        private readonly IFaceDeviceWorkerRepository _repository;

        public WorkerService(
            IWorkerQueryRepository workerRepository,
            IFileMapRepository fileRepository, IFaceDeviceWorkerRepository repository)
        {
            _workerRepository = workerRepository;
            _fileRepository = fileRepository;
            _repository = repository;
        }

        public TeamWorkerDto Get(string workerId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 设备下人员分页查询工人列表
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">一页显示几页</param>
        /// <param name="teamId">班组id</param>
        /// <param name="keywords">模糊查询</param>
        /// <param name="state">认证状态</param>
        /// <returns></returns>
        public PagedResult<WorkerDto> GetPaged(int pageIndex, int pageSize, string teamId, string keywords, WorkerAuthenticationState state, string dName)
        {
            var searchCriteria = new SearchCriteria<FaceDeviceWorker>();

            searchCriteria.AddFilterCriteria(t => t.Worker.IsDelete == false);
            //班组不为空时
            if (!string.IsNullOrEmpty(teamId))
            {
                searchCriteria.AddFilterCriteria(t => t.Worker.TeamId == teamId);
            }
            else
            {
                searchCriteria.AddFilterCriteria(t => t.Worker.Team != null && t.Worker.Team.IsDelete == false);
            }
            //设备号
            if (!string.IsNullOrEmpty(dName))
            {
                searchCriteria.AddFilterCriteria(t => t.FaceDevice.Code == dName);
            }

            //模糊查询
            if (!string.IsNullOrEmpty(keywords))
            {
                var keywordNationValue = IdentityNationService.GetValue(keywords);
                searchCriteria.AddFilterCriteria(
                    t => t.Worker.Name.Contains(keywords) ||
                         t.Worker.WorkerIdentity.Code.Contains(keywords) ||
                         t.Worker.AddressNow.Contains(keywords) ||
                         t.Worker.WorkerIdentity.Address.Contains(keywords) ||
                         (keywordNationValue != null && t.Worker.WorkerIdentity.Nation == keywordNationValue));
            }

            searchCriteria.AddSortCriteria(
                new ExpressionSortCriteria<FaceDeviceWorker, DateTime>(s => s.Worker.CreateTime,
                    SortDirection.Descending));
            searchCriteria.AddSortCriteria(
                new ExpressionSortCriteria<FaceDeviceWorker, string>(s => s.Worker.Name,
                    SortDirection.Ascending));
            searchCriteria.PagingCriteria = new PagingCriteria(pageIndex, pageSize);
            var pagedResult = _repository.FindPaged(searchCriteria);



            var list = pagedResult.Entities.Select(i => new WorkerDto
            {
                Id = i.WorkerId,
                dId = i.Id,
                WorkerName = i.Worker.Name,
                IdentityCode = i.Worker.WorkerIdentity.Code,
                Sex = ((WorkerSex)i.Worker.WorkerIdentity.Sex).ToEnumText(),
                Nation = ((IdentityNation)i.Worker.WorkerIdentity.Nation).ToEnumText(),
                Mobile = i.Worker.Mobile,
                AddressNow = i.Worker.AddressNow,
                FacePicId = i.Worker.FacePicId,
                IdentityPicId = i.Worker.WorkerIdentity.PicId,
                IdentityBackPicId = i.Worker.WorkerIdentity.BackPicId,
                TeamId = i.Worker.TeamId,
                TeamName = i.Worker.Team.Name,
                ktpState = i.Worker.WorkerSync == null ? ((KtpSyncState)KtpSyncState.NewAdd).ToEnumText() :
               ((KtpSyncState)i.Worker.WorkerSync.Status).ToEnumText(),
                panelState = ((FaceWorkerState)i.Status).ToEnumText(),
                panelStateCode = i.Status,
                panelMag = i.ErrorCode

            }).ToList();

            return new PagedResult<WorkerDto>(
          pagedResult.Count, list);
        }
        /// <summary>
        /// 查询条件添加
        /// </summary>
        /// <param name="teamId">班组id</param>
        /// <param name="keywords">模糊查询</param>
        /// <param name="state">工人认证状态</param>
        /// <returns></returns>
        private SearchCriteria<Worker> GetTeamWorkerGridSearchCriteria(
      string teamId, string keywords, WorkerAuthenticationState state)
        {
            var searchCriteria = new SearchCriteria<Worker>();
            //班组不为空时
            if (!string.IsNullOrEmpty(teamId))
            {
                searchCriteria.AddFilterCriteria(t => t.TeamId == teamId);
            }
            else
            {
                searchCriteria.AddFilterCriteria(t => t.Team != null && t.Team.IsDelete == false);
            }
            //模糊查询
            if (!string.IsNullOrEmpty(keywords))
            {
                var keywordNationValue = IdentityNationService.GetValue(keywords);

                //姓名，身份证，手机号，地址，民族，模糊查询
                searchCriteria.AddFilterCriteria(
                    t => t.Name.Contains(keywords) ||
                         t.WorkerIdentity.Code.Contains(keywords) ||
                         t.Mobile.Contains(keywords) ||
                         t.AddressNow.Contains(keywords) ||
                         (keywordNationValue != null && t.WorkerIdentity.Nation == keywordNationValue));
            }

            //认证状态
            if (state == WorkerAuthenticationState.Already)
            {
                searchCriteria.AddFilterCriteria(
                    t => t.FacePicId != null && t.FacePicId != string.Empty
                         && t.WorkerIdentity.PicId != null && t.WorkerIdentity.PicId != string.Empty
                         && t.WorkerIdentity.BackPicId != null && t.WorkerIdentity.BackPicId != string.Empty);
            }
            //待认证
            if (state == WorkerAuthenticationState.WaitFor)
            {
                searchCriteria.AddFilterCriteria(
                    t => t.FacePicId == null || t.FacePicId == string.Empty
                         || t.WorkerIdentity.PicId == null || t.WorkerIdentity.PicId == string.Empty
                         || t.WorkerIdentity.BackPicId == null ||
                         t.WorkerIdentity.BackPicId != string.Empty);
            }
            //已删除
            if (state == WorkerAuthenticationState.Delete)
            {
                searchCriteria.AddFilterCriteria(t => t.IsDelete);
            }
            //名字排序顺序
            searchCriteria.AddSortCriteria(
                new ExpressionSortCriteria<Worker, string>(s => s.Name, SortDirection.Ascending));
            //添加时间倒序排序
            searchCriteria.AddSortCriteria(
                new ExpressionSortCriteria<Worker, DateTime>(s => s.CreateTime, SortDirection.Descending));
            return searchCriteria;
        }
        /// <summary>
        /// 查询显示前台字段
        /// </summary>
        /// <param name="teamWorkers">查询sql</param>
        /// <returns>前台字段</returns>
        private List<WorkerDto> GetMaptoTeamWorkerGridDtos(IEnumerable<Worker> teamWorkers)
        {
            if (teamWorkers == null)
            {
                return new List<WorkerDto>();
            }
            return teamWorkers.Select(i => new WorkerDto
            {
                Id = i.Id,
                WorkerName = i.WorkerIdentity.Name,
                IdentityCode = i.WorkerIdentity.Code,
                Sex = ((WorkerSex)i.WorkerIdentity.Sex).ToEnumText(),
                Nation = ((IdentityNation)i.WorkerIdentity.Nation).ToEnumText(),
                Mobile = i.Mobile,
                AddressNow = i.AddressNow,
                FacePicId = i.FacePicId,
                IdentityPicId = i.WorkerIdentity.PicId,
                IdentityBackPicId = i.WorkerIdentity.BackPicId,
                TeamId = i.TeamId,
                TeamName = i.Team.Name,
                ktpState = i.WorkerSync == null ? ((KtpSyncState)KtpSyncState.NewAdd).ToEnumText() :
                ((KtpSyncState)i.WorkerSync.Status).ToEnumText(),

            }).ToList();
        }

        public PagedResult<WorkerDto> GetPaged(int pageIndex, int pageSize, string teamId, string keywords, WorkerAuthenticationState state)
        {
            var searchCriteria = GetTeamWorkerGridSearchCriteria(teamId, keywords, state);
            searchCriteria.PagingCriteria = new PagingCriteria(pageIndex, pageSize);
            var pagedResult = _workerRepository.FindPaged(searchCriteria);
            return new PagedResult<WorkerDto>(
                pagedResult.Count, GetMaptoTeamWorkerGridDtos(pagedResult.Entities));

        }
        /// <summary>
        ///查询工人数量
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public int GetWorkerCount(WorkerAuthenticationState state)
        {
            int count = 0;
            if (state == WorkerAuthenticationState.WaitFor)
            {//待认证状态

                count = _workerRepository.FindAll().Where(a => a.FacePicId == null).Count();
            }
            else if (state == WorkerAuthenticationState.Delete)
            {
                //未同步的工人
                count = _workerRepository.FindAll().Where(a => a.Sync == null || a.Sync.Status == (int)KtpSyncState.Fail).Count();
            }
            else
            {

                count = _workerRepository.FindAll().Count();
            }
            return count;
        }
    }
}


