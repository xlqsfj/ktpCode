using System.Collections.Generic;
using KtpAcsMiddleware.Domain.Data;

namespace KtpAcsMiddleware.AppService.TeamWorkers
{
    public interface ITeamService
    {
        Team Get(string id);
        IList<Team> GetAll();
        bool Any(string name, string excludedId);
        void Add(Team dto);
        void Change(Team dto, string id);
        void ChangeLeaderId(string teamId, string newLeaderId);
        void Remove(string teamId);
        IList<TeamWorkType> GetAllWorkTypes();
    }
}