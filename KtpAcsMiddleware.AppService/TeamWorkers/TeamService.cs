using System;
using System.Collections.Generic;
using System.Linq;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.Teams;
using KtpAcsMiddleware.Domain.Workers;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.AppService.TeamWorkers
{
    internal class TeamService : ITeamService
    {
        private readonly ITeamRepository _repository;
        private readonly IWorkerQueryRepository _workerQueryRepository;
        private readonly ITeamWorkTypeRepository _workTypeRepository;

        public TeamService(
            ITeamRepository repository,
            ITeamWorkTypeRepository workTypeRepository,
            IWorkerQueryRepository workerQueryRepository)
        {
            _repository = repository;
            _workTypeRepository = workTypeRepository;
            _workerQueryRepository = workerQueryRepository;
        }

        public Team Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(id)));
            }
            return _repository.Find(id);
        }

        public IList<Team> GetAll()
        {
            return _repository.FindAll().Where(a=> a.ProjectId == ConfigHelper.ProjectId).OrderBy(t => t.Name ).ToList();
        }

        public bool Any(string name, string excludedId)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(name)));
            }
            var searchCriteria = new SearchCriteria<Team>();
            searchCriteria.AddFilterCriteria(t => t.Name == name);
            if (!string.IsNullOrEmpty(excludedId))
                searchCriteria.AddFilterCriteria(t => t.Id != excludedId);
            return _repository.Find(searchCriteria).Any();
        }

        public void Add(Team dto)
        {
            dto.Id = ConfigHelper.NewGuid;
            dto.ProjectId = ConfigHelper.ProjectId;
            _repository.Add(dto);
        }

        public void Change(Team dto, string id)
        {
            if (id != dto.Id)
            {
                throw new InvalidException("The Id field is invalid.");
            }
            _repository.Modify(dto, id);
        }

        public void Remove(string teamId)
        {
            _repository.Delete(teamId);
        }

        public IList<TeamWorkType> GetAllWorkTypes()
        {
            return _workTypeRepository.FindAll();
        }

        public void ChangeLeaderId(string teamId, string newLeaderId)
        {
            if (string.IsNullOrEmpty(teamId))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(teamId)));
            }
            if (string.IsNullOrEmpty(newLeaderId))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(newLeaderId)));
            }
            var worker = _workerQueryRepository.Find(newLeaderId);
            if (worker.TeamId != teamId)
            {
                throw new ArgumentOutOfRangeException(
                    ExMessage.MustNotBeOutOfRange(nameof(newLeaderId), $"{newLeaderId}-{teamId}"));
            }
            _repository.ModifyLeaderId(teamId, newLeaderId);
        }
    }
}