using System;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.FaceRecognition;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.AppService.FaceRecognition
{
    internal class FaceAuthService : IFaceAuthService
    {
        private readonly IFaceAuthRepository _repository;

        public FaceAuthService(IFaceAuthRepository repository)
        {
            _repository = repository;
        }

        public ZmskAuthentication Add(ZmskAuthentication item)
        {
            item.Id = ConfigHelper.NewGuid;
            item.CreateTime = DateTime.Now;
            _repository.Add(item);

            return item;
        }
    }
}