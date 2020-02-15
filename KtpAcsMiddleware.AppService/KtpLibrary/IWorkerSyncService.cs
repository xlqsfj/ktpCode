using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Infrastructure.Search.Paging;

namespace KtpAcsMiddleware.AppService.KtpLibrary
{
    public interface IWorkerSyncService
    {
        PagedResult<WorkerSyncPagedDto> GetPaged(
            int pageIndex, int pageSize, string keywords, string teamId, KtpSyncState? state);

        void ResetSyncState(string workerSyncId);
    }
}