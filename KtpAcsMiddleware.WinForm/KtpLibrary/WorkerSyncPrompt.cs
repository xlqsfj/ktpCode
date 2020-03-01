using System;
using System.Threading;
using System.Windows.Forms;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Asp.AuthenticationSyncs;
using KtpAcsMiddleware.KtpApiService.Asp.TeamSyncs;
using KtpAcsMiddleware.KtpApiService.Asp.WorkerSyncs;
using KtpAcsMiddleware.WinForm.Shared;

namespace KtpAcsMiddleware.WinForm.KtpLibrary
{
    public partial class WorkerSyncPrompt : FormBaseUi
    {
        /// <summary>
        ///     类型：1=推送，2=拉取，3=同步，4=拉取所有班组和工人并推送考勤
        /// </summary>
        private readonly int _type;

        private readonly string _workerId;
        private readonly Thread _workthread;

        public WorkerSyncPrompt()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     入口：同步指定工人，不走同步逻辑，直接按方向覆盖
        /// </summary>
        /// <param name="workerId">工人ID</param>
        /// <param name="type">类型：1=推送，2=拉取</param>
        public WorkerSyncPrompt(string workerId, int type)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            _workerId = workerId;
            _type = type;

            _workthread = null;
            _workthread = new Thread(SyncWorker) {IsBackground = true};
            _workthread.Start();
        }

        /// <summary>
        ///     入口：同步全部工人，走同步逻辑
        /// </summary>
        /// <param name="type">类型：1=推送，2=拉取，3=同步，4=拉取所有班组和工人并推送考勤</param>
        public WorkerSyncPrompt(int type)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            _type = type;

            _workthread = null;
            _workthread = new Thread(SyncWorkers) {IsBackground = true};
            _workthread.Start();
        }

        /// <summary>
        ///     同步(拉取/推送)单个工人
        /// </summary>
        private void SyncWorker()
        {
            try
            {
                var workerSyncDesignatedService = new WorkerSyncAspDesignatedService();
                OkButton.Enabled = false;
                if (string.IsNullOrEmpty(_workerId))
                {
                    MsgLabel.Text = @"工人ID不允许为空";
                }
                else
                {
                    switch (_type)
                    {
                        case 1:
                            MsgLabel.Text = @"正在推送......";
                            workerSyncDesignatedService.PushWorker(_workerId);
                            MsgLabel.Text = @"推送成功";
                            break;
                        case 2:
                            MsgLabel.Text = @"正在拉取......";
                            workerSyncDesignatedService.PullWorker(_workerId);
                            MsgLabel.Text = @"拉取成功";
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MsgLabel.Text = ex.Message;
            }
            finally
            {
                ControlBox = true;
                OkButton.Enabled = true;
            }
        }

        /// <summary>
        ///     同步(拉取/推送/双向同步)全部工人
        /// </summary>
        private void SyncWorkers()
        {
            try
            {
                var workerSyncService = new WorkerSyncAspService();
                OkButton.Enabled = false;

                switch (_type)
                {
                    case 1:
                        MsgLabel.Text = @"正在推送......";
                        workerSyncService.PushWorkers();
                        workerSyncService.PushDelWorkers();
                        MsgLabel.Text = @"推送成功";
                        break;
                    case 2:
                        MsgLabel.Text = @"正在拉取......";
                        workerSyncService.PullWorkers();
                        MsgLabel.Text = @"拉取成功";
                        break;
                    case 3:
                        MsgLabel.Text = @"正在同步......";
                        workerSyncService.SyncWorkers();
                        MsgLabel.Text = @"同步成功";
                        break;
                    case 4:
                        MsgLabel.Text = @"正在拉取......";
                        //拉取班组
                        var teamSyncService = new TeamSyncAspService();
                        teamSyncService.PullTeams();
                        //拉取工人
                        workerSyncService.PullWorkers();
                        //推送考勤
                        var authSyncService = new AuthSyncAspService();
                        authSyncService.PushAuthentications();
                        MsgLabel.Text = @"拉取成功";
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MsgLabel.Text = ex.Message;
            }
            finally
            {
                ControlBox = true;
                OkButton.Enabled = true;
            }
        }

        /// <summary>
        ///     确认按钮事件
        /// </summary>
        private void OkButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        ///     窗口关闭事件
        /// </summary>
        private void WorkerSyncPrompt_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_workthread != null && _workthread.IsAlive)
                {
                    _workthread.Resume();
                    _workthread.Abort();
                }
            }
            catch
            {
                // ignored
            }
        }
    }
}