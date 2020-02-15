using System.Collections.Generic;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Search.Paging;

namespace KtpAcsMiddleware.Domain.FaceRecognition
{
    public interface IFaceDeviceWorkerRepository
    {
        FaceDeviceWorker Find(string id);

        bool FindAny(string workerId, string deviceId);

        /// <summary>
        ///     获取设备所有预添加或者添加失败的数据
        /// </summary>
        /// <returns></returns>
        IList<FaceDeviceWorker> FindDeviceUnSyncAddWorkers(string deviceId);

        /// <summary>
        ///     获取设备所有预删除或者删除失败的数据
        /// </summary>
        /// <returns></returns>
        IList<FaceDeviceWorker> FindDeviceUnSyncDelWorkers(string deviceId);

        PagedResult<FaceDeviceWorker> FindPaged(SearchCriteria<FaceDeviceWorker> searchCriteria);

        void Add(FaceDeviceWorker entity);

        void ModifyStates(IList<string> faceDeviceWorkerIds, FaceWorkerState state);

        void ModifyState(string faceDeviceWorkerId, FaceWorkerState state);

        void Delete(string faceDeviceWorkerId);
    }
}