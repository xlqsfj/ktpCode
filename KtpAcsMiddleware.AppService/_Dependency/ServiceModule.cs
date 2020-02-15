using Autofac;
using KtpAcsMiddleware.AppService.FaceRecognition;
using KtpAcsMiddleware.AppService.FileMaps;
using KtpAcsMiddleware.AppService.KtpLibrary;
using KtpAcsMiddleware.AppService.Organizations;
using KtpAcsMiddleware.AppService.ServiceAuths;
using KtpAcsMiddleware.AppService.ServiceDevice;
using KtpAcsMiddleware.AppService.ServiceWorkers;
using KtpAcsMiddleware.AppService.TeamWorkers;
using KtpAcsMiddleware.AppService.WorkerAuths;

namespace KtpAcsMiddleware.AppService._Dependency
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FileMapService>().As<IFileMapService>();
            builder.RegisterType<OrgUserService>().As<IOrgUserService>();
            builder.RegisterType<WorkerQueryService>().As<IWorkerQueryService>();
            builder.RegisterType<WorkerCommandService>().As<IWorkerCommandService>();
            builder.RegisterType<TeamService>().As<ITeamService>();
            builder.RegisterType<FaceDeviceService>().As<IFaceDeviceService>();
            builder.RegisterType<FaceDeviceWorkerService>().As<IFaceDeviceWorkerService>();
            builder.RegisterType<FaceDeviceWorkerApiService>().As<IFaceDeviceWorkerApiService>();
            builder.RegisterType<FaceAuthService>().As<IFaceAuthService>();
            builder.RegisterType<WorkerIdentityService>().As<IWorkerIdentityService>();
            builder.RegisterType<WorkerSyncService>().As<IWorkerSyncService>();
            builder.RegisterType<TeamSyncService>().As<ITeamSyncService>();
            builder.RegisterType<AuthenticationSyncService>().As<IAuthenticationSyncService>();
            builder.RegisterType<FaceWorkerDeletedService>().As<IFaceWorkerDeletedService>();
            builder.RegisterType<WorkerAuthService>().As<IWorkerAuthService>();
            builder.RegisterType<WorkerService>().As<IWorkerService>();
            builder.RegisterType<ServiceDeviceFaceWorker>().As<IServiceDeviceFaceWorker>();
            builder.RegisterType<ServiceAuthsWorker>().As<IServiceAuthsWorker>();
        }
    }
}