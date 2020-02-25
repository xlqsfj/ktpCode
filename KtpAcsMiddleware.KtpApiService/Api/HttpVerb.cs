using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.Api
{
    public enum HttpVerb
    {
        GET= Method.GET, //method 常用的就这几样，当然你也可以添加其他的 get：获取 post：修改 put：写入 delete：删除 
        POST = Method.POST,
        PUT,
        DELETE
    }
}
