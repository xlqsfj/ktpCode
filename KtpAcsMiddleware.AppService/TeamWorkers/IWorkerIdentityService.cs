using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.Domain.Data;

namespace KtpAcsMiddleware.AppService.TeamWorkers
{
    public interface IWorkerIdentityService
    {
        WorkerIdentity ReaderAdd(IdentitySynDto dto);
        WorkerIdentity Add(WorkerIdentity dto);
    }
}