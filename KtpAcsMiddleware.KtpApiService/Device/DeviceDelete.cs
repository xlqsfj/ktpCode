using KS.Resting;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Api;
using KtpAcsMiddleware.KtpApiService.PanelApi;
using KtpAcsMiddleware.KtpApiService.PanelApi.PanelMage;
using KtpAcsMiddleware.KtpApiService.PanelApiCd;
using KtpAcsMiddleware.KtpApiService.PanelApiHq;
using KtpAcsMiddleware.KtpApiService.PanelApiHq.HqModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.Device
{
    /// <summary>
    /// 设备删除接口
    /// </summary>
    public class DeviceDelete : ApiBase<dynamic, DeviceDeleteResult>
    {



        public DeviceDelete()
          : base()
        {
            base.API = "/project/deletedevice";
            base.ServiceName = ApiType.KTP;
            base.MethodType = Method.POST;
            base.Token = ConfigHelper.KtpLoginToken;
        }


        protected override dynamic FetchDataToPush()
        {
            // var  param=new { projectId=ConfigHelper.ProjectId.ToString() };

            return base.RequestParam;
        }

        protected override void OnPushFailed(RichRestRequest request, string errorSummary)
        {

        }

        protected override PushSummary OnPushSuccess(RichRestRequest request, DeviceDeleteResult receiveData)
        {
            PushSummary mag = new PushSummary(receiveData.success, receiveData.msg, ApiType.KTP, request, "设备删除接口");
            var param = base.RequestParam;
            if (ConfigHelper.PanelApiType == (int)EPanelApiType.chidao)
            {//赤道产品

                IMulePusher panelDeleteApi = new PanelDeletePersonApi()
                { PanelIp = param.GetType().GetProperty("ip").GetValue(param).ToString(), RequestParam = new Send { id = -1 } };

                PushSummary pushSummarySet = panelDeleteApi.PushForm();
            }
            else if (ConfigHelper.PanelApiType == (int)EPanelApiType.haiqing) {

                DeleteSend deleteSend = new DeleteSend()
                {
                    _operator = "SetFactoryDefault",
                    info = new UserDelete()
                    {
                         DefaltPerson=1


                    }
                };
                IMulePusher panelDeleteApi = new PanelHqDeleteAllPersonApi()

                { PanelIp = param.GetType().GetProperty("ip").GetValue(param).ToString(), RequestParam = deleteSend };

                PushSummary pushSummarySet = panelDeleteApi.Push();
            }
            else
            {//宇视产品
                IMulePusher panelDeleteApi = new PanelLibraryDeleteApi() { PanelIp = param.GetType().GetProperty("ip").GetValue(param).ToString() };

                PushSummary pushSummarySet = panelDeleteApi.Push();
            }
            //PanelResult panelDeleteApiR = pushSummarySet.ResponseData;
            //if (!pushSummarySet.Success) {

            //    return pushSummarySet;
            //}
            mag.ResponseData = receiveData;


            return mag;
        }
    }
}

