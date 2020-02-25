using KS.Resting;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Api;
using KtpAcsMiddleware.KtpApiService.PanelApi;
using KtpAcsMiddleware.KtpApiService.PanelApi.PanelMage;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService
{
    public abstract class ApiBase<TSend, TReceive> : IMulePusher where TSend : class where TReceive : new()
    {
        private MuleRestClientBehavior _behavior;
        public ApiBase()
        {
            //_logger = Logger.GetLogger("MulePushBillLog");
            //_maxPackageSize = MuleConfigs.MaxPackageSize;
            _behavior = new MuleRestClientBehavior();
            s_rootUrl = ConfigHelper.KtpApiAspBaseUrl;
        }

        /// <summary>
        /// 登录返回的Token
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        ///请求参数
        /// </summary>
        public dynamic RequestParam { get; set; }

        /// <summary>
        /// 如：condition
        /// </summary>
        public string API
        {
            get;
            set;
        }
        private string panelUrl = "/LAPI/V1.0";
        private string _panelIp;
        /// <summary>
        /// 面板的ip号
        /// </summary>
        public string PanelIp
        {
            get { return _panelIp; }
            set
            {
                if (value != "")
                {
                    _panelIp = value;

                }
                s_rootUrl = GetPanelUrl();



            }
        }

        /// <summary>
        /// 面板的ip号
        /// </summary>
        /// <returns></returns>
        public string GetPanelUrl()
        {

            if (ServiceName == ApiType.Panel)
                return $"http://{_panelIp}{panelUrl}";
            else if (ServiceName == ApiType.App)
                return $"{_panelIp}";
            else
                return $"http://{_panelIp}";
        }
        /// <summary>
        /// 对应header里的biz_event
        /// </summary>
        public string BizEvent
        {
            get;
            set;
        }

        /// <summary>
        /// 对应header里的service_name
        /// </summary>
        public ApiType ServiceName
        {
            get;
            set;
        }

        /// <summary>
        /// 请求的类型
        /// </summary>
        public Method MethodType
        {
            get;
            set;
        }

        private int _maxPackageSize;
        /// <summary>
        /// 
        /// </summary>
        public int MaxPackageSize
        {
            get { return _maxPackageSize; }
            set { _maxPackageSize = value; }
        }

        private IRestClient _client;
        /// <summary>
        /// 
        /// </summary>
        public IRestClient Client
        {
            get
            {
                if (_client == null)
                    _client = CreateRestClient();
                return _client;
            }
        }
        public string s_rootUrl;
        /// <summary>
        /// 例如http://10.115.64.194:8089/sap-api/sap/
        /// </summary>
        public string RootUrl
        {
            get { return s_rootUrl; }
            set { s_rootUrl = value; }
        }
        protected virtual RichRestClient CreateRestClient()
        {
            RichRestClient client = new RichRestClient(RootUrl);
            //client.Behaviors.Add(_behavior);
            //client.Behaviors.Add(new LogRestClientBehavior());
            return client;
        }

        /// <summary>
        /// 推送数据（批量）
        /// </summary>
        /// <returns></returns>
        PushSummary IMulePusher.Push()
        {
            return InternalPush();
        }


        private PushSummary InternalPush()
        {


            TSend senddata = FetchDataToPush();
            if (senddata == null && (MethodType != Method.GET && MethodType != Method.POST && MethodType != Method.DELETE))
            {
                return PushSummary.NoDataResult;
            }

            RichRestRequest request = CreateRestRequest(senddata);
            List<Parameter> ts = request.Parameters;
            var response = Client.Execute(request);

            ////if (response.StatusCode != HttpStatusCode.OK)
            ////{
            //  return InvokeOnPushFailed(request, $"调用接口失败。statuscode:{response.StatusCode.ToString()},statusdesc:{response.StatusDescription}");
            ////}
            ///


            Console.WriteLine($"调用{this.ServiceName}传的json参数:" + ts[ts.Count - 2]);


            if (response.ErrorException != null && response.StatusCode != HttpStatusCode.OK)
            {
                //  throw new InvalidOperationException("调用接口失败, 错误信息：" + response.ErrorException.Message);

                return InvokeOnPushFailed(request, $"调用接口失败。" + response.ErrorException.Message);
            }
            //else if (response.Data is IReceiveMessage)
            //{
            //    string message = (response.Data as IReceiveMessage).Message;
            //    if (!string.IsNullOrEmpty(message))
            //    {
            //        return InvokeOnPushFailed(request, "调用接口失败。错误信息：" + message);
            //    }
            //}
            //  IRestResponse responsePost = client.Execute(requestPost);
            dynamic contentPost = response.Content;
            Console.WriteLine($"调用{this.ServiceName}返回的json参数:" + contentPost);
            bool isDataNull = true;
            PushSummary pushSummary = null;
            try
            {
                if (ServiceName == Api.ApiType.Panel)
                {
                    dynamic obj = JsonConvert.DeserializeObject(contentPost) as JObject;
                    if (obj.Response.StatusCode.Value == 1 || obj.Response.StatusCode.Value == 2)
                    {
                        //PResult r = new PResult();
                        //TReceive receiveData = JsonConvert.DeserializeObject<PanelDeleteResult>(contentPost);
                        //pushSummary = OnPushSuccess(request, receiveData);
                        isDataNull = false;
                        return InvokeOnPushFailed(request, $"调用人脸识别设备接口失败。错误信息：接口失败。请重试" + obj.Response.StatusString.Value);
                    }
                }
                if (isDataNull)
                {
                    TReceive receiveData = JsonConvert.DeserializeObject<TReceive>(contentPost);
                    pushSummary = OnPushSuccess(request, receiveData);

                }
            }
            catch (Exception ex)
            {

                throw;
            }
            //  T receiveData1 = (response.Content as IRestResponse<T>).Data;

            string summary = string.Empty;
            try
            {
                //WritePushBillLog(request, receiveData);
                //summary = GetRecordCountSummary(senddata) + GetPushDataSummary(senddata);
            }
            catch (Exception ex)
            {
                summary = "数据推送成功。但生成推送摘要时出错，错误信息：" + ex.Message;
            }
            return pushSummary;
        }

        private RichRestRequest CreateRestRequest<T>(T postdata)
        {
            // Method.POST
            var request = new RichRestRequest(API, this.MethodType);
            request.JsonSerializer = new RestJsonSerializer();
            request.BizName = this.BizEvent;
            request.AddHeader(Constants.SourceName, "KTP")
                   .AddHeader(Constants.TargetName, "Panel3.0");
            if (!string.IsNullOrEmpty(this.Token))
            {//平台加 登录token验证
                request.AddHeader("Authorization", this.Token);

            }
            if (ServiceName == ApiType.PanelHq)
            {//海清接口加 Basic验证
                request.AddHeader("Authorization", $"Basic {FormatHelper.GetUserPwdToBase("admin", "admin")}");

            }
            request.UserState = postdata;
            request.AddJsonBody(postdata);
            return request;
        }

        private PushSummary InvokeOnPushFailed(RichRestRequest request, string errorSummary)
        {

            OnPushFailed(request, errorSummary);
            return new PushSummary(false, errorSummary, this.ServiceName, request, "接口");
        }
        protected abstract PushSummary OnPushSuccess(RichRestRequest request, TReceive receiveData);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="errorSummary"></param>
        protected virtual void OnPushFailed(RichRestRequest request, string errorSummary)
        {

        }
        /// <summary>
        /// 获取要推送的数据，如果没有需要推送的数据，请返回null
        /// </summary>
        /// <returns></returns>
        protected abstract TSend FetchDataToPush();

        public PushSummary PushForm()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        internal class MuleRestClientBehavior : IRestClientBehavior
        {
            public bool ThrowError
            {
                get { return false; }
            }

            public void Executed(IRestResponse response)
            {

            }

            public void Executing(IRestRequest request)
            {
                RichRestRequest richrequest = request as RichRestRequest;
                request
                    .AddHeader(Constants.TransID, richrequest.RequestKey)
                    .AddHeader(Constants.SubmitTime, richrequest.RequestTime.ToString("yyyy-MM-dd HH:mm:ss fff"));
            }
        }
    }
}
