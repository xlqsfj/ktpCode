using System.Collections.Generic;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Search;

namespace KtpAcsMiddleware.Domain.Teams
{
    public interface ITeamRepository
    {
        Team Find(string id);
        IEnumerable<Team> FindAll();
        IEnumerable<Team> Find(SearchCriteria<Team> searchCriteria);
        void Add(Team dto);
        void Modify(Team dto, string id);
        void ModifyLeaderId(string id, string newLeaderId);
        void Delete(string id);
    }
}