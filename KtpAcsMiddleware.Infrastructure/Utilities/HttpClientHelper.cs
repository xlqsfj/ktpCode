using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace KtpAcsMiddleware.Infrastructure.Utilities
{
    public class HttpClientHelper
    {
        /// <summary>
        ///     GET请求
        /// </summary>
        public static string Get(string url)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = httpClient.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var apiResult = response.Content.ReadAsStringAsync().Result;
                    return apiResult;
                }
                LogHelper.ExceptionLog($"url={url},response={response}");
                throw new Exception("远程接口调用错误,返回了失败的状态值。");
            }
        }
        /// <summary>
        /// Post请求
        /// </summary>
        public static string Post(string url, string param)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(param, Encoding.UTF8, "application/x-www-form-urlencoded");
                var response = httpClient.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    var apiResult = response.Content.ReadAsStringAsync().Result;
                    return apiResult;
                }
                LogHelper.ExceptionLog($"url={url},response={response}");
                throw new Exception("远程接口调用错误,返回了失败的状态值。");
            }
        }
    }
}