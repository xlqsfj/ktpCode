using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.Domain.Workers;
using KtpAcsMiddleware.Infrastructure.Search.Paging;

namespace KtpAcsMiddleware.AppService.TeamWorkers
{
    public interface IWorkerQueryService
    {
        TeamWorkerDto Get(string workerId);

        PagedResult<TeamWorkerPagedDto> GetPaged(
            int pageIndex, int pageSize, string teamId, string keywords, WorkerAuthenticationState state);
    }
}