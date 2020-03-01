using System;
using System.Threading;
using System.Windows.Forms;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Asp.AuthenticationSyncs;
using KtpAcsMiddleware.WinForm.Shared;

namespace KtpAcsMiddleware.WinForm.KtpLibrary
{
    public partial class AuthenticationSyncPrompt : FormBaseUi
    {
        private readonly string _authId;
        private readonly Thread _workthread;

        public AuthenticationSyncPrompt()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            _workthread = null;
            _workthread = new Thread(PushAuthentications) {IsBackground = true};
            _workthread.Start();
        }

        /// <summary>
        ///     入口：推送指定考勤，直接向云端上传
        /// </summary>
        /// <param name="authId">考勤记录ID</param>
        public AuthenticationSyncPrompt(string authId)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            _authId = authId;

            _workthread = null;
            _workthread = new Thread(PushAuthentication) {IsBackground = true};
            _workthread.Start();
        }

        /// <summary>
        ///     推送(上传)全部考勤数据
        /// </summary>
        private void PushAuthentications()
        {
            try
            {
                OkButton.Enabled = false;
                var authSyncService = new AuthSyncAspService();
                MsgLabel.Text = @"正在上传......";
                authSyncService.PushAuthentications();
                MsgLabel.Text = @"上传成功";
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
        ///     推送(上传)指定考勤数据
        /// </summary>
        private void PushAuthentication()
        {
            try
            {
                OkButton.Enabled = false;
                var authSyncService = new AuthSyncAspService();
                MsgLabel.Text = @"正在上传......";
                authSyncService.PushAuthentication(_authId);
                MsgLabel.Text = @"上传成功";
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
        private void AuthenticationSyncPrompt_FormClosing(object sender, FormClosingEventArgs e)
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