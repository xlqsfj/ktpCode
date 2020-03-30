using System;
using System.Threading;
using System.Windows.Forms;
using KtpAcsMiddleware.Infrastructure.Utilities;

using KtpAcsMiddleware.WinForm.Api.Shared;

namespace KtpAcsMiddleware.WinForm.Api.KtpLibrary
{
    public partial class TeamSyncPrompt : FormBaseUi
    {
        private readonly string _teamId;

        /// <summary>
        ///     类型：1=推送，2=拉取，3=同步
        /// </summary>
        private readonly int _type;

        private readonly Thread _workthread;

        public TeamSyncPrompt()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        /// <summary>
        ///     入口：同步指定班组，不走同步逻辑，直接按方向覆盖
        /// </summary>
        /// <param name="teamId">班组ID</param>
        /// <param name="type">类型：1=推送，2=拉取</param>
        public TeamSyncPrompt(string teamId, int type)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            _teamId = teamId;
            _type = type;

            _workthread = null;
            _workthread = new Thread(SyncTeam) {IsBackground = true};
            _workthread.Start();
        }

        /// <summary>
        ///     入口：同步全部班组，走同步逻辑
        /// </summary>
        /// <param name="type">1=推送，2=拉取，3=同步</param>
        public TeamSyncPrompt(int type)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            _type = type;

            _workthread = null;
            _workthread = new Thread(SyncTeams) {IsBackground = true};
            _workthread.Start();
        }

        /// <summary>
        ///     同步(拉取/推送)单个班组
        /// </summary>
        private void SyncTeam()
        {
            try
            {
               
               
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
        ///     同步(拉取/推送/双向同步)全部班组
        /// </summary>
        private void SyncTeams()
        {
            try
            {
              
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
        private void TeamSyncPrompt_FormClosing(object sender, FormClosingEventArgs e)
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