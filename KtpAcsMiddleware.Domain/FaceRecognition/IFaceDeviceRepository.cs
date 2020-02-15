using System.Collections.Generic;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Search;

namespace KtpAcsMiddleware.Domain.FaceRecognition
{
    public interface IFaceDeviceRepository
    {
        FaceDevice First(string id);
        FaceDevice FirstOrDefault(SearchCriteria<FaceDevice> searchCriteria);
        bool Any(string code, string excludedId);
        IList<FaceDevice> FindAll();
        void Add(FaceDevice dto);
        void Modify(FaceDevice dto, string deviceId);
        void ModifyIpAddress(string deviceId, string ipAddress);
        void Delete(string deviceId);
        void AddAllWorkers(string deviceId);
    }
}