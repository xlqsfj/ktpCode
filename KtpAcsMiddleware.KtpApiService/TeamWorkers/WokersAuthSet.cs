using KS.Resting;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Api;
using KtpAcsMiddleware.KtpApiService.TeamWorkers.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.TeamWorkers
{

    /// <summary>
    /// 写入人员考勤
    /// </summary>
    public class WokersAuthSet : ApiBase<AuthSend, AuthResult>
    {

        public WokersAuthSet()
          : base()
        {


            base.API = "/api/app/attendance/attendance-app/attendanceOld";
            base.ServiceName = ApiType.App;
            base.MethodType = Method.POST;

        }

        /// <summary>
        /// 请求的方法
        /// </summary>
        /// <returns>传输的参数</returns>
        protected override AuthSend FetchDataToPush()
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
        protected override PushSummary OnPushSuccess(RichRestRequest request, AuthResult receiveData)
        {
            PushSummary mag = new PushSummary(receiveData.result == 1 ? true : false, receiveData.msg, ApiType.KTP, request, "新增考勤接口");
            mag.ResponseData = receiveData;
            return mag;
        }
    }
}
