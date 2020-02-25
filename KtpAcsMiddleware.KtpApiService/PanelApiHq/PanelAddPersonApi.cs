using KS.Resting;
using KtpAcsMiddleware.KtpApiService.Api;
using KtpAcsMiddleware.KtpApiService.PanelApiHq.HqModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.PanelApiHq
{
    public class PanelAddPersonApi : ApiBase<PanelPersonSend, HqResult>
    {

        public PanelAddPersonApi()
     : base()
        {


            base.API = "/action/AddPerson";
            base.MethodType = Method.POST;
            base.ServiceName = ApiType.PanelHq;

        }

        /// <summary>
        /// 请求的方法
        /// </summary>
        /// <returns>传输的参数</returns>
        protected override PanelPersonSend FetchDataToPush()
        {
            PanelPersonSend send = base.RequestParam;

            try
            {
               Info infos = PanelBaseHq.GetPersonInfo(this.PanelIp, Convert.ToInt32(send.info.CustomizeID));
                if (infos.CustomizeID !=0)
                {
                    send._operator = "EditPerson";
                    base.API = "/action/EditPerson";
                }
            }
            catch (Exception)
            {


            }
            return send;
        }

        /// <summary>
        /// 返回信息方法
        /// </summary>
        /// <param name="request">请求的参数</param>
        /// <param name="receiveData">返回的参数</param>
        /// <returns></returns>
        protected override PushSummary OnPushSuccess(RichRestRequest request, HqResult receiveData)
        {
            PanelPersonSend send = base.RequestParam;
            if (send._operator == "EditPerson")
            {
                switch (receiveData.code)
                {

                    case 461:
                        receiveData.info.Detail = "未知错误";
                        break;
                    case 479:
                        receiveData.info.Detail = "获取图片,连接服务错误";
                        break;
                    case 475:
                        receiveData.info.Detail = "人员已存在";
                        break;
                    case 477:
                        receiveData.info.Detail = "未检测到人脸";
                        break;
                    case 468:
                        receiveData.info.Detail = "图片base64编码错误";
                        break;
                    case 480:
                        receiveData.info.Detail = "获取图片数据太小";
                        break;
                }

            }
            else
            {
               

                switch (receiveData.code)
                {

                    case 461:
                        receiveData.info.Detail = "未知错误";
                        break;
                    case 464:
                        receiveData.info.Detail = "图片信息错误";
                        break;
                    case 471:
                        receiveData.info.Detail = "人员已存在";
                        break;
                    case 473:
                        receiveData.info.Detail = "未检测到人脸";
                        break;
                    case 474:
                        receiveData.info.Detail = "图片base64编码错误";
                        break;
                    case 477:
                        receiveData.info.Detail = "获取图片数据太小";
                        break;
                }
            }
            PushSummary mag = new PushSummary(receiveData.info.Result == "Fail" ? false : true, receiveData.info.Detail, ApiType.Panel, request, "闸门创建人员接口");
            mag.ResponseData = receiveData;
            return mag;
        }
    }
}
