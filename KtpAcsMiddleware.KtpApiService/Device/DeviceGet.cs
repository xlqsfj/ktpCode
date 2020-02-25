using KS.Resting;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Api;
using KtpAcsMiddleware.KtpApiService.PanelApi;
using KtpAcsMiddleware.KtpApiService.PanelApi.PanelMage;
using KtpAcsMiddleware.KtpApiService.PanelApiCd;
using KtpAcsMiddleware.KtpApiService.PanelApiCd.CdModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.Device
{
    /// <summary>
    /// 查询ktp设备信息列表
    /// </summary>
    public class DeviceGet : ApiBase<dynamic, DeviceResult>
    {



        public DeviceGet()
          : base()
        {
            base.API = "/project/deviceinfo";
            base.ServiceName = ApiType.KTP;
            base.MethodType = Method.POST;
            base.Token = ConfigHelper.KtpLoginToken;
        }


        protected override dynamic FetchDataToPush()
        {
       

            return base.RequestParam;
        }

        protected override void OnPushFailed(RichRestRequest request, string errorSummary)
        {

        }


        protected override PushSummary OnPushSuccess(RichRestRequest request, DeviceResult receiveData)
        {
            PushSummary mag = new PushSummary(receiveData.success, receiveData.msg, ApiType.KTP, request, "查询设备列表接口");

            if (receiveData.data != null)
            {



                mag.ResponseData = receiveData.data;


            }
            return mag;
        }

    }
}

