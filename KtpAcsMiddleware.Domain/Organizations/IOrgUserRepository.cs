using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Search.Paging;

namespace KtpAcsMiddleware.Domain.Organizations
{
    public interface IOrgUserRepository
    {
        OrgUser Find(string id);
        OrgUser FindByAccount(string loginName);
        OrgUser FindByCode(string code);
        bool AnyLoginName(string loginName, string excludedId);
        bool AnyCode(string code, string excludedId);
        PagedResult<OrgUser> FindPaged(SearchCriteria<OrgUser> searchCriteria);
        void Add(OrgUser dto);
        void Modify(OrgUser dto, string id);
        void ModifyPassword(string id, string password);
        void ModifyState(string id, OrgUserState state);
}
    }