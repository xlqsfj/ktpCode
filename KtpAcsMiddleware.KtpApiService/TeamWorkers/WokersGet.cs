using KS.Resting;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Api;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.TeamWorkers
{
    
    public class WokersGet : ApiBase<WorkerSend, WorkersResult>
    {
    
        public WokersGet()
          : base()
        {

         
            base.API = "/user/list";
            base.ServiceName = ApiType.KTP;
            base.MethodType = Method.POST;
            base.Token = ConfigHelper.KtpLoginToken;
        }

        /// <summary>
        /// 请求的方法
        /// </summary>
        /// <returns>传输的参数</returns>
        protected override WorkerSend FetchDataToPush()
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
        protected override PushSummary OnPushSuccess(RichRestRequest request, WorkersResult receiveData)
        {
            PushSummary mag = new PushSummary(receiveData.result==1?true:false, receiveData.msg,ApiType.KTP, request, "查询人员列表接口");
            mag.ResponseData = receiveData;
            return mag;
        }
    }
}
