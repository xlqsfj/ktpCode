using KS.Resting;
using KtpAcsMiddleware.KtpApiService.Api;
using KtpAcsMiddleware.KtpApiService.PanelApi.PanelMage;
using KtpAcsMiddleware.KtpApiService.PanelApiCd;
using KtpAcsMiddleware.KtpApiService.PanelApiCd.CdModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.PanelApiCd
{

    [Description("闸门面板人员时间截止接口")]
    public class PanelDateBeginPersonApi : ApiBaseForm<Send, CdResult>
    {
      

        public PanelDateBeginPersonApi()
          : base()
        {


            base.API = "/person/permissionsCreate";
            base.MethodType = Method.POST;
            base.ServiceName = ApiType.Panel;

        }

        /// <summary>
        /// 请求的方法
        /// </summary>
        /// <returns>传输的参数</returns>
        protected override Send FetchDataToPush()
        {
            //PanelCreateSend send = base.RequestParam;

            //List<PanelUserInfo> infos = PanelBaseCd.GetPersonInfo(this.PanelIp, Convert.ToInt32(send.person.id));
            //if (infos != null)
            //    base.API = "/person/update";
            return base.RequestParam;
        }

        /// <summary>
        /// 返回信息方法
        /// </summary>
        /// <param name="request">请求的参数</param>
        /// <param name="receiveData">返回的参数</param>
        /// <returns></returns>
        protected override PushSummary OnPushSuccess(RichRestRequest request, CdResult receiveData)
        {
            PushSummary mag = new PushSummary(receiveData.success, receiveData.msg, ApiType.Panel, request, "闸门人员权限设置接口");
            mag.ResponseData = receiveData;
            return mag;
        }
    }
}

