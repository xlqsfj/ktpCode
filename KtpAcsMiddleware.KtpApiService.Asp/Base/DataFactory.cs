using Autofac;
using Autofac.Features.ResolveAnything;
using KtpAcsMiddleware.Domain.Base;
using KtpAcsMiddleware.Domain.DomainAuths;
using KtpAcsMiddleware.Domain.DomainWorkers;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Domain.Teams;
using KtpAcsMiddleware.Domain.Workers;

namespace KtpAcsMiddleware.KtpApiService.Asp.Base
{
    internal class DataFactory
    {
        static DataFactory()
        {
            DataObjectMapConfig.Configure();
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
            containerBuilder.RegisterModule(new DataModule());
            using (var container = containerBuilder.Build())
            {
                TeamWorkTypeRepository = container.Resolve<ITeamWorkTypeRepository>();
                TeamRepository = container.Resolve<ITeamRepository>();
                TeamSyncRepository = container.Resolve<ITeamSyncRepository>();
                FileMapRepository = container.Resolve<IFileMapRepository>();
                WorkerQueryRepository = container.Resolve<IWorkerQueryRepository>();
                WorkerCommandRepository = container.Resolve<IWorkerCommandRepository>();
                WorkerIdentityRepository = container.Resolve<IWorkerIdentityRepository>();
                WorkerSyncRepository = container.Resolve<IWorkerSyncRepository>();
                AuthenticationSyncRepository = container.Resolve<IAuthenticationSyncRepository>();
                DomainAuthsRepository = container.Resolve<IDomainAuthsRepository>();
            }
        }

        internal static ITeamWorkTypeRepository TeamWorkTypeRepository { get; }
        internal static ITeamRepository TeamRepository { get; }
        internal static ITeamSyncRepository TeamSyncRepository { get; }
        internal static IFileMapRepository FileMapRepository { get; }
        internal static IWorkerQueryRepository WorkerQueryRepository { get; }
        internal static IWorkerCommandRepository WorkerCommandRepository { get; }
        internal static IWorkerIdentityRepository WorkerIdentityRepository { get; }
        internal static IWorkerSyncRepository WorkerSyncRepository { get; }
        internal static IAuthenticationSyncRepository AuthenticationSyncRepository { get; }
        /// <summary>
        /// 考勤上传
        /// </summary>
        internal static IDomainAuthsRepository DomainAuthsRepository { get; }
    }
}