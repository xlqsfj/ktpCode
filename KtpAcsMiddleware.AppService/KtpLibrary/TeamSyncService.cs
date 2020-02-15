using System;
using System.Linq;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Search.Paging;
using KtpAcsMiddleware.Infrastructure.Search.Sort;

namespace KtpAcsMiddleware.AppService.KtpLibrary
{
    internal class TeamSyncService : ITeamSyncService
    {
        private readonly ITeamSyncRepository _repository;

        public TeamSyncService(ITeamSyncRepository repository)
        {
            _repository = repository;
        }

        public PagedResult<TeamSyncPagedDto> GetPaged(
            int pageIndex, int pageSize, string keywords, string workTypeId, KtpSyncState? state)
        {
            var searchCriteria = new SearchCriteria<Team>();
            if (state != null)
            {
                if (state == KtpSyncState.NewAdd)
                {
                    searchCriteria.AddFilterCriteria(
                        t => t.TeamSync == null || t.TeamSync.Status == (int) state);
                }
                else
                {
                    searchCriteria.AddFilterCriteria(
                        t => t.TeamSync != null && t.TeamSync.Status == (int) state);
                }
            }
            if (!string.IsNullOrEmpty(workTypeId))
            {
                searchCriteria.AddFilterCriteria(t => t.WorkTypeId == workTypeId);
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                int keywordInt;
                var keywordSyncTypeValue = KtpSyncTypeService.GetValue(keywords);
                searchCriteria.AddFilterCriteria(
                    t => t.Name.Contains(keywords) ||
                         t.TeamWorkType.Name.Contains(keywords) ||
                         (t.TeamSync != null &&
                          keywordSyncTypeValue != null && t.TeamSync.Type == keywordSyncTypeValue) ||
                         (t.TeamSync != null && t.TeamSync.Feedback != null &&
                          t.TeamSync.Feedback.Contains(keywords)) ||
                         (t.TeamSync != null && int.TryParse(keywords, out keywordInt) &&
                          t.TeamSync.FeedbackCode != null && t.TeamSync.FeedbackCode == keywordInt));
            }
            searchCriteria.AddSortCriteria(
                new ExpressionSortCriteria<Team, string>(s => s.Name, SortDirection.Ascending));
            searchCriteria.AddSortCriteria(
                new ExpressionSortCriteria<Team, DateTime>(s => s.ModifiedTime, SortDirection.Descending));
            searchCriteria.PagingCriteria = new PagingCriteria(pageIndex, pageSize);
            var pagedResult = _repository.FindPaged(searchCriteria);
            return new PagedResult<TeamSyncPagedDto>(pagedResult.Count, pagedResult.Entities
                .Select(t => new TeamSyncPagedDto
                {
                    Id = t.Id,
                    ThirdPartyId = t.TeamSync == null ? 0 : t.TeamSync.ThirdPartyId,
                    Type = t.TeamSync == null ? (int) KtpSyncType.PushAdd : t.TeamSync.Type,
                    Status = t.TeamSync == null ? (int) KtpSyncState.NewAdd : t.TeamSync.Status,
                    FeedbackCode = t.TeamSync?.FeedbackCode,
                    Feedback = t.TeamSync == null ? string.Empty : t.TeamSync.Feedback ?? string.Empty,
                    CreateTime = t.CreateTime,
                    ModifiedTime = t.ModifiedTime,
                    WorkTypeName = t.TeamWorkType.Name,
                    TeamName = t.Name,
                    TeamModifiedTime = t.ModifiedTime
                }).ToList());
        }

        public void ResetSyncState(string teamSyncId)
        {
            if (string.IsNullOrEmpty(teamSyncId))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(teamSyncId)));
            }
            var teamSync = _repository.FirstOrDefault(teamSyncId);
            if (teamSync == null)
            {
                throw new NotFoundException(
                    ExMessage.NotFound(nameof(teamSync), $"teamSyncId={teamSyncId}"));
            }
            var syncType = (KtpSyncType) teamSync.Type;
            if (syncType == KtpSyncType.PushAdd)
            {
                _repository.ModifyState(teamSyncId, KtpSyncState.NewAdd);
                return;
            }
            if (syncType == KtpSyncType.PushEdit)
            {
                _repository.ModifyState(teamSyncId, KtpSyncState.NewEdit);
                return;
            }
            if (syncType == KtpSyncType.PushDelete)
            {
                _repository.ModifyState(teamSyncId, KtpSyncState.NewDel);
            }
        }
    }
}