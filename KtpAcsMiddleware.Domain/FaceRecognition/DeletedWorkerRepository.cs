using System.Linq;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.Organizations;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Search.Extensions;
using KtpAcsMiddleware.Infrastructure.Search.Paging;

namespace KtpAcsMiddleware.Domain.FaceRecognition
{
    internal class DeletedWorkerRepository : AbstractRepository, IDeletedWorkerRepository
    {
        public PagedResult<Worker> FindPagedWorkers(SearchCriteria<Worker> searchCriteria)
        {
            searchCriteria.AddFilterCriteria(t => t.IsDelete || t.WorkerIdentity.IsDelete || t.Team.IsDelete);
            var count = DataContext.Workers.FilterBy(searchCriteria.FilterCriterias).Count();
            var entities = DataContext.Workers.SearchBy(searchCriteria);
            return new PagedResult<Worker>(count, entities);
        }
    }
}