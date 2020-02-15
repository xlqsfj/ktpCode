using System.Collections.Generic;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.Dto;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Search.Paging;

namespace KtpAcsMiddleware.Domain.KtpLibrary
{
    public interface IWorkerSyncRepository
    {
        WorkerSync FirstOrDefault(string id);
        IList<WorkerDto> FindCoverPushNews();
        PagedResult<Worker> FindPaged(SearchCriteria<Worker> searchCriteria);
        void Add(WorkerSync dto);
        void Modify(string id, WorkerSync dto);
        void ModifyState(string id, KtpSyncState status);
    }
}