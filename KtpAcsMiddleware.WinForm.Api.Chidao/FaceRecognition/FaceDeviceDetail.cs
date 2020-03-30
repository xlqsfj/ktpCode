using System;
using System.Windows;
using CCWin;

using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService;
using KtpAcsMiddleware.KtpApiService.Api;
using KtpAcsMiddleware.KtpApiService.Device;
using KtpAcsMiddleware.KtpApiService.PanelApi;
using KtpAcsMiddleware.KtpApiService.PanelApi.PanelMage;
using KtpAcsMiddleware.KtpApiService.PanelApiCd;
using KtpAcsMiddleware.KtpApiService.PanelApiCd.CdModel;
using KtpAcsMiddleware.WinForm.Api.Models;
using KtpAcsMiddleware.WinForm.Api.Shared;

namespace KtpAcsMiddleware.WinForm.Api.FaceRecognition
{
    public partial class FaceDeviceDetail : Skin_Color
    {
        private  string _deviceId;
        int id = 0;
        public FaceDeviceDetail()
        {
            InitializeComponent();
            _deviceId = null;
        }

        public FaceDeviceDetail(string id)
        {
            InitializeComponent();

            _deviceId = id;


            IMulePusher pusher = new DeviceGet() { RequestParam = new { projectId = ConfigHelper.KtpLoginProjectId, proDeviceId = id } };
            PushSummary push = pusher.Push();
            ContentItem c = push.ResponseData[0];
            CodeTxt.Text = c.machineNum;
            IpAddressTxt.Text = c.deviceIp;
            DescriptionTxt.Text = c.description;


            if (c.deviceIn != null)
            {
                if (c.deviceIn == "进口")
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
            string submit = SaveBtn.Text;
            try
            {
                var isPrePass = true;
                PreValidationHelper.InitPreValidation(FormErrorProvider);
                //PreValidationHelper.MustNotBeNullOrEmpty(FormErrorProvider, CodeTxt, "编号(设备号)不能为空", ref isPrePass);
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
                if (!ConfigHelper.MyPing(IpAddressTxt.Text))
                {
                    FormErrorProvider.SetError(IpAddressTxt, "IP地址不通，请确定同一个网段");
                    throw new PreValidationException("IP地址不通，请确定同一个网段");

                }
                SaveBtn.Text = "正在添加。。";
                SaveBtn.Enabled = false;

               
                //查询设备序列号
                IMulePusher PanelDevice = new PanelGetCdDeviceApi() { PanelIp = IpAddressTxt.Text, RequestParam =new  { pass= ConfigHelper.CdPassPwd } };
                PushSummary PanelMag = PanelDevice.PushForm();
                PanelStringResult result = PanelMag.ResponseData;
                string deviceNo = result.data;
                //初始化密码
                IMulePusher PanelPwd = new PanelSetPwdApi() { PanelIp = IpAddressTxt.Text, RequestParam=new { oldPass= ConfigHelper.CdPassPwd, newPass= ConfigHelper.CdPassPwd } };
                PushSummary mag = PanelPwd.PushForm();

                if (!string.IsNullOrEmpty(_deviceId))
                    id = Convert.ToInt32(_deviceId);

                var device = new Device
                {
                    proId = ConfigHelper.KtpLoginProjectId,
                    id = id,
                    deviceNo = deviceNo,
                    deviceIp = IpAddressTxt.Text,
                    remark = DescriptionTxt.Text,
                    deviceIn = IsCheckInYesRb.Checked ? 1 : 0
                };

                IMulePusher pusher = new DeviceSet() { RequestParam = device };

                PushSummary ktpMag = pusher.Push();

                if (!ktpMag.Success) {

                    MessageHelper.Show(ktpMag.Message, @"刷新提示");
                    SaveBtn.Text = submit;
                    SaveBtn.Enabled = true;
                    return;
                }
                Result resultD = ktpMag.ResponseData;

                _deviceId = resultD.data.id.ToString();
                if (ktpMag.Success)
                {
                    MessageHelper.Show(@"创建成功", @"刷新提示");

                    Hide();
                }
                else
                {

                    MessageHelper.Show(ktpMag.Message, @"刷新提示");

                }
                SaveBtn.Text = submit;
                SaveBtn.Enabled = true;



            }
            catch (PreValidationException ex)
            {
                MessageHelper.Show(ex.Message);
                SaveBtn.Text = submit;
                SaveBtn.Enabled = true;
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show("创建库失败请重试!");
                SaveBtn.Text = submit;
                SaveBtn.Enabled = true;
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FaceDeviceDetail_Load(object sender, EventArgs e)
        {

        }
    }
}