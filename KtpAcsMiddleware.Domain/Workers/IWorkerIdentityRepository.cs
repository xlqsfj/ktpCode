using System.Collections.Generic;
using KtpAcsMiddleware.Domain.Data;

namespace KtpAcsMiddleware.Domain.Workers
{
    public interface IWorkerIdentityRepository
    {
        WorkerIdentity FindByCode(string code);
        IList<WorkerIdentity> FindAll();
        void Add(WorkerIdentity dto);
        void Modify(string id, WorkerIdentity dto);
    }
}