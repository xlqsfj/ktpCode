using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace KtpAcsMiddleware.Infrastructure.Serialization
{
    public static class JsonSerializationExtension
    {
        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public static string ToJson<T>(this T toSerialize)
        {
            return JsonConvert.SerializeObject(toSerialize);
        }

        public static string ToJson<T>(this T toSerialize, bool isSerializerSettings)
        {
            if (isSerializerSettings)
            {
                return JsonConvert.SerializeObject(toSerialize, JsonSerializerSettings);
            }
            return JsonConvert.SerializeObject(toSerialize);
        }

        public static T FromJson<T>(this T fromSerialize, string json)
        {
            //example:var members = new List<MemberDto>().FromJson(membersStr.ToHtmlDecode());
            return JsonConvert.DeserializeObject<T>(HttpUtility.HtmlDecode(json), JsonSerializerSettings);
        }

        //public static T FromJson<T>(this T fromSerialize, string json, bool isSerializerSettings)
        //{
        //    if (isSerializerSettings)
        //    {
        //        return JsonConvert.DeserializeObject<T>(HttpUtility.HtmlDecode(json), JsonSerializerSettings);
        //    }
        //    return JsonConvert.DeserializeObject<T>(HttpUtility.HtmlDecode(json));
        //}

        public static string ToHtmlDecode(this string s)
        {
            return HttpUtility.HtmlDecode(s);
        }
    }
}