using System;
using System.Collections.Generic;
using System.Linq;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Search.Extensions;
using KtpAcsMiddleware.Infrastructure.Search.Paging;

namespace KtpAcsMiddleware.Domain.KtpLibrary
{
    internal class TeamSyncRepository : AbstractRepository, ITeamSyncRepository
    {
        public TeamSync FirstOrDefault(string id)
        {
            return DataContext.TeamSyncs.FirstOrDefault(t => t.Id == id);
        }

        public TeamSync FindByThirdPartyId(int thirdPartyId)
        {
            return DataContext.TeamSyncs.FirstOrDefault(t => t.ThirdPartyId == thirdPartyId);
        }

        public IList<TeamSync> FindAll()
        {
            return DataContext.TeamSyncs.Where(t => t.ThirdPartyId > 0).ToList();
        }

        public PagedResult<Team> FindPaged(SearchCriteria<Team> searchCriteria)
        {
            var count = DataContext.Teams.FilterBy(searchCriteria.FilterCriterias).Count();
            var entities = DataContext.Teams.SearchBy(searchCriteria);
            return new PagedResult<Team>(count, entities);
        }

        public void Add(TeamSync dto)
        {
            using (var dataContext = DataContext)
            {
                dto.CreateTime = DateTime.Now;
                dto.ModifiedTime = DateTime.Now;
                dataContext.TeamSyncs.InsertOnSubmit(dto);
                dataContext.SubmitChanges();
            }
        }

        public void Modify(string id, TeamSync dto)
        {
            using (var dataContext = DataContext)
            {
                var teamSync = dataContext.TeamSyncs.First(t => t.Id == id);
                teamSync.Type = dto.Type;
                teamSync.Status = dto.Status;
                teamSync.FeedbackCode = dto.FeedbackCode;
                teamSync.Feedback = dto.Feedback;
                if (teamSync.ThirdPartyId == 0)
                {
                    teamSync.ThirdPartyId = dto.ThirdPartyId;
                }
                teamSync.ModifiedTime = DateTime.Now;
                dataContext.SubmitChanges();
            }
        }

        public void ModifyState(string id, KtpSyncState status)
        {
            using (var dataContext = DataContext)
            {
                var teamSync = dataContext.TeamSyncs.First(t => t.Id == id);
                teamSync.Status = (int) status;
                teamSync.ModifiedTime = DateTime.Now;
                dataContext.SubmitChanges();
            }
        }
    }
}