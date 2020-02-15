using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace KtpAcsMiddleware.Infrastructure.Utilities
{
    /// <summary>
    ///     json格式数据操作帮助
    /// </summary>
    public class JsonHelper
    {
        public static string GetJsonString(string value, string key)
        {
            try
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(key))
                {
                    return null;
                }
                value = HttpUtility.HtmlDecode(value);
                return JObject.Parse(value)[key].ToString();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                return null;
            }
        }

        public static string[] GetJsonStrings(string value, string arrayKey, string key)
        {
            try
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(arrayKey) || string.IsNullOrEmpty(key))
                {
                    return null;
                }
                IList<string> result = new List<string>();
                var arrayJson = JObject.Parse(value)[arrayKey].ToString();
                var objects = JArray.Parse(arrayJson);
                foreach (var objectStr in objects)
                {
                    result.Add(((JObject) objectStr)[key].ToString());
                }
                return result.ToArray();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                return null;
            }
        }

        public static string[] GetArrayJsonStrings(string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                {
                    return null;
                }
                IList<string> result = new List<string>();
                var objects = JArray.Parse(value);
                foreach (var objectStr in objects)
                {
                    result.Add(objectStr.ToString());
                }
                return result.ToArray();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                return null;
            }
        }
    }
}