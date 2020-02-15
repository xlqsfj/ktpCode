
using Autofac;
using Autofac.Features.ResolveAnything;
using KtpAcsMiddleware.AppService.FaceRecognition;
using KtpAcsMiddleware.AppService.FileMaps;
using KtpAcsMiddleware.AppService.KtpLibrary;
using KtpAcsMiddleware.AppService.Organizations;
using KtpAcsMiddleware.AppService.ServiceAuths;
using KtpAcsMiddleware.AppService.ServiceDevice;
using KtpAcsMiddleware.AppService.ServiceWorkers;
using KtpAcsMiddleware.AppService.TeamWorkers;
using KtpAcsMiddleware.AppService.WorkerAuths;
using KtpAcsMiddleware.Domain.Base;

namespace KtpAcsMiddleware.AppService._Dependency
{
    public class ServiceFactory
    {
        static ServiceFactory()
        {
            DataObjectMapConfig.Configure();
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
            containerBuilder.RegisterModule(new DataModule());
            containerBuilder.RegisterModule(new ServiceModule());
            using (var container = containerBuilder.Build())
            {
                FileMapService = container.Resolve<IFileMapService>();
                OrgUserService = container.Resolve<IOrgUserService>();
                TeamService = container.Resolve<ITeamService>();
                WorkerCommandService = container.Resolve<IWorkerCommandService>();
                WorkerQueryService = container.Resolve<IWorkerQueryService>();
                WorkerSyncService = container.Resolve<IWorkerSyncService>();
                TeamSyncService = container.Resolve<ITeamSyncService>();
                AuthenticationSyncService = container.Resolve<IAuthenticationSyncService>();
                FaceDeviceService = container.Resolve<IFaceDeviceService>();
                FaceDeviceWorkerService = container.Resolve<IFaceDeviceWorkerService>();
                FaceDeviceWorkerApiService = container.Resolve<IFaceDeviceWorkerApiService>();
                FaceWorkerDeletedService = container.Resolve<IFaceWorkerDeletedService>();
                WorkerAuthService = container.Resolve<IWorkerAuthService>();
                WorkerService = container.Resolve<IWorkerService>();
                FaceWorkerServiceDevice = container.Resolve<IServiceDeviceFaceWorker>();
                WorkerAuthsServiceAuths = container.Resolve<IServiceAuthsWorker>();
            }
        }

        public static IFileMapService FileMapService { get; }
        public static IOrgUserService OrgUserService { get; }
        public static ITeamService TeamService { get; }
        public static IWorkerCommandService WorkerCommandService { get; }
        public static IWorkerQueryService WorkerQueryService { get; }
        public static IWorkerSyncService WorkerSyncService { get; }
        public static ITeamSyncService TeamSyncService { get; }
        public static IAuthenticationSyncService AuthenticationSyncService { get; }
        public static IFaceDeviceService FaceDeviceService { get; }
        public static IFaceDeviceWorkerService FaceDeviceWorkerService { get; }
        public static IFaceDeviceWorkerApiService FaceDeviceWorkerApiService { get; }
        public static IFaceWorkerDeletedService FaceWorkerDeletedService { get; }
        public static IWorkerAuthService WorkerAuthService { get; }
        public static IWorkerService WorkerService { get; }
        public static IServiceDeviceFaceWorker FaceWorkerServiceDevice { get; }
        public static IServiceAuthsWorker WorkerAuthsServiceAuths { get; }

    }
}