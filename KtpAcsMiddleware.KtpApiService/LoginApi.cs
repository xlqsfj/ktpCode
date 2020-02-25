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

namespace KtpAcsMiddleware.KtpApiService
{
    /// <summary>
    /// 请求后台登录验证
    /// </summary>
    [Description("云端登录接口")]
    public class LoginApi : ApiBase<dynamic, LoginResult>
    {

        public LoginApi()
          : base()
        {

            base.API = "/auth/login";
            base.ServiceName = ApiType.KTP;
            base.MethodType = Method.POST;
        }

        /// <summary>
        /// 请求的方法
        /// </summary>
        /// <returns>传输的参数</returns>
        protected override dynamic FetchDataToPush()
        {


            return base.RequestParam;
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        /// <param name="request"></param>
        /// <param name="errorSummary"></param>
        protected override void OnPushFailed(RichRestRequest request, string errorSummary)
        {



        }
        /// <summary>
        /// 返回信息方法
        /// </summary>
        /// <param name="request">请求的参数</param>
        /// <param name="receiveData">返回的参数</param>
        /// <returns></returns>
        protected override PushSummary OnPushSuccess(RichRestRequest request, LoginResult receiveData)
        {
            PushSummary mag = new PushSummary(receiveData.success, receiveData.msg, ApiType.KTP, request, "登录接口");
            if (mag.Success)
            {

                ConfigHelper._KtpLoginToken = receiveData.data.token;
                ConfigHelper._KtpLoginProjectId = receiveData.data.proId;
                ConfigHelper.KtpLoginProjectName = receiveData.data.proName;

            }
            mag.ResponseData = receiveData;
            return mag;
        }
    }
}
