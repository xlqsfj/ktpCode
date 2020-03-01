using System;
using System.Threading;
using System.Windows.Forms;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.Sync
{
    public partial class KtpSync : Form
    {
        private bool _isRun;
        private bool _isStop;
        private Thread _uithread;
        private Thread _workthread;

        public KtpSync()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            _isRun = false;
            _isStop = false;
        }

        /// <summary>
        ///     窗口关闭事件
        /// </summary>
        private void KtpSync_FormClosing(object sender, FormClosingEventArgs e)
        {
            _isStop = true;
        }

        /// <summary>
        ///     停止按钮点击事件
        /// </summary>
        private void StopButton_Click(object sender, EventArgs e)
        {
            if (_isRun)
            {
                _isStop = true;
                StopButton.Text = @"正在停止";
                StopButton.Enabled = false;
            }
            else
            {
                StopService();
            }
        }

        /// <summary>
        ///     退出按钮点击事件
        /// </summary>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (_isRun)
            {
                MessageBox.Show(@"服务正在运行，请先停止。");
            }
            Application.Exit();
        }

        /// <summary>
        ///     同步按钮点击事件:运行服务
        /// </summary>
        private void StartServiceButton_Click(object sender, EventArgs e)
        {
            if (!ConfigHelper.CustomFilesDirIsLocal)
            {
                MessageBox.Show(@"同步操作必须在服务器本机运行，且需要配置文件存储路径。");
                return;
            }
            _uithread = null;
            _uithread = new Thread(DisableControls) {IsBackground = true};
            _uithread.Start();

            _workthread = null;
            _workthread = new Thread(StartService) {IsBackground = true};
            _workthread.Start();
        }

        /// <summary>
        ///     单次同步按钮点击事件
        /// </summary>
        private void SingleTimeSyncButton_Click(object sender, EventArgs e)
        {
            if (!ConfigHelper.CustomFilesDirIsLocal)
            {
                MessageBox.Show(@"同步操作必须在服务器本机运行，且需要配置文件存储路径。");
                return;
            }
            _uithread = null;
            _uithread = new Thread(DisableControls) {IsBackground = true};
            _uithread.Start();

            _workthread = null;
            _workthread = new Thread(SingleTimeSync) {IsBackground = true};
            _workthread.Start();
        }

        /// <summary>
        ///     覆盖推送
        /// </summary>
        private void CoverPushButton_Click(object sender, EventArgs e)
        {
            if (!ConfigHelper.CustomFilesDirIsLocal)
            {
                MessageBox.Show(@"同步操作必须在服务器本机运行，且需要配置文件存储路径。");
                return;
            }
            _uithread = null;
            _uithread = new Thread(DisableControls) {IsBackground = true};
            _uithread.Start();

            _workthread = null;
            _workthread = new Thread(CoverPush) {IsBackground = true};
            _workthread.Start();
        }

        /// <summary>
        ///     异常重推(重新推送所有出现异常的数据--班组、工人)
        /// </summary>
        private void RePushExceptionsButton_Click(object sender, EventArgs e)
        {
            if (!ConfigHelper.CustomFilesDirIsLocal)
            {
                MessageBox.Show(@"同步操作必须在服务器本机运行，且需要配置文件存储路径。");
                return;
            }
            _uithread = null;
            _uithread = new Thread(DisableControls) {IsBackground = true};
            _uithread.Start();

            _workthread = null;
            _workthread = new Thread(RePushExceptions) {IsBackground = true};
            _workthread.Start();
        }

        /// <summary>
        ///     停止服务
        /// </summary>
        private void StopService()
        {
            if (_uithread != null && _uithread.IsAlive)
            {
                _uithread.Abort();
            }
            EnabledControls();
            _isRun = false;
            _isStop = false;
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

        /// <summary>
        ///     禁用控件
        /// </summary>
        private void DisableControls()
        {
            Text = @"KtpAcsMiddleware数据同步-运行中...";
            StartServiceButton.Enabled = false;
            ExitButton.Enabled = false;
            SingleTimeSyncButton.Enabled = false;
            CoverPushButton.Enabled = false;
            RePushExceptionsButton.Enabled = false;
        }

        /// <summary>
        ///     激活控件
        /// </summary>
        private void EnabledControls()
        {
            Text = @"KtpAcsMiddleware数据同步";
            StartServiceButton.Enabled = true;
            ExitButton.Enabled = true;
            SingleTimeSyncButton.Enabled = true;
            StopButton.Text = @"停止";
            StopButton.Enabled = true;
            CoverPushButton.Enabled = true;
            RePushExceptionsButton.Enabled = true;
        }
    }
}