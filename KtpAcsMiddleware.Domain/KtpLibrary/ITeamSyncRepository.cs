using System.Collections.Generic;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Search.Paging;

namespace KtpAcsMiddleware.Domain.KtpLibrary
{
    public interface ITeamSyncRepository
    {
        TeamSync FirstOrDefault(string id);
        TeamSync FindByThirdPartyId(int thirdPartyId);
        IList<TeamSync> FindAll();
        PagedResult<Team> FindPaged(SearchCriteria<Team> searchCriteria);
        void Add(TeamSync dto);
        void Modify(string id, TeamSync dto);
        void ModifyState(string id, KtpSyncState status);
    }
}