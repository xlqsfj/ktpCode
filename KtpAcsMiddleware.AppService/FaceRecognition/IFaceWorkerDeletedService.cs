using System.Collections.Generic;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Search.Paging;

namespace KtpAcsMiddleware.AppService.FaceRecognition
{
    /// <summary>
    ///     已删除的(设备工人)数据
    /// </summary>
    public interface IFaceWorkerDeletedService
    {
        IList<FaceDevice> GetDevices();

        PagedResult<FaceDeviceWorkerDeletedPagedDto> GetPaged(
            int pageIndex, int pageSize, string deviceId, string keywords, int state);

        /// <summary>
        ///     设备工人与对应的设备都设置为删除状态
        /// </summary>
        void ResetDeletedState(string faceDeviceWorkerId);
    }
}