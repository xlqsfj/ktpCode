using KS.Resting;
using KtpAcsMiddleware.Infrastructure.Utilities;
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

    [Description("闸门面板照片管理接口")]
    public class PanelFacePersonApi : ApiBaseForm<PanelFaceInfoSend, PanelObjectResult>
    {


        public PanelFacePersonApi()
          : base()
        {
            base.API = "/face/create";
            base.MethodType = Method.POST;
            base.ServiceName = ApiType.Panel;

        }

        /// <summary>
        /// 请求的方法
        /// </summary>
        /// <returns>传输的参数</returns>
        protected override PanelFaceInfoSend FetchDataToPush()
        {
            PanelFaceInfoSend send = base.RequestParam;

            List<PanelUserFaceInfo> infos = PanelBaseCd.GetPersonFaceInfo(this.PanelIp, Convert.ToInt32(send.personId));
            if (infos.Count > 0)
                base.API = "/face/update";
            return base.RequestParam;
        }

        /// <summary>
        /// 返回信息方法
        /// </summary>
        /// <param name="request">请求的参数</param>
        /// <param name="receiveData">返回的参数</param>
        /// <returns></returns>
        protected override PushSummary OnPushSuccess(RichRestRequest request, PanelObjectResult receiveData)
        {
            if (receiveData == null)
            {
                PushSummary mag1 = new PushSummary(false, "", ApiType.Panel, request, "闸门照片管理接口");
                return mag1;
            }
            PanelFaceInfoSend send = base.RequestParam;
            PushSummary mag = new PushSummary(receiveData.success, receiveData.msg, ApiType.Panel, request, "闸门照片管理接口");
            if (!mag.Success)
            {//照片下发失败，删除人员接口

                //List<PanelUserFaceInfo> infos = PanelBaseCd.GetPersonFaceInfo(base.PanelIp, Convert.ToInt32(send.personId));
                //if (infos == null)
                //{
                IMulePusher panelDeleteApi = new PanelDeletePersonApi()
                { PanelIp = base.PanelIp, RequestParam = new Send { id = send.personId } };

                PushSummary pushSummarySet = panelDeleteApi.PushForm();
                // }
            }
            mag.ResponseData = receiveData;
            return mag;
        }
    }
}

