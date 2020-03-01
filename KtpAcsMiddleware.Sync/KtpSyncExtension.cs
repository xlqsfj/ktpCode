using System;
using System.Threading;
using System.Windows.Forms;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Asp;

namespace KtpAcsMiddleware.Sync
{
    public partial class KtpSync
    {
        /// <summary>
        ///     同步(服务)函数
        /// </summary>
        private void StartService()
        {
            while (true)
            {
                try
                {
                    if (_isStop)
                    {
                        break;
                    }
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
                    _isRun = true;

                    var syncService = new AspSyncService();
                    syncService.SyncToKtpIgnoreEx();
                }
                catch (Exception ex)
                {
                    LogHelper.ExceptionLog(ex);
                }
                finally
                {
                    _isRun = false;
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
                }
            }
            //出了循环，停止服务
            StopService();
        }

        /// <summary>
        ///     单次同步函数
        /// </summary>
        private void SingleTimeSync()
        {
            try
            {
                _isRun = true;
                var syncService = new AspSyncService();
                syncService.SyncToKtp();
                MessageBox.Show(@"同步完成");
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageBox.Show($@"出现异常,{ex.Message}");
            }
            finally
            {
                _isRun = false;
                StopService();
            }
        }

        /// <summary>
        ///     覆盖推送(单次)
        /// </summary>
        private void CoverPush()
        {
            try
            {
                _isRun = true;

                var coverPushService = new AspCoverPushService();
                coverPushService.CoverPushTeamWorkers();

                MessageBox.Show(@"推送完成");
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageBox.Show(@"出现异常,请联系技术人员查看日志");
            }
            finally
            {
                _isRun = false;
                StopService();
            }
        }

        /// <summary>
        ///     异常重推(重新推送所有出现异常的数据--班组、工人)(单次)
        /// </summary>
        private void RePushExceptions()
        {
            try
            {
                _isRun = true;

                var aspSyncService = new AspSyncService();
                aspSyncService.RePushExceptions();

                MessageBox.Show(@"推送完成");
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageBox.Show(@"出现异常,请联系技术人员查看日志");
            }
            finally
            {
                _isRun = false;
                StopService();
            }
        }
    }
}