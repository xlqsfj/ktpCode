using KS.Resting;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Api;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.TeamWorkers
{
    /// <summary>
    /// 新增班组列表
    /// </summary>
    public class TeamSet : ApiBase<DataItem, TeamAddResult>
    {
    
        public TeamSet()
          : base()
        {

         
            base.API = "/proorgan/createOrUpdateTeam";
            base.ServiceName = ApiType.KTP;
            base.MethodType = Method.POST;
            base.Token = ConfigHelper.KtpLoginToken;
        }

        /// <summary>
        /// 请求的方法
        /// </summary>
        /// <returns>传输的参数</returns>
        protected override DataItem FetchDataToPush()
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
        protected override PushSummary OnPushSuccess(RichRestRequest request, TeamAddResult receiveData)
        {
            PushSummary mag = new PushSummary(receiveData.result==1?true:false, receiveData.msg,ApiType.KTP,request, "添加班组列表");
            mag.ResponseData = receiveData;
            return mag;
        }
    }
}
