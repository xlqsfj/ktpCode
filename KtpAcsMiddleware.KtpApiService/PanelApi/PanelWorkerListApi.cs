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

    [Description("闸门面板人员列表接口")]
    public class PanelWorkerListApi : ApiBase<dynamic, PanelResult>
    {
        public PanelWorkerSend PanelWorkerSend;

        public PanelWorkerListApi()
          : base()
        {


            base.API = "/PeopleLibraries/3/UpdateTime";
            base.MethodType = Method.POST;
            base.ServiceName = ApiType.Panel;

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
        /// 返回信息方法
        /// </summary>
        /// <param name="request">请求的参数</param>
        /// <param name="receiveData">返回的参数</param>
        /// <returns></returns>
        protected override PushSummary OnPushSuccess(RichRestRequest request, PanelResult receiveData)
        {
             PushSummary mag = new PushSummary(receiveData.Response.StatusCode==0?true:false, receiveData.Response.StatusString, ApiType.Panel, request, "面板人员列表接口");

            if (receiveData.Response.Data != null)
            {
                List<Personlist> personlist = receiveData.Response.Data.PersonList;
                mag.ResponseData = personlist;

            }
          
           
            return mag;
        }
    }
}
