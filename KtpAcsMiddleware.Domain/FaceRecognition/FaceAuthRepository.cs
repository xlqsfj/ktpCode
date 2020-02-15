using System;
using System.Linq;
using KtpAcsMiddleware.Domain.Data;

namespace KtpAcsMiddleware.Domain.FaceRecognition
{
    internal class FaceAuthRepository : AbstractRepository, IFaceAuthRepository
    {
        public Worker FindWorker(string workerIdentityCode, DateTime authTime)
        {
            return DataContext.Workers.FirstOrDefault(
                t => t.WorkerIdentity.Code == workerIdentityCode &&
                     t.InTime <= authTime && (t.OutTime == null || t.OutTime > authTime));
        }

        public void Add(ZmskAuthentication authentication)
        {
            using (var dataContext = DataContext)
            {
                dataContext.ZmskAuthentications.InsertOnSubmit(authentication);
                dataContext.SubmitChanges();
            }
        }

        public void ModifyGroupId(string id, string groupId)
        {
            using (var dataContext = DataContext)
            {
                var authentication = dataContext.ZmskAuthentications.First(t => t.Id == id);
                authentication.GroupId = groupId;
                dataContext.SubmitChanges();
            }
        }
    }
}