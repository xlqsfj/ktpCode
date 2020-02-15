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
    internal class WorkerSyncService : IWorkerSyncService
    {
        private readonly IWorkerSyncRepository _repository;

        public WorkerSyncService(IWorkerSyncRepository repository)
        {
            _repository = repository;
        }

        public PagedResult<WorkerSyncPagedDto> GetPaged(
            int pageIndex, int pageSize, string keywords, string teamId, KtpSyncState? state)
        {
            var searchCriteria = new SearchCriteria<Worker>();
            if (state != null)
            {
                if (state == KtpSyncState.NewAdd)
                {
                    searchCriteria.AddFilterCriteria(
                        t => t.WorkerSync == null || t.WorkerSync.Status == (int) state);
                }
                else
                {
                    searchCriteria.AddFilterCriteria(
                        t => t.WorkerSync != null && t.WorkerSync.Status == (int) state);
                }
            }
            if (!string.IsNullOrEmpty(teamId))
            {
                searchCriteria.AddFilterCriteria(t => t.TeamId == teamId);
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                int keywordInt;
                int? keywordFeedbackCode = null;
                if (int.TryParse(keywords, out keywordInt))
                {
                    keywordFeedbackCode = keywordInt;
                }

                var keywordSyncTypeValue = KtpSyncTypeService.GetValue(keywords);
                searchCriteria.AddFilterCriteria(
                    t => t.Name.Contains(keywords) ||
                         t.Mobile.Contains(keywords) ||
                         t.WorkerIdentity.Code.Contains(keywords) ||
                         (t.WorkerSync != null &&
                          keywordSyncTypeValue != null && t.WorkerSync.Type == keywordSyncTypeValue) ||
                         (t.WorkerSync != null && t.WorkerSync.Feedback != null &&
                          t.WorkerSync.Feedback.Contains(keywords)) ||
                         (t.WorkerSync != null && t.WorkerSync.FeedbackCode != null &&
                          keywordFeedbackCode == null && t.WorkerSync.FeedbackCode == keywordInt));
            }
            searchCriteria.AddSortCriteria(
                new ExpressionSortCriteria<Worker, string>(s => s.Name, SortDirection.Ascending));
            searchCriteria.AddSortCriteria(
                new ExpressionSortCriteria<Worker, DateTime>(s => s.ModifiedTime, SortDirection.Descending));
            searchCriteria.PagingCriteria = new PagingCriteria(pageIndex, pageSize);
            var pagedResult = _repository.FindPaged(searchCriteria);
            return new PagedResult<WorkerSyncPagedDto>(pagedResult.Count,
                pagedResult.Entities.Select(t => new WorkerSyncPagedDto
                {
                    Id = t.Id,
                    IdentityCode = t.WorkerIdentity.Code,
                    WorkerName = t.WorkerIdentity.Name,
                    Mobile = t.Mobile,
                    ThirdPartyId = t.WorkerSync == null ? 0 : t.WorkerSync.ThirdPartyId,
                    TeamThirdPartyId = t.WorkerSync == null ? 0 : t.WorkerSync.TeamThirdPartyId,
                    Type = t.WorkerSync == null
                        ? (t.IsDelete ? (int) KtpSyncType.PushDelete : (int) KtpSyncType.PushAdd)
                        : t.WorkerSync.Type,
                    Status = t.WorkerSync == null
                        ? (t.IsDelete ? (int) KtpSyncState.Ignore : (int) KtpSyncState.NewAdd)
                        : t.WorkerSync.Status,
                    FeedbackCode = t.WorkerSync?.FeedbackCode,
                    Feedback = t.WorkerSync == null ? string.Empty : t.WorkerSync.Feedback ?? string.Empty,
                    CreateTime = t.CreateTime,
                    ModifiedTime = t.ModifiedTime,
                    IsAuthentication = !string.IsNullOrEmpty(t.FacePicId)
                                       && !string.IsNullOrEmpty(t.WorkerIdentity.PicId)
                                       && !string.IsNullOrEmpty(t.WorkerIdentity.BackPicId),
                    TeamName = t.Team.Name
                }).ToList());
        }

        public void ResetSyncState(string workerSyncId)
        {
            if (string.IsNullOrEmpty(workerSyncId))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(workerSyncId)));
            }
            var teamSync = _repository.FirstOrDefault(workerSyncId);
            if (teamSync == null)
            {
                throw new NotFoundException(
                    ExMessage.NotFound(nameof(teamSync), $"workerSyncId={workerSyncId}"));
            }
            var syncType = (KtpSyncType) teamSync.Type;
            if (syncType == KtpSyncType.PushAdd)
            {
                _repository.ModifyState(workerSyncId, KtpSyncState.NewAdd);
                return;
            }
            if (syncType == KtpSyncType.PushEdit)
            {
                _repository.ModifyState(workerSyncId, KtpSyncState.NewEdit);
                return;
            }
            if (syncType == KtpSyncType.PushDelete)
            {
                _repository.ModifyState(workerSyncId, KtpSyncState.NewDel);
            }
        }
    }
}