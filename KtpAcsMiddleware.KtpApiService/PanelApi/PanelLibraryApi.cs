using KS.Resting;
using KtpAcsMiddleware.KtpApiService.Api;
using KtpAcsMiddleware.KtpApiService.PanelApi.PanelMage;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.PanelApi
{

    [Description("闸门面板库管理接口")]
    public class PanelLibraryApi : ApiBase<PanelLibrarySend, PanelResult>
    {
        public PanelLibrarySend libraryRequest;

        public PanelLibraryApi()
          : base()
        {


            base.API = "/PeopleLibraries/BasicInfo";
            base.MethodType = Method.GET;
            base.ServiceName = ApiType.Panel;

        }

        /// <summary>
        /// 请求的方法
        /// </summary>
        /// <returns>传输的参数</returns>
        protected override PanelLibrarySend FetchDataToPush()
        {

            return base.RequestParam;
        }

        /// <summary>
        /// 返回信息方法
        /// </summary>
        /// <param name="request">请求的参数</param>
        /// <param name="receiveData">返回的参数</param>
        /// <returns></returns>
        protected override PushSummary OnPushSuccess(RichRestRequest request, PanelResult receiveData)
        {
            PushSummary mag = new PushSummary(receiveData.Response.StatusCode == 0 ? true : false, receiveData.Response.StatusString, ApiType.Panel, request, "闸门面板库接口");
            mag.ResponseData = receiveData;
            return mag;
        }
    }
}

