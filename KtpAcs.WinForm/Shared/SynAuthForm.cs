using CCWin;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Asp.AuthenticationSyncs;
using System;
using System.Threading;

namespace KtpAcs.WinForm.Shared
{
    public partial class SynAuthForm : Skin_Mac
    {


        private readonly Thread _workthread;
     
        /// <summary>
        ///     入口：推送指定考勤，直接向云端上传
        /// </summary>
        /// <param name="authId">考勤记录ID</param>
        public SynAuthForm(string authId)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            _workthread = null;
            _workthread = new Thread(PushAuthentication) { IsBackground = true };
            _workthread.Start(authId);
        }
        /// <summary>
        ///     入口：推送指定考勤，直接向云端上传
        /// </summary>
        /// <param name="authId">考勤记录ID</param>
        public SynAuthForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            _workthread = null;
            _workthread = new Thread(PushAuthentications) { IsBackground = true };
            _workthread.Start();
        }

        /// <summary>
        ///推送(上传)指定考勤数据
        /// </summary>
        /// <param name="authId"></param>
        private void PushAuthentication(dynamic authId)
        {
            try
            {
              
                var authSyncService = new AuthSyncAspService();
                this.Text = "考勤同步提示";
                authSyncService.PushAuthentication(authId);
                closeOrder();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
        
            }
            finally
            {
                ControlBox = true;
     
            }
        }
        /// <summary>
        ///     推送(上传)全部考勤数据
        /// </summary>
        private void PushAuthentications()
        {
            try
            {
            
                var authSyncService = new AuthSyncAspService();
      
                authSyncService.PushAuthentications();
                closeOrder();

            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
  
            }
            finally
            {
                ControlBox = true;
           
            }
        }
        /// <summary>
        /// 关闭命令
        /// </summary>
        public void closeOrder()
        {
            if (this.InvokeRequired)
            {
                //这里利用委托进行窗体的操作，避免跨线程调用时抛异常，后面给出具体定义
                CONSTANTDEFINE.SetUISomeInfo UIinfo = new CONSTANTDEFINE.SetUISomeInfo(new Action(() =>
                {
                    while (!this.IsHandleCreated)
                    {
                        ;
                    }
                    if (this.IsDisposed)
                        return;
                    if (!this.IsDisposed)
                    {
                        this.Dispose();
                    }

                }));
                this.Invoke(UIinfo);
            }
            else
            {
                if (this.IsDisposed)
                    return;
                if (!this.IsDisposed)
                {
                    this.Dispose();
                }
            }
        }

    }
    public class CONSTANTDEFINE
    {

        public delegate void SetUISomeInfo();
    }
}
