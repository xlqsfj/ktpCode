using KS.Resting;
using KtpAcsMiddleware.KtpApiService.Api;
using KtpAcsMiddleware.KtpApiService.PanelApiHq.HqModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.PanelApiHq
{
  public   class PanelGetServiceParamApi : ApiBase<PanelSearchSend, HqResult>
    {
        public PanelGetServiceParamApi()
         : base()
        {


            base.API = "/action/CheckNet";
            base.MethodType = Method.POST;
            base.ServiceName = ApiType.PanelHq;

        }

        /// <summary>
        /// 请求的方法
        /// </summary>
        /// <returns>传输的参数</returns>
        protected override PanelSearchSend FetchDataToPush()
        {

            return base.RequestParam;
        }

        /// <summary>
        /// 返回信息方法
        /// </summary>
        /// <param name="request">请求的参数</param>
        /// <param name="receiveData">返回的参数</param>
        /// <returns></returns>
        protected override PushSummary OnPushSuccess(RichRestRequest request, HqResult receiveData)
        {
            string isSuccess = receiveData.info.Result;
            PushSummary mag = new PushSummary(isSuccess == "Fail" ? false : true, receiveData.info.Detail, ApiType.Panel, request, "闸门面板网络状态接口");

            mag.ResponseData = receiveData;
            return mag;
        }
    }
}
