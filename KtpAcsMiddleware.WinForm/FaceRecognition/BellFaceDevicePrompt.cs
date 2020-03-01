using System;
using System.Threading;
using System.Windows.Forms;
using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.Domain.FaceRecognition;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.WinForm.Shared;

namespace KtpAcsMiddleware.WinForm.FaceRecognition
{
    public partial class BellFaceDevicePrompt : FormBaseUi
    {
        private readonly string _ipAddress;
        private readonly Thread _workthread;

        /// <summary>
        ///     入口：通知所有
        /// </summary>
        public BellFaceDevicePrompt()
        {
            InitializeComponent();
            //通知所有设备
            CheckForIllegalCrossThreadCalls = false;
            _workthread = null;
            _workthread = new Thread(BellAll) {IsBackground = true};
            _workthread.Start();
        }

        /// <summary>
        ///     入口：通知指定IP
        /// </summary>
        public BellFaceDevicePrompt(string ipAddress)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            _ipAddress = ipAddress;

            _workthread = null;
            _workthread = new Thread(SingleTimeBell) {IsBackground = true};
            _workthread.Start();
        }

        /// <summary>
        ///     单个通知
        /// </summary>
        private void SingleTimeBell()
        {
            try
            {
                OkButton.Enabled = false;
                if (string.IsNullOrEmpty(_ipAddress))
                {
                    MsgLabel.Text = @"IP地址不允许为空";
                }
                else
                {
                    FaceDeviceWorkerEntityService.BellDeviceSyncFaceLibrary(_ipAddress);
                    MsgLabel.Text = @"通知成功";
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
        ///     通知所有
        /// </summary>
        private void BellAll()
        {
            try
            {
                OkButton.Enabled = false;
                var devices = ServiceFactory.FaceDeviceService.GetAll();
                var exDeviceCodes = string.Empty;
                foreach (var device in devices)
                {
                    var ipAddress = device.IpAddress;
                    if (string.IsNullOrEmpty(ipAddress))
                    {
                        continue;
                    }
                    try
                    {
                        MsgLabel.Text = $@"正在通知<{device.Code}>......";
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
                if (exDeviceCodes == string.Empty)
                {
                    MsgLabel.Text = @"所有设备通知成功";
                }
                else
                {
                    MsgLabel.Text = $@"<{exDeviceCodes.TrimEnd(',')}>通知失败";
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
        private void BellFaceDevicePrompt_FormClosing(object sender, FormClosingEventArgs e)
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