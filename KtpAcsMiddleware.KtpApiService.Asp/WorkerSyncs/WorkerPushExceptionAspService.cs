using System;
using System.Collections.Generic;
using System.Linq;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.Dto;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.KtpApiService.Asp.Base;
using KtpAcsMiddleware.KtpApiService.Asp.WorkerSyncs.Api;

namespace KtpAcsMiddleware.KtpApiService.Asp.WorkerSyncs
{
    /// <summary>
    ///     推送异常的工人(重新推送)处理
    /// </summary>
    public class WorkerPushExceptionAspService
    {
        /// <summary>
        ///     推送所有(异常)工人
        /// </summary>
        public void RePushExceptionWorkers()
        {
            //同步所有工人照片到七牛
            var workerSyncAspService = new WorkerSyncAspService();
            workerSyncAspService.UpWorkerNewPicsToQiniu();

            var newExceptionWorkers = GetExceptionWorkers();
            if (newExceptionWorkers == null)
            {
                return;
            }
            //遍历-逐个覆盖推送
            var workerSyncAspDesignatedService = new WorkerSyncAspDesignatedService();
            var erros = string.Empty;
            foreach (var newWorker in newExceptionWorkers)
            {
                try
                {
                    workerSyncAspDesignatedService.PushWorker(newWorker.Id, true);
                }
                catch (Exception ex)
                {
                    erros = $"{erros}Message={ex.Message},StackTrace={ex.StackTrace},id={newWorker.Id}|";
                }
            }
            if (erros != string.Empty)
            {
                erros = erros.TrimEnd('|');
                throw new Exception(erros);
            }
        }

        /// <summary>
        ///     推送所有删除(异常)工人
        /// </summary>
        public void RePushDelExceptionWorkers()
        {
            var newDelExceptionWorkers = GetDelExceptionWorkers();
            if (newDelExceptionWorkers == null)
            {
                return;
            }
            //遍历-逐个覆盖推送
            var ktpWorkerUpService = new KtpWorkerUpService();
            var erros = string.Empty;
            foreach (var newDelWorker in newDelExceptionWorkers)
            {
                try
                {
                    ktpWorkerUpService.PushDeleteWorker(newDelWorker.Id,
                        newDelWorker.Sync.TeamThirdPartyId, newDelWorker.Sync.ThirdPartyId, true);
                }
                catch (Exception ex)
                {
                    erros = $"{erros}Message={ex.Message},StackTrace={ex.StackTrace},id={newDelWorker.Id}|";
                }
            }
            if (erros != string.Empty)
            {
                erros = erros.TrimEnd('|');
                throw new Exception(erros);
            }
        }

        /// <summary>
        ///     获取需要同步的工人(异常)数据
        /// </summary>
        private IList<WorkerDto> GetExceptionWorkers()
        {
            var searchCriteria = new SearchCriteria<Worker>();
            //同步到开太平的数据必须时已经认证的工人
            searchCriteria.AddFilterCriteria(
                t => t.WorkerSync != null && t.WorkerSync.Status == (int) KtpSyncState.Fail
                     && (t.WorkerSync.Type == (int) KtpSyncType.PushEdit ||
                         t.WorkerSync.Type == (int) KtpSyncType.PushAdd)
                     && t.WorkerIdentity != null
                     && t.FacePicId != null && t.FacePicId != string.Empty
                     && t.WorkerIdentity.PicId != null && t.WorkerIdentity.PicId != string.Empty
                     && t.WorkerIdentity.BackPicId != null && t.WorkerIdentity.BackPicId != string.Empty);
            searchCriteria.AddFilterCriteria(t => t.Team != null && t.Team.TeamSync != null);
            var workers = DataFactory.WorkerQueryRepository.Find(searchCriteria);
            if (workers.Count == 0)
                return null;
            return workers;
        }

        /// <summary>
        ///     获取需要同步删除的工人(异常)数据
        /// </summary>
        private IList<WorkerDto> GetDelExceptionWorkers()
        {
            var searchCriteria = new SearchCriteria<Worker>();
            searchCriteria.AddFilterCriteria(
                t => t.WorkerSync != null && t.WorkerSync.Status == (int) KtpSyncState.Fail
                     && t.WorkerSync.Type == (int) KtpSyncType.PushDelete);
            var workers = DataFactory.WorkerQueryRepository.Find(searchCriteria, true).ToList();
            if (workers.Count == 0)
                return null;
            return workers;
        }
    }
}