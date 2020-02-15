using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Infrastructure.Search.Paging;

namespace KtpAcsMiddleware.AppService.KtpLibrary
{
    public interface ITeamSyncService
    {
        PagedResult<TeamSyncPagedDto> GetPaged(
            int pageIndex, int pageSize, string keywords, string workTypeId, KtpSyncState? state);

        void ResetSyncState(string teamSyncId);
    }
}