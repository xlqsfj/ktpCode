using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.FaceRecognition;
using KtpAcsMiddleware.Infrastructure.Search.Paging;

namespace KtpAcsMiddleware.AppService.FaceRecognition
{
    public interface IFaceDeviceWorkerService
    {
        PagedResult<FaceDeviceWorkerPagedDto> GetPaged(
            int pageIndex, int pageSize, string deviceId, string keywords, int state);

        FaceDeviceWorker Add(string workerId, string deviceId);

        void ChangeState(string faceDeviceWorkerId, FaceWorkerState state);

        void Remove(string faceDeviceWorkerId);
    }
}