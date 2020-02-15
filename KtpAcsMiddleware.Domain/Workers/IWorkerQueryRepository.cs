using System.Collections.Generic;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.Dto;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Search.Paging;

namespace KtpAcsMiddleware.Domain.Workers
{
    public interface IWorkerQueryRepository
    {
        /// <summary>
        ///     DataContextFactory.First
        /// </summary>
        Worker First(string id);

        Worker Find(string id);
        IList<WorkerDto> FindAll(bool isContainDel = false);
        IList<WorkerDto> Find(SearchCriteria<Worker> searchCriteria, bool isContainDel = false);
        PagedResult<Worker> FindPaged(SearchCriteria<Worker> searchCriteria);

        /// <summary>
        ///     判断当前用户身份证号的全局唯一性
        /// </summary>
        bool FindAnyIdentityCode(string identityCode, string excludedId);

        /// <summary>
        ///     判断当前用户身份证号的全局唯一性
        /// </summary>
        bool FindAnyMobile(string mobile, string excludedId);
    }
}