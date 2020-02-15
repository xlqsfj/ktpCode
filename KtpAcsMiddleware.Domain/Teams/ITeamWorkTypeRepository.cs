using System.Collections.Generic;
using KtpAcsMiddleware.Domain.Data;

namespace KtpAcsMiddleware.Domain.Teams
{
    public interface ITeamWorkTypeRepository
    {
        IList<TeamWorkType> FindAll();
        void Adds(IList<TeamWorkType> teamWorkTypes);
    }
}