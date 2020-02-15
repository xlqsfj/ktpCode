using System;
using System.Collections.Generic;
using System.Linq;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.Domain.Teams
{
    internal class TeamWorkTypeRepository : AbstractRepository, ITeamWorkTypeRepository
    {
        public IList<TeamWorkType> FindAll()
        {
            return DataContext.TeamWorkTypes.Where(t => t.IsDelete == false).OrderBy(t => t.Name).ToList();
        }

        public void Adds(IList<TeamWorkType> teamWorkTypes)
        {
            if (teamWorkTypes == null)
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNull(nameof(teamWorkTypes)));
            }
            if (teamWorkTypes.Count == 0)
            {
                throw new ArgumentOutOfRangeException(ExMessage.MustBeGreaterThanZero(nameof(teamWorkTypes), 0));
            }
            var now = DateTime.Now;
            using (var dataContext = DataContext)
            {
                foreach (var teamWorkType in teamWorkTypes)
                {
                    teamWorkType.Id = ConfigHelper.NewGuid;
                    teamWorkType.CreateTime = now;
                    teamWorkType.IsDelete = false;
                    dataContext.TeamWorkTypes.InsertOnSubmit(teamWorkType);
                }
                dataContext.SubmitChanges();
            }
        }
    }
}