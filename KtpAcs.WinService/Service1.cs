using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Asp;
using KtpAcsMiddleware.KtpApiService.Asp.AuthenticationSyncs;
using KtpAcsMiddleware.KtpApiService.Asp.TeamSyncs;
using KtpAcsMiddleware.KtpApiService.Asp.WorkerSyncs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KtpAcs.WinService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }


        System.Timers.Timer timerTeam = new System.Timers.Timer();
        System.Timers.Timer timerWorker = new System.Timers.Timer();
        System.Timers.Timer timerAuth = new System.Timers.Timer();
        System.Timers.Timer timerAbnormal = new System.Timers.Timer();
        protected override void OnStart(string[] args)
        {


            LogHelper.Info($"{DateTime.Now},服务启动！");
            var syncService = new AspSyncService();
            syncService.SyncToKtpIgnoreEx();

            LogHelper.Info($"{DateTime.Now},开始执行定时服务！");
            int sInterval = ConfigHelper.ThreadSleepTime;

            //班组定时同步
            timerTeam.Interval = sInterval;
            timerTeam.Elapsed += timer_TeamSyn;
            timerTeam.Start();

            //工人定时同步
            timerWorker.Interval = sInterval;
            timerWorker.Elapsed += timer_WorkerSyn;
            timerWorker.Start();

            //考勤定时同步
            timerAuth.Interval = ConfigHelper.ThreadSleepTimeAuth;
            timerAuth.Elapsed += timer_AuthSyn;
            timerAuth.Start();

            //异常定时同步
            timerAbnormal.Interval = 1800000;//半个小时同步
            timerAbnormal.Elapsed += RePushExceptions;
            timerAbnormal.Start();
        }
        /// <summary>
        /// 班组同步
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void timer_TeamSyn(object source, System.Timers.ElapsedEventArgs e)
        {
            LogHelper.Info(string.Format("班组同步定时启动服务开始：" + DateTime.Now));
            timerTeam.Stop();
            var teamSyncService = new TeamSyncAspService();
            teamSyncService.SyncTeamsIgnoreEx();
            LogHelper.Info(string.Format("班组同步定时启动服务结束：" + DateTime.Now));
            timerTeam.Start();

        }
        /// <summary>
        /// 工人定时同步
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void timer_WorkerSyn(object source, System.Timers.ElapsedEventArgs e)
        {
            LogHelper.Info(string.Format("工人同步定时启动服务开始：" + DateTime.Now));
            timerWorker.Stop();
            var workerSyncService = new WorkerSyncAspService();
             workerSyncService.SyncWorkersIgnoreEx();
            LogHelper.Info(string.Format("工人同步定时启动服务结束：" + DateTime.Now));
            timerWorker.Start();
           
        }
        /// <summary>
        /// 考勤定时同步
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void timer_AuthSyn(object source, System.Timers.ElapsedEventArgs e)
        {
            LogHelper.Info(string.Format("考勤同步定时启动服务开始：" + DateTime.Now));
            timerAuth.Stop();
            var authSyncService = new AuthSyncAspService();
            //考勤同步
            authSyncService.PushAuthenticationsIgnoreEx();
            LogHelper.Info(string.Format("考勤同步定时启动服务结束：" + DateTime.Now));
            timerAuth.Start();

        }
        /// <summary>
        /// 异常数据重新执行
        /// </summary>
        private void RePushExceptions(object source, System.Timers.ElapsedEventArgs e)
        {
            LogHelper.Info(string.Format("异常数据同步定时启动服务开始：" + DateTime.Now));
            timerAbnormal.Stop();
            try
                {
                    var syncService = new AspSyncService();
                    syncService.RePushExceptions();
                }
                catch (Exception ex)
                {
                    LogHelper.ExceptionLog(ex);
                }
            timerAbnormal.Start();

            LogHelper.Info(string.Format("异常数据同步定时启动服务开始：" + DateTime.Now));
        }

        protected override void OnStop()
        {

            //服务结束执行代码
            //var teamSyncService = new TeamSyncAspService();
            //teamSyncService.SyncTeamsIgnoreEx();
            //var syncService = new AspSyncService();
            //syncService.SyncToKtpIgnoreEx();

            //LogHelper.Info($"{DateTime.Now},开始执行定时服务！");
            //int sInterval = ConfigHelper.ThreadSleepTime;

            //班组定时同步
            //timerTeam.Interval = 5000;
            //timerTeam.Elapsed += timer_TeamSyn;
            //timerTeam.Start();

            ////工人定时同步
            //timerWorker.Interval = sInterval;
            //timerWorker.Elapsed += timer_WorkerSyn;
            //timerWorker.Start();

            ////考勤定时同步
            //timerAuth.Interval = sInterval;
            //timerAuth.Elapsed += timer_AuthSyn;
            //timerAuth.Start();

            ////异常定时同步
            //timerAbnormal.Interval = 1800000;//半个小时同步
            //timerAbnormal.Elapsed += RePushExceptions;
            //timerAbnormal.Start();
            LogHelper.Info($"{DateTime.Now},服务停止！");


        }
        protected override void OnPause()
        {
            //服务暂停执行代码
            base.OnPause();
        }
        protected override void OnContinue()
        {
            //服务恢复执行代码
            base.OnContinue();
        }
        protected override void OnShutdown()
        {
            //系统即将关闭执行代码
            base.OnShutdown();
        }
        public void ontest() {


        }
    }
}
