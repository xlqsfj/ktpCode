using KS.Resting;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Api;
using KtpAcsMiddleware.KtpApiService.Device;
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
using static KtpAcsMiddleware.KtpApiService.PanelApi.PanelWorkerSend;

namespace KtpAcsMiddleware.KtpApiService.TeamWorkers
{
    public class WorkerDelete : ApiBase<WorkerDeleteSend, WorkerDeleteResult>
    {


        public WorkerDelete()
          : base()
        {

            base.API = "/user/deleteProOrganPer";
            base.ServiceName = ApiType.KTP;
            base.MethodType = Method.POST;
            base.Token = ConfigHelper.KtpLoginToken;
        }

        /// <summary>
        /// 请求的方法
        /// </summary>
        /// <returns>传输的参数</returns>
        protected override WorkerDeleteSend FetchDataToPush()
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
        protected override PushSummary OnPushSuccess(RichRestRequest request, WorkerDeleteResult receiveData)
        {
            PushSummary mag = new PushSummary(receiveData.success, receiveData.msg, ApiType.KTP, request, "删除工人接口");
            mag.ResponseData = receiveData;
            WorkerDeleteSend deleteInfo = base.RequestParam;
            if (receiveData.success)
            {


                IMulePusher pusher = new DeviceGet() { RequestParam = new { projectId = ConfigHelper.KtpLoginProjectId } };
                PushSummary push = pusher.Push();
                if (push.Success)
                {

                    List<ContentItem> Device = push.ResponseData;

                    foreach (ContentItem device in Device)
                    {
                        if (!ConfigHelper.MyPing(device.deviceIp))
                        {

                            continue;
                        }

                        if (ConfigHelper.PanelApiType == (int)EPanelApiType.chidao)
                        {//赤道产品

                            IMulePusher panelDeleteApi = new PanelApiCd.PanelDeletePersonApi()
                            { PanelIp = device.deviceIp, RequestParam = new Send { id = FormatHelper.StringToInt(deleteInfo.userId) } };

                            PushSummary pushSummarySet = panelDeleteApi.PushForm();
                        }
                        else if (ConfigHelper.PanelApiType == (int)EPanelApiType.haiqing)
                        {
                            //海清
                            PanelBaseHq.PanelDeleteUser(FormatHelper.StringToInt(deleteInfo.userId), device.deviceIp);
                        }
                        else
                        {//宇视产品

                            IMulePusher PanelLibrarySet = new PanelWorkerDeleteApi() { API = "/PeopleLibraries/3/People/" + deleteInfo.userId + $"?Lastchange={DateTime.Now.Ticks}", MethodType = Method.DELETE, PanelIp = device.deviceIp };

                            PushSummary pushSummary = PanelLibrarySet.Push();
                            PanelDeleteResult rr = pushSummary.ResponseData;
                        }
                    }
                }
            }

            return mag;
        }


    }
}
