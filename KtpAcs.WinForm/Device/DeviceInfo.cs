using CCWin;
using KtpAcs.WinForm.Models;
using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KtpAcs.WinForm.Device
{
    public partial class DeviceInfo : Skin_Color
    {
        private readonly string _deviceId;
        public DeviceInfo()
        {
            InitializeComponent();
            _deviceId = null;
        }
        public DeviceInfo(string id)
        {
            InitializeComponent();
            _deviceId = id;
            var device = ServiceFactory.FaceDeviceService.Get(_deviceId);
            CodeTxt.Text = device.Code;
            IpAddressTxt.Text = device.IpAddress;
            DescriptionTxt.Text = device.Description;
            if (device.IsCheckIn != null)
            {
                if (device.IsCheckIn == true)
                {
                    IsCheckInYesRb.Checked = true;
                }
                else
                {
                    IsCheckInNoRb.Checked = true;
                }
            }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 保存设备信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, EventArgs e)
        {

            try
            {
                var isPrePass = true;
                PreValidationHelper.InitPreValidation(FormErrorProvider);
                PreValidationHelper.MustNotBeNullOrEmpty(FormErrorProvider, CodeTxt, "编号(设备号)不能为空", ref isPrePass);
                PreValidationHelper.MustNotBeNullOrEmpty(FormErrorProvider, IpAddressTxt, "IP地址不能为空", ref isPrePass);
                PreValidationHelper.IsIpAddress(FormErrorProvider, IpAddressTxt, "IP地址格式错误", ref isPrePass);
                if (IsCheckInYesRb.Checked == false && IsCheckInNoRb.Checked == false)
                {
                    FormErrorProvider.SetError(IsCheckInNoRb, "必须选择是否是进场方向");
                    isPrePass = false;
                }
                if (!isPrePass)
                {
                    throw new PreValidationException(PreValidationHelper.ErroMsg);
                }

                var faceDevice = new FaceDevice
                {
                    Id = _deviceId,
                    Code = CodeTxt.Text.Trim(),
                    IpAddress = IpAddressTxt.Text,
                    Description = DescriptionTxt.Text,
                    IsCheckIn = IsCheckInYesRb.Checked
                };
                if (ServiceFactory.FaceDeviceService.Any(faceDevice.Code, faceDevice.Id))
                {
                    FormErrorProvider.SetError(CodeTxt, "编号(设备号)不允许重复");
                    throw new PreValidationException("编号(设备号)不允许重复");
                }
                if (!string.IsNullOrEmpty(_deviceId))
                {
                    ServiceFactory.FaceDeviceService.Change(faceDevice, _deviceId);
                }
                else
                {
                    ServiceFactory.FaceDeviceService.Add(faceDevice);
                }
                Hide();
            }
            catch (PreValidationException ex)
            {
                MessageHelper.Show(ex.Message);
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show(ex);
            }
        }
    }
}
