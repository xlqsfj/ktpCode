using AutoMapper;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.Dto;

namespace KtpAcsMiddleware.Domain.Base
{
    public static class DataObjectMapConfig
    {
        public static void Configure()
        {
            //因多次配置而出现异常
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                WorkerMapConfig(cfg);
                ApiFaceWorkerUnsyncMapConfig(cfg);
            });
        }

        private static void WorkerMapConfig(IMapperConfigurationExpression cfg)
        {
            //左侧的类型是源类型(s)，右侧的类型是目标类型(t)
            cfg.CreateMap<WorkerSync, WorkerSyncDto>();
            cfg.CreateMap<WorkerSyncDto, WorkerSync>();
            cfg.CreateMap<WorkerIdentity, WorkerIdentityDto>();
            cfg.CreateMap<WorkerIdentityDto, WorkerIdentity>();
            cfg.CreateMap<Worker, WorkerDto>()
                .ForMember(t => t.Identity, opt => opt.MapFrom(s => Mapper.Map<WorkerIdentityDto>(s.WorkerIdentity)))
                .ForMember(t => t.Sync, opt => opt.MapFrom(s => Mapper.Map<WorkerSyncDto>(s.WorkerSync)));
            cfg.CreateMap<WorkerDto, Worker>()
                .ForMember(t => t.WorkerIdentity, opt => opt.MapFrom(s => Mapper.Map<WorkerIdentity>(s.Identity)))
                .ForMember(t => t.WorkerSync, opt => opt.MapFrom(s => Mapper.Map<WorkerSync>(s.Sync)));
        }

        private static void ApiFaceWorkerUnsyncMapConfig(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<FaceDeviceWorker, ApiFaceWorkerUnsyncDto>()
                .ForMember(t => t.Worker, opt => opt.MapFrom(s => Mapper.Map<WorkerDto>(s.Worker)))
                .ForMember(t => t.WorkerIdentity,
                    opt => opt.MapFrom(s => Mapper.Map<WorkerIdentityDto>(s.Worker.WorkerIdentity)));
        }
    }
}