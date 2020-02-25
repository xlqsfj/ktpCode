using System;
using System.Net.Http;
using System.Net.Http.Headers;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.KtpApiService.Base
{
    /// <summary>
    ///     开太平接口认证(token java)
    /// </summary>
    public class KtpAuthHelper
    {
        /// <summary>
        ///     获取班组Api模板
        /// </summary>
        private static string GetTokenApi
        {
            get
            {
                return
                    $"{ConfigHelper.KtpApiBaseUrl}auth/app/token/login?grant_type=app_mobile&app_mobile=APP_SMS@eyJ1c2VySW1lYSI6IjMyNjUyMSIsInBob25lIjoiMTM4MTIzNDU2NzgiLCJ2ZXJzaW9uIjoidjEuMCJ9";
            }
        }

        public static string GetToken()
        {
            return GetToken(ConfigHelper.KtpApiAuthorization);
        }

        private static string GetToken(string authorization)
        {
            if (string.IsNullOrEmpty(authorization))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNull(authorization));
            }
            if (!authorization.Contains("Basic"))
            {
                //格式示例：Basic YXBwOk5Ja2s2OGVfM0FEYVM=
                authorization = $"Basic {authorization}";
            }
            var apiResult = string.Empty;
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Add("Authorization", authorization);
                    //post参数示例,use:var response = httpClient.PostAsync(GetTokenApi, content).Result;
                    //var content = new FormUrlEncodedContent(new Dictionary<string, string>()
                    //{
                    //    {"ak", "65fc7ca4fc441d26f71bf3d691b278c2"},
                    //    {"deviceId", "537eb34be4b022b7fbe19471"}
                    //});
                    var response = httpClient.PostAsync(GetTokenApi, null).Result;
                    //var statusCode = response.StatusCode.ToString();
                    if (response.IsSuccessStatusCode)
                    {
                        apiResult = response.Content.ReadAsStringAsync().Result;
                        var token = JsonHelper.GetJsonString(apiResult, "access_token");
                        if (string.IsNullOrEmpty(token))
                        {
                            throw new NotFoundException(ExMessage.NotFound(nameof(token)));
                        }
                        return token;
                    }
                    throw new Exception(ExMessage.NotFound("response.IsSuccessStatusCod equals false"));
                }
            }
            catch
            {
                LogHelper.ExceptionLog($"authorization={authorization},apiResult={apiResult}");
                throw;
            }
        }
    }
}