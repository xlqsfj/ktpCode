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

    [Description("闸门面板人员管理接口")]
    public class PanelWorkerDeleteApi : ApiBase<PanelWorkerSend, PanelDeleteResult>
    {
        public PanelWorkerSend PanelWorkerSend;

        public PanelWorkerDeleteApi()
          : base()
        {


            base.API = "/PeopleLibraries/3/People";
            base.MethodType = Method.DELETE;
            base.ServiceName = ApiType.Panel;

        }

        /// <summary>
        /// 请求的方法
        /// </summary>
        /// <returns>传输的参数</returns>
        protected override PanelWorkerSend FetchDataToPush()
        {

            return base.RequestParam;
        }

        /// <summary>
        /// 返回信息方法
        /// </summary>
        /// <param name="request">请求的参数</param>
        /// <param name="receiveData">返回的参数</param>
        /// <returns></returns>
        protected override PushSummary OnPushSuccess(RichRestRequest request, PanelDeleteResult receiveData)
        {
            PushSummary mag = new PushSummary(receiveData.Response.StatusCode==0?true:false, receiveData.Response.StatusString,ApiType.Panel, request, "人员删除接口");

            return mag;
        }
    }
}
