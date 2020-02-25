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
using static KtpAcsMiddleware.KtpApiService.PanelApi.PanelWorkerSend;

namespace KtpAcsMiddleware.KtpApiService.TeamWorkers
{
    /// <summary>
    /// 手机发送验证码
    /// </summary>
    public class WorkerPhoneSet : ApiBase<dynamic, ResultNoData>
    {
    

        public WorkerPhoneSet()
          : base()
        {

      
            base.API = "/sms/send";
            base.ServiceName = ApiType.KTP;
            base.MethodType = Method.POST;
            base.Token = ConfigHelper.KtpLoginToken;
        }

        /// <summary>
        /// 请求的方法
        /// </summary>
        /// <returns>传输的参数</returns>
        protected override dynamic FetchDataToPush()
        {
      

            return base.RequestParam;
        }

        protected override void OnPushFailed(RichRestRequest request, string errorSummary)
        {

        }
        /// <summary>
        /// 返回信息方法
        /// </summary>
        /// <param name="request">请求的参数</param>
        /// <param name="receiveData">返回的参数</param>
        /// <returns></returns>
        protected override PushSummary OnPushSuccess(RichRestRequest request, ResultNoData receiveData)
        {
            PushSummary mag = new PushSummary(receiveData.success, receiveData.msg, ApiType.KTP, request, "手机发送验证码接口");
            mag.ResponseData = receiveData;
            return mag;
        }

    
    }
}
