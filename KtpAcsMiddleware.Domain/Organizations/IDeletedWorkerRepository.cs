using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Search.Paging;

namespace KtpAcsMiddleware.Domain.Organizations
{
    /// <summary>
    ///     已删除的工人(暂时未使用)
    /// </summary>
    public interface IDeletedWorkerRepository
    {
        PagedResult<Worker> FindPagedWorkers(SearchCriteria<Worker> searchCriteria);
    }
}