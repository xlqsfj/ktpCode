using KtpAcsMiddleware.KtpApiService.Asp.AuthenticationSyncs;
using KtpAcsMiddleware.KtpApiService.Asp.TeamSyncs;
using KtpAcsMiddleware.KtpApiService.Asp.WorkerSyncs;

namespace KtpAcsMiddleware.KtpApiService.Asp
{
    public class AspSyncService
    {
        /// <summary>
        ///     入口：同步所有数据（班组、工人、考勤）
        ///     忽略异常
        /// </summary>
        public void SyncToKtpIgnoreEx()
        {
            var teamSyncService = new TeamSyncAspService();
            var workerSyncService = new WorkerSyncAspService();
            var authSyncService = new AuthSyncAspService();
            //班组同步
            teamSyncService.SyncTeamsIgnoreEx();
            //工人同步
            workerSyncService.SyncWorkersIgnoreEx();
            //考勤同步
            authSyncService.PushAuthenticationsIgnoreEx();
        }

        /// <summary>
        ///     入口：同步所有数据（班组、工人、考勤）
        /// </summary>
        public void SyncToKtp()
        {
            var teamSyncService = new TeamSyncAspService();
            var workerSyncService = new WorkerSyncAspService();
            var authSyncService = new AuthSyncAspService();
            //班组同步
            teamSyncService.SyncTeams();
            //工人同步
            workerSyncService.SyncWorkers();
            //考勤同步
            authSyncService.PushAuthentications();
        }

        /// <summary>
        ///     入口：异常重推(重新推送所有出现异常的数据--班组、工人)
        /// </summary>
        public void RePushExceptions()
        {
            //班组重新推送
            try
            {
                var teamSyncService = new TeamSyncAspService();
                teamSyncService.PushExceptionTeams();
            }
            catch
            {
                // ignored
            }
            //工人(编辑or添加)重新推送
            try
            {
                var workerPushExceptionAspService = new WorkerPushExceptionAspService();
                workerPushExceptionAspService.RePushExceptionWorkers();
            }
            catch
            {
                // ignored
            }
            //工人(删除)重新推送
            try
            {
                var workerPushExceptionAspService = new WorkerPushExceptionAspService();
                workerPushExceptionAspService.RePushDelExceptionWorkers();
            }
            catch
            {
                // ignored
            }
        }
    }
}