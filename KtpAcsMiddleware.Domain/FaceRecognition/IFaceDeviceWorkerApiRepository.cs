using System.Collections.Generic;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.Dto;

namespace KtpAcsMiddleware.Domain.FaceRecognition
{
    public interface IFaceDeviceWorkerApiRepository
    {
        FaceDeviceWorker Find(string id);

        string FindId(int identityId);

        /// <summary>
        ///     设备人脸库未同步的新添加数据
        /// </summary>
        /// <returns>前三条数据</returns>
        IList<ApiFaceWorkerUnsyncDto> FindFaceLibraryNewAddUnsyncs(string deviceCode);

        /// <summary>
        ///     设备人脸库未同步的新删除数据
        /// </summary>
        IList<ApiFaceWorkerUnsyncDto> FindFaceLibraryNewDelUnsyncs(string deviceCode);

        void ModifyState(string id, FaceWorkerState state, string errorCode);
    }
}