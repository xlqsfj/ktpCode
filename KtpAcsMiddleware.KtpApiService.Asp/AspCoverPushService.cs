using System;
using System.Linq;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Asp.Base;
using KtpAcsMiddleware.KtpApiService.Asp.TeamSyncs.Api;
using KtpAcsMiddleware.KtpApiService.Asp.WorkerSyncs;

namespace KtpAcsMiddleware.KtpApiService.Asp
{
    /// <summary>
    ///     覆盖推送
    /// </summary>
    public class AspCoverPushService
    {
        private readonly KtpTeamUpService _ktpTeamUpService;

        public AspCoverPushService()
        {
            _ktpTeamUpService = new KtpTeamUpService();
        }

        /// <summary>
        ///     入口：班组工人数据覆盖推送到开太平
        /// </summary>
        public void CoverPushTeamWorkers()
        {
            var hasException = false;
            try
            {
                CoverPushTeams();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                hasException = true;
            }
            try
            {
                CoverPushWorkers();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                hasException = true;
            }
            if (hasException)
            {
                throw new Exception("hasException = true");
            }
        }

        /// <summary>
        ///     推送所有班组
        /// </summary>
        private void CoverPushTeams()
        {
            //获取新添加状态的班组
            var searchCriteria = new SearchCriteria<Team>();
            searchCriteria.AddFilterCriteria(t => t.IsDelete == false);
            var newTeams = DataFactory.TeamRepository.Find(searchCriteria).ToList();
            if (newTeams.Count == 0)
            {
                return;
            }
            LogHelper.Info($"CoverPushTeams newTeams.Count={newTeams.Count}");
            //遍历并执行推送
            var erros = string.Empty;
            foreach (var newTeam in newTeams)
            {
                try
                {
                    _ktpTeamUpService.PushNewTeam(newTeam.Name, newTeam.TeamWorkType.Value, newTeam.Id);
                }
                catch (Exception ex)
                {
                    erros = $"{erros}Message={ex.Message},StackTrace={ex.StackTrace},id={newTeam.Id}|";
                }
            }
            if (erros != string.Empty)
            {
                erros = erros.TrimEnd('|');
                throw new Exception(erros);
            }
        }

        /// <summary>
        ///     推送所有工人
        /// </summary>
        private void CoverPushWorkers()
        {
            //同步所有工人照片到七牛
            var workerSyncAspService = new WorkerSyncAspService();
            workerSyncAspService.UpWorkerNewPicsToQiniu();
            LogHelper.Info(@"同步工人照片到七牛完成......");

            var newWorkers = DataFactory.WorkerSyncRepository.FindCoverPushNews();
            if (newWorkers == null)
            {
                return;
            }
            LogHelper.Info($"CoverPushWorkers count={newWorkers.Count}");
            //遍历-逐个覆盖推送
            var workerSyncAspDesignatedService = new WorkerSyncAspDesignatedService();
            var erros = string.Empty;
            foreach (var newWorker in newWorkers)
            {
                try
                {
                    workerSyncAspDesignatedService.PushWorker(newWorker.Id);
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
    }
}