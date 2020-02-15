using System.Web.Mvc;
using Autofac;
using Autofac.Features.ResolveAnything;
using Autofac.Integration.Mvc;
using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.Domain.Base;

namespace KtpAcsMiddleware
{
    public class DependencyConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
            builder.RegisterModule(new DataModule());
            builder.RegisterModule(new ServiceModule());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}