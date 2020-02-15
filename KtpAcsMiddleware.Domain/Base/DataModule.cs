using Autofac;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.DomainAuths;
using KtpAcsMiddleware.Domain.DomainDevice;
using KtpAcsMiddleware.Domain.DomainWorkers;
using KtpAcsMiddleware.Domain.FaceRecognition;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Domain.Organizations;
using KtpAcsMiddleware.Domain.Teams;
using KtpAcsMiddleware.Domain.WorkerAuths;
using KtpAcsMiddleware.Domain.Workers;

namespace KtpAcsMiddleware.Domain.Base
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<FileMapRepository>().As<IFileMapRepository>();
            builder.RegisterType<OrgUserRepository>().As<IOrgUserRepository>();
            builder.RegisterType<TeamRepository>().As<ITeamRepository>();
            builder.RegisterType<WorkerQueryRepository>().As<IWorkerQueryRepository>();
            builder.RegisterType<WorkerCommandRepository>().As<IWorkerCommandRepository>();
            builder.RegisterType<FaceDeviceRepository>().As<IFaceDeviceRepository>();
            builder.RegisterType<FaceDeviceWorkerRepository>().As<IFaceDeviceWorkerRepository>();
            builder.RegisterType<FaceDeviceWorkerApiRepository>().As<IFaceDeviceWorkerApiRepository>();
            builder.RegisterType<FaceAuthRepository>().As<IFaceAuthRepository>();
            builder.RegisterType<TeamWorkTypeRepository>().As<ITeamWorkTypeRepository>();
            builder.RegisterType<WorkerIdentityRepository>().As<IWorkerIdentityRepository>();
            builder.RegisterType<TeamSyncRepository>().As<ITeamSyncRepository>();
            builder.RegisterType<WorkerSyncRepository>().As<IWorkerSyncRepository>();
            builder.RegisterType<AuthenticationSyncRepository>().As<IAuthenticationSyncRepository>();
            builder.RegisterType<DeletedFaceWorkerRepository>().As<IDeletedFaceWorkerRepository>();
            builder.RegisterType<WorkerAuthRepository>().As<IWorkerAuthRepository>();
            builder.RegisterType<DomainDeviceRepository>().As<IDomainDeviceRepository>();
            //工人
            builder.RegisterType<DomainWorkersRepository>().As<IDomainWorkersRepository>();

            builder.RegisterType<DomainAuthsRepository>().As<IDomainAuthsRepository>();
        }
    }
}