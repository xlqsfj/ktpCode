using CCWin;
using KtpAcs.WinForm.Models;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Asp.AuthenticationSyncs;
using KtpAcsMiddleware.KtpApiService.Asp.WorkerSyncs;
using KtpAcsMiddleware.KtpApiService.Asp.WorkerSyncs.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KtpAcs.WinForm.Shared
{
    public partial class SynWorkerForm : Skin_Mac
    {

        /// <summary>
        ///同步所有工人
        /// </summary>
        public SynWorkerForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            _workthread = null;
            _workthread = new Thread(SynWorkers) { IsBackground = true };
            _workthread.Start();
        }

        /// <summary>
        ///1、拉取所有工人1
        /// </summary>
        public SynWorkerForm(int type)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            _workthread = null;
            _workthread = new Thread(ObtainWorkers) { IsBackground = true };
            _workthread.Start();
        }



        private readonly Thread _workthread;

        /// <summary>
        ///     入口：推送指定考勤，直接向云端上传
        /// </summary>
        /// <param name="workerId">考勤记录ID</param>
        public SynWorkerForm(string workerId)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            _workthread = null;
            _workthread = new Thread(PushAuthentication) { IsBackground = true };
            _workthread.Start(workerId);
        }




        /// <summary>
        ///推送(上传)指定考勤数据
        /// </summary>
        /// <param name="authId"></param>
        private void PushAuthentication(dynamic workerId)
        {
            try
            {

                var workerAspSys = new WorkerAspSys();

                workerAspSys.PushWorker(workerId);
                //关闭加载页面
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
        /// 拉取所有工人
        /// </summary>
        private void ObtainWorkers()
        {
            var wokerObtain = new KtpWokerObtainList();
            wokerObtain.PullWorkers();
            //关闭加载页面
            closeOrder();

        }
        /// <summary>
        /// 同步所有工人
        /// </summary>
        private void SynWorkers()
        {
            try
            {
                var workerAspSys = new WorkerAspSys();
                workerAspSys.SyncWorkers();
                //关闭加载页面
                closeOrder();
                MessageHelper.Show("同步成功");
            }
            catch (Exception ex)
            {   //关闭加载页面
                closeOrder();
                MessageHelper.Show(ex.Message);
             
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


}
