using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.AppService.ServiceModel;
using KtpAcsMiddleware.Domain.Workers;
using KtpAcsMiddleware.Infrastructure.Search.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.AppService.ServiceWorkers
{
   public interface IWorkerService
    {
        TeamWorkerDto Get(string workerId);

        PagedResult<WorkerDto> GetPaged(
            int pageIndex, int pageSize, string teamId, string keywords, WorkerAuthenticationState state);

        PagedResult<WorkerDto> GetPaged(
         int pageIndex, int pageSize, string teamId, string keywords, WorkerAuthenticationState state, string dName);

        int GetWorkerCount(WorkerAuthenticationState state);
    }
}
