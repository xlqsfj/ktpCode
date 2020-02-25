using KS.Resting;
using KtpAcsAotoUpdate;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Api;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Threading;

namespace KtpAcsMiddleware.KtpApiService
{
    /// <summary>
    /// 表示一次推送的推送结果（并非数据接收方的返回结果）
    /// </summary>
    public class PushSummary
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="success"></param>
        /// <param name="message"></param>
        public PushSummary(bool success, string message)
        {
            this.Message = "";
            this.Success = success;
            this.Message = message;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="success"></param>
        /// <param name="message"></param>
        public PushSummary(bool success, string message, ApiType appType, RichRestRequest request, string apiName)
        {
            this.Message = "";
            this.Success = success;
            List<Parameter> ts = request.Parameters;
            this.RequestParam = $"传的json参数:" + request.Parameters[ts.Count - 2];

            if (appType == ApiType.KTP && success == false)
            {
                this.Message = "调用云端接口失败。错误信息：" + message;
                LogHelper.Info(ApiType.KTP.ToEnumText() + apiName);
                LogHelper.EntryLog(this.RequestParam, "url:" + request.Resource);
                LogHelper.ExceptionLog(this.Message);

                if (message == "您的账号已在其他地方登录,请重新登录")
                {

                    throw new Exception("您的账号已在其他地方登录,请重新登录");


                }

            }
            else if (appType == ApiType.Panel && success == false)
            {
                this.Message = "调用人脸识别设备接口失败。错误信息：" + message;
                LogHelper.Info(ApiType.Panel.ToEnumText() + apiName);
                LogHelper.EntryLog(this.RequestParam, "url:" + request.Resource);
                LogHelper.ExceptionLog(this.Message);
                // throw new Exception(this.Message);
            }
        }

        /// <summary>
        /// 无数据传输的推送结果
        /// </summary>
        public static PushSummary NoDataResult
        {
            get { return new PushSummary(true, "没有数据要传输。"); }
        }

        public dynamic ResponseData { get; set; }
        /// <summary>
        /// 推送是否成功
        /// </summary>
        public bool Success
        {
            get;
            private set;
        }


        /// <summary>
        /// 
        /// </summary>
        public string Message
        {
            get;
            private set;
        }

        /// <summary>
        /// 请求的参数
        /// </summary>
        public string RequestParam
        {
            get;
            set;
        }



    }
}
