using System;
using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.WinForm.Models;
using KtpAcsMiddleware.WinForm.Shared;

namespace KtpAcsMiddleware.WinForm.FaceRecognition
{
    public partial class FaceDeviceDetail : FormBaseUi
    {
        private readonly string _deviceId;

        public FaceDeviceDetail()
        {
            InitializeComponent();
            _deviceId = null;
        }

        public FaceDeviceDetail(string id)
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

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}