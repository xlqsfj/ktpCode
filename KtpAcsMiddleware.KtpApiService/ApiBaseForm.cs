using KS.Resting;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Api;
using KtpAcsMiddleware.KtpApiService.PanelApi;
using KtpAcsMiddleware.KtpApiService.PanelApi.PanelMage;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Extensions.MonoHttp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService
{
    public abstract class ApiBaseForm<TSend, TReceive> : IMulePusher where TSend : class where TReceive : new()
    {
        private MuleRestClientBehavior _behavior;
        public ApiBaseForm()
        {

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
                    _panelIp = value;
                s_rootUrl = GetPanelUrl();


            }
        }

        /// <summary>
        /// 面板的ip号
        /// </summary>
        /// <returns></returns>
        public string GetPanelUrl()
        {

            return $"http://{_panelIp}{panelUrl}";

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
        private string panelUrl = ":8090";
        protected virtual RichRestClient CreateRestClient()
        {
            RichRestClient client = new RichRestClient(RootUrl);
            //client.Behaviors.Add(_behavior);
            //client.Behaviors.Add(new LogRestClientBehavior());
            return client;
        }



        public PushSummary PushForm()
        {
            return InternalPushForm();
        }

        /// <summary>
        /// 用form表单提交
        /// </summary>
        /// <returns></returns>
        private PushSummary InternalPushForm()
        {


            TSend senddata = FetchDataToPush();
            if (senddata == null && (MethodType != Method.GET && MethodType != Method.DELETE))
            {
                return PushSummary.NoDataResult;
            }

            RichRestRequest request = CreateRestRequestForm(senddata);

            List<Parameter> ts = request.Parameters;
            var response = Client.Execute(request);


            Console.WriteLine($"调用{this.ServiceName}传的json参数:" + ts[ts.Count - 2]);


            if (response.ErrorException != null && response.StatusCode != HttpStatusCode.OK)
            {

                return InvokeOnPushFailed(request, $"调用接口失败。" + response.ErrorException.Message);
            }
            if ( response.StatusCode != HttpStatusCode.OK)
            {

                return InvokeOnPushFailed(request, $"调用接口失败。");
            }

            dynamic contentPost = response.Content;
            Console.WriteLine($"调用{this.ServiceName}返回的json参数:" + contentPost);
            bool isDataNull = true;
            PushSummary pushSummary = null;

            if (isDataNull)
            {
                TReceive receiveData = JsonConvert.DeserializeObject<TReceive>(contentPost);
                pushSummary = OnPushSuccess(request, receiveData);

            }


            string summary = string.Empty;


            return pushSummary;
        }


        private RichRestRequest CreateRestRequestForm<T>(T postdata)
        {
            object param = ObjectToForm(postdata);
            if (this.MethodType == Method.GET)
            {
                //Parameter parameter = new Parameter();
                //parameter.Value = param;
                //request.AddParameter(parameter);
                this.API += param;
            }
            var request = new RichRestRequest(API, this.MethodType);
            request.BizName = this.BizEvent;
            request.AddHeader(Constants.SourceName, "KTP")
                   .AddHeader(Constants.TargetName, "Panel3.0");

            if (this.MethodType != Method.GET)
            {

                request.AddParameter("application/x-www-form-urlencoded", param, ParameterType.RequestBody);
            }
       

            return request;
        }

        /// <summary>
        /// 对象转url字符串
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="postdata"></param>
        /// <returns></returns>
        public object ObjectToForm<T>(T postdata)
        {

            PropertyInfo[] propertis = postdata.GetType().GetProperties();
            StringBuilder sb = new StringBuilder();
            if (this.MethodType == Method.GET)
            {
                sb.Append("?");
            }

            foreach (var p in propertis)
            {
                dynamic v = p.GetValue(postdata, null);
                if (v == null)
                    continue;
                var type = v.GetType();
                sb.Append(p.Name);
                sb.Append("=");
                if (type == typeof(string) || type == typeof(int) || type == typeof(bool) || type == typeof(double) || type == typeof(decimal))
                {//数据列
                    sb.Append(HttpUtility.UrlEncode(v.ToString()));
                }
                else
                {
                    //对象转json
                    string json = JsonConvert.SerializeObject(v);
                    sb.Append(HttpUtility.UrlEncode(json));
                }
                sb.Append("&");
            }
            sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
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

        public PushSummary Push()
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
