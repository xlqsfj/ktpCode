using KS.Resting;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Api;
using KtpAcsMiddleware.KtpApiService.PanelApi;
using KtpAcsMiddleware.KtpApiService.PanelApi.PanelMage;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.Device
{
    public class DeviceSet : ApiBase<Device, Result>
    {


        public DeviceSet()
          : base()
        {


            base.API = "/prodevice/saveProDevice";
            base.ServiceName = ApiType.KTP;
            base.MethodType = Method.POST;
            base.Token = ConfigHelper.KtpLoginToken;
        }


        protected override Device FetchDataToPush()
        {


            return base.RequestParam;
        }

        protected override void OnPushFailed(RichRestRequest request, string errorSummary)
        {

        }
        protected override PushSummary OnPushSuccess(RichRestRequest request, Result receiveData)
        {
            PushSummary mag = new PushSummary(receiveData.success, receiveData.msg);
            mag.ResponseData = receiveData;
            if (!mag.Success)
            {
                return mag;
            }

            //Device device = this.RequestParam;
            //Liblist liblist = PanelBase.GetPanelDeviceInfo(device.deviceIp);

            return mag;
        }
    }
}
