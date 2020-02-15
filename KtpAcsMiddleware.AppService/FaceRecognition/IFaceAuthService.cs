using KtpAcsMiddleware.Domain.Data;

namespace KtpAcsMiddleware.AppService.FaceRecognition
{
    public interface IFaceAuthService
    {
        ZmskAuthentication Add(ZmskAuthentication item);
    }
}