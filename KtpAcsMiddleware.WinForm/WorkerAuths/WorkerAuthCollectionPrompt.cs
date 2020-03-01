using System;
using System.Threading;
using System.Windows.Forms;
using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.WinForm.Shared;

namespace KtpAcsMiddleware.WinForm.WorkerAuths
{
    public partial class WorkerAuthCollectionPrompt : FormBaseUi
    {
        private readonly string _authId;
        private readonly Thread _workthread;

        public WorkerAuthCollectionPrompt()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            _workthread = null;
            _workthread = new Thread(CollectionWorkerAuths) {IsBackground = true};
            _workthread.Start();
        }

        /// <summary>
        ///     采集(刷新)工人考勤信息
        /// </summary>
        private void CollectionWorkerAuths()
        {
            try
            {
                OkButton.Enabled = false;

                MsgLabel.Text = @"正在刷新......";
                ServiceFactory.WorkerAuthService.CollectionWorkerAuths();
                MsgLabel.Text = @"刷新成功";
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
        private void WorkerAuthCollectionPrompt_FormClosing(object sender, FormClosingEventArgs e)
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