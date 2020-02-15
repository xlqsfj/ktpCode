using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using KtpAcsMiddleware.Domain.Base;

namespace KtpAcsMiddleware
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            DependencyConfig.Configure();
            DataObjectMapConfig.Configure();
            //ObjectMapConfig.Configure();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}