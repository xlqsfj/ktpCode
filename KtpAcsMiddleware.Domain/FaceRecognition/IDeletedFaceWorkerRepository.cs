using System.Collections.Generic;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Search.Paging;

namespace KtpAcsMiddleware.Domain.FaceRecognition
{
    /// <summary>
    ///     已删除的设备工人
    /// </summary>
    public interface IDeletedFaceWorkerRepository
    {
        IList<FaceDevice> FindDevices();

        PagedResult<FaceDeviceWorker> FindPagedWorkers(SearchCriteria<FaceDeviceWorker> searchCriteria);

        /// <summary>
        ///     设备工人与对应的设备都设置为删除状态
        /// </summary>
        void ResetDeletedState(string faceDeviceWorkerId);
    }
}