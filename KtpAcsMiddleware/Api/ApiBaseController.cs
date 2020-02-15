using System.Web.Mvc;
using KtpAcsMiddleware.Infrastructure.Serialization;

namespace KtpAcsMiddleware.Api
{
    public class ApiBaseController : Controller
    {
        protected string Ok200Success(object data = null)
        {
            if (data == null)
            {
                return new
                {
                    code = 200,
                    msg = "success"
                }.ToJson();
            }
            return new
            {
                code = 200,
                data,
                msg = "success"
            }.ToJson();
        }

        protected string OkFail(object data = null)
        {
            if (data == null)
            {
                return new
                {
                    code = 1,
                    msg = "fail"
                }.ToJson();
            }
            return new
            {
                code = 1,
                data,
                msg = "fail"
            }.ToJson();
        }
    }
}