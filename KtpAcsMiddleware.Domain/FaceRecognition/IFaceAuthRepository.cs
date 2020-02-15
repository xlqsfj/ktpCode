using System;
using KtpAcsMiddleware.Domain.Data;

namespace KtpAcsMiddleware.Domain.FaceRecognition
{
    public interface IFaceAuthRepository
    {
        Worker FindWorker(string workerIdentityCode, DateTime authTime);
        void Add(ZmskAuthentication authentication);
        void ModifyGroupId(string id, string groupId);
    }
}