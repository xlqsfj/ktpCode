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
    /// 查询人员详细信息
    /// </summary>
    public class WorkerGet : ApiBase<dynamic, WorkerResult>
    {
    

        public WorkerGet()
          : base()
        {

      
            base.API = "/user/details";
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
        protected override PushSummary OnPushSuccess(RichRestRequest request, WorkerResult receiveData)
        {
            PushSummary mag = new PushSummary(receiveData.success, receiveData.msg, ApiType.KTP, request, "查询详细信息接口");
            mag.ResponseData = receiveData;
            return mag;
        }

    
    }
}
