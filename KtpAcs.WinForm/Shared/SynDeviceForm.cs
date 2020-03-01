using CCWin;
using KtpAcs.WinForm.Models;
using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.Domain.FaceRecognition;
using KtpAcsMiddleware.Infrastructure.Utilities;
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
    public partial class SynDeviceForm : Skin_Mac
    {
        private readonly Thread _workthread;

        /// <summary>
        /// 通知全部设备
        /// </summary>
        public SynDeviceForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;


            _workthread = null;
            _workthread = new Thread(BellAll) { IsBackground = true };
            _workthread.Start();
        }
        /// <summary>
        /// 通知当前设备
        /// </summary>
        /// <param name="ipAddress"></param>
        public SynDeviceForm(string ipAddress)
        {

            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;


            _workthread = null;
            _workthread = new Thread(SingleTimeBell) { IsBackground = true };
            _workthread.Start(ipAddress);
        }

        /// <summary>
        ///     通知所有
        /// </summary>
        private void BellAll()
        {
            try
            {

                var devices = ServiceFactory.FaceDeviceService.GetAll();
                var exDeviceCodes = string.Empty;
                this.MsgLabel.Visible = true;
                foreach (var device in devices)
                {
                    var ipAddress = device.IpAddress;
                    if (string.IsNullOrEmpty(ipAddress))
                    {
                        continue;
                    }
                    try
                    {

                        FaceDeviceWorkerEntityService.BellDeviceSyncFaceLibrary(ipAddress);
                        MsgLabel.Text = $@"<{device.Code}>通知成功";

                    }
                    catch (Exception ex)
                    {
                        LogHelper.ExceptionLog(ex, $"BellFaceDevicePrompt.BellAll.<{device.Code}>");
                        MsgLabel.Text = $@"<{device.Code}>通知失败";
                        exDeviceCodes = $"{exDeviceCodes}{device.Code},";
                    }
                }
                this.MsgLabel.Visible = true;
                if (exDeviceCodes == string.Empty)
                {
                    MsgLabel.Visible = false;
                    showMag(@"所有设备通知成功");
                }
                else
                {
                    showMag($@"<{exDeviceCodes.TrimEnd(',')}>通知失败");
                }
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                showMag(ex.Message);
            }
            finally
            {
                ControlBox = true;

            }
        }
        /// <summary>
        ///     单个通知
        /// </summary>
        private void SingleTimeBell(dynamic ipAddress)
        {
            try
            {

                if (string.IsNullOrEmpty(ipAddress))
                {

                    showMag("IP地址不允许为空");
                }
                else
                {
                    FaceDeviceWorkerEntityService.BellDeviceSyncFaceLibrary(ipAddress);

                    showMag("通知成功");
                }
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);

                showMag(ex.Message);
            }
            finally
            {
                ControlBox = true;

            }
        }

        public void showMag(string mag)
        {
            closeOrder();
            MessageHelper.Show(mag);
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
