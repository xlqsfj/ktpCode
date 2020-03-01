using System;
using System.ServiceProcess;
using System.Threading;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Asp;

namespace KtpAcsMiddleware.WinServvice
{
    public partial class Service1 : ServiceBase
    {
        private bool _isStop;
        private Thread _rePushExceptionsThread;
        private Thread _syncToKtpThread;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            LogHelper.Info("服务正在启动......");
            if (!ConfigHelper.CustomFilesDirIsLocal)
            {
                LogHelper.ExceptionLog("同步操作必须在服务器本机运行，且需要配置文件存储路径。");
                LogHelper.Info("配置错误，工作线程未运行");
                return;
            }
            //睡眠30秒，避免在数据库服务启动完成前启动
            Thread.Sleep(30000);
            try
            {
                LogHelper.Info("服务已启动,开始做OnStart处理......");
                var syncService = new AspSyncService();
                syncService.SyncToKtpIgnoreEx();
                LogHelper.Info("OnStart处理完成,工作线程开始......");

                _syncToKtpThread = new Thread(SyncToKtp) {IsBackground = true};
                _syncToKtpThread.Start();
                _rePushExceptionsThread = new Thread(RePushExceptions) {IsBackground = true};
                _rePushExceptionsThread.Start();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
            }
        }

        protected override void OnStop()
        {
            _isStop = true;
            StopService();
        }

        private void SyncToKtp()
        {
            while (true)
            {
                try
                {
                    if (!string.IsNullOrEmpty(ConfigHelper.ThreadRunTime))
                    {
                        var dateRun = DateTime.Now.Date
                            .AddHours(int.Parse(ConfigHelper.ThreadRunTime.Split(':')[0]))
                            .AddMinutes(int.Parse(ConfigHelper.ThreadRunTime.Split(':')[1]));
                        var now = DateTime.Now;
                        if (now.Hour == dateRun.Hour)
                        {
                            if (now.Minute < dateRun.Minute)
                            {
                                //睡眠50秒,每分钟检查一次
                                Thread.Sleep(50000);
                                continue;
                            }
                        }
                        else if (now > dateRun)
                        {
                            //计算间隔时间，睡眠时间少于间隔时间2秒
                            Thread.Sleep((int) (((dateRun.AddHours(24) - now).TotalSeconds - 2) * 1000));
                            continue;
                        }
                        else
                        {
                            //计算间隔时间，睡眠时间少于间隔时间2秒
                            Thread.Sleep((int) (((dateRun - now).TotalSeconds - 2) * 1000));
                            continue;
                        }
                    }
                    var syncService = new AspSyncService();
                    syncService.SyncToKtpIgnoreEx();
                }
                catch (Exception ex)
                {
                    LogHelper.ExceptionLog(ex);
                }
                finally
                {
                    if (!_isStop)
                    {
                        if (string.IsNullOrEmpty(ConfigHelper.ThreadRunTime))
                        {
                            //如果没有设置特定时间运行，则执行间隔运行机制
                            Thread.Sleep(ConfigHelper.ThreadSleepTime);
                        }
                        else
                        {
                            //睡眠一个小时==避免符合定时设置后多次运行
                            Thread.Sleep(3600000);
                        }
                    }
                    else
                    {
                        StopService();
                    }
                }
            }
        }

        /// <summary>
        ///     异常数据重新执行
        /// </summary>
        private void RePushExceptions()
        {
            while (true)
            {
                try
                {
                    var syncService = new AspSyncService();
                    syncService.RePushExceptions();
                }
                catch (Exception ex)
                {
                    LogHelper.ExceptionLog(ex);
                }
                finally
                {
                    Thread.Sleep(1800000); //半个小时一次
                }
            }
        }

        private void StopService()
        {
            if (_syncToKtpThread != null && _syncToKtpThread.IsAlive)
            {
                _syncToKtpThread.Abort();
            }
            if (_rePushExceptionsThread != null && _rePushExceptionsThread.IsAlive)
            {
                _rePushExceptionsThread.Abort();
            }
        }
    }
}