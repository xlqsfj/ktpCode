using System.Collections.Generic;
using KtpAcsMiddleware.AppService.Dto;

namespace KtpAcsMiddleware.AppService.FaceRecognition
{
    public interface IFaceDeviceWorkerApiService
    {
        string GetId(int identityId);
        IList<FaceLibraryUnsyncUserDto> GetFaceLibraryUnsync(string deviceCode);
        void SaveSyncedState(string id);
        void SaveSyncFailState(string id, string errorCode);
    }
}