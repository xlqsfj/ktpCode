using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.Api
{
    public class RestClient
    {
        public string EndPoint { get; set; } //请求的url地址 eg： http://215.23.12.45:8080/order/order_id=1&isdel=0 
        public HttpVerb Method { get; set; } //请求的方法 
        public string ContentType { get; set; } //格式类型：我用的是application/json，具体使用什么，看需求吧 
        public string PostData { get; set; } //传送的数据，当然了我使用的是json字符串 
        public RestClient()
        {
            EndPoint = "";
            Method = HttpVerb.GET;
            ContentType = "text/xml";
            PostData = "";
        }
        public RestClient(string endpoint)
        {
            EndPoint = endpoint;
            Method = HttpVerb.GET;
            ContentType = "text/xml";
            PostData = "";
        }
        public RestClient(string endpoint, HttpVerb method)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = "text/xml";
            PostData = "";
        }
        public RestClient(string endpoint, HttpVerb method, string postData)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = "text/xml";
            PostData = postData;
        }

        public string MakeRequest()
        {
            return MakeRequest("");
        }
        public string MakeRequest(string parameters)
        {
            // Uri uri = new Uri("http://localhost:8087/water-datacenter/dataTheme/historyData/historyData/getHisDataByIdsName?ids=1&startTime=1989-12-31 00:00:00&endTime=2000-12-31 00:00:00&rtName=yyzcb&rtName=zfgxsf");
            // var request = (HttpWebRequest)WebRequest.Create(uri);


            var request = (HttpWebRequest)WebRequest.Create(EndPoint + parameters);
            request.Method = Method.ToString();
            request.ContentLength = 0;
            request.ContentType = ContentType;
            if (!string.IsNullOrEmpty(PostData) && Method == HttpVerb.POST)//如果传送的数据不为空，并且方法是post 
            {
                var encoding = new UTF8Encoding();
                var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(PostData);//编码方式按自己需求进行更改，我在项目中使用的是UTF-8 
                request.ContentLength = bytes.Length;
                using (var writeStream = request.GetRequestStream())
                {
                    writeStream.Write(bytes, 0, bytes.Length);
                }
            }
            if (!string.IsNullOrEmpty(PostData) && Method == HttpVerb.PUT)//如果传送的数据不为空，并且方法是put 
            {
                var encoding = new UTF8Encoding();
                var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(PostData);//编码方式按自己需求进行更改，我在项目中使用的是UTF-8 
                request.ContentLength = bytes.Length;
                using (var writeStream = request.GetRequestStream())
                {
                    writeStream.Write(bytes, 0, bytes.Length);
                }
            }
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var responseValue = string.Empty;
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    var message = String.Format("Request failed. Received HTTP {0}", response.StatusCode);
                    throw new ApplicationException(message);
                }
                // grab the response 
                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                        }
                }
                return responseValue;
            }
        }
    } // class 
}

