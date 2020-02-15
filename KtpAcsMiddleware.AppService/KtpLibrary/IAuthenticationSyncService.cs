using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Infrastructure.Search.Paging;

namespace KtpAcsMiddleware.AppService.KtpLibrary
{
    public interface IAuthenticationSyncService
    {
        PagedResult<AuthenticationSyncPagedDto> GetPaged(
            int pageIndex, int pageSize, string keywords, string deviceCode, KtpSyncState? state);

        void ResetSyncState(string authenticationSyncId);
    }
}