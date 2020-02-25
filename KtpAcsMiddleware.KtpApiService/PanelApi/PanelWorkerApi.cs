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
    public class PanelWorkerApi : ApiBase<PanelWorkerSend, PanelResult>
    {
        public PanelWorkerSend PanelWorkerSend;

        public PanelWorkerApi()
          : base()
        {


            base.API = "/PeopleLibraries/3/People";
            base.MethodType = Method.POST;
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
        protected override PushSummary OnPushSuccess(RichRestRequest request, PanelResult receiveData)
        {
            string resultCode = "1";
            if (receiveData.Response.Data != null)
            {
                Personlist personlist = receiveData.Response.Data.PersonList[0];
                if(personlist !=null)
                resultCode = personlist.FaceList[0].ResultCode;

            }
            PushSummary mag = new PushSummary(resultCode == "0" ? true : false, resultCode, ApiType.Panel, request, "人员接口");

            mag.ResponseData = receiveData;
            return mag;
        }
    }
}
