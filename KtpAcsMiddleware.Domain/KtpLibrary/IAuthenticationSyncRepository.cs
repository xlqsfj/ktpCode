using System.Collections.Generic;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.Dto;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Search.Paging;

namespace KtpAcsMiddleware.Domain.KtpLibrary
{
    public interface IAuthenticationSyncRepository
    {
        ZmskAuthenticationSync FirstOrDefault(string id);
        void Save(ZmskAuthenticationSync dto);
        PagedResult<ZmskAuthentication> FindPaged(SearchCriteria<ZmskAuthentication> searchCriteria);

        /// <summary>
        ///     获取认证信息对应的工人信息
        /// </summary>
        /// <param name="auths">认证信息</param>
        /// <returns></returns>
        IList<Worker> FindAuthWorkers(IList<ZmskAuthentication> auths);

        WorkerAuthCollectionDto FindNew(string authId);
        IList<WorkerAuthCollectionDto> FindTopOneThousandNews(out int selectCount);
        void ModifyState(string id, KtpSyncState state);
    }
}