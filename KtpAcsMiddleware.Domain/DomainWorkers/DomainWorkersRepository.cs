using System;
using System.Collections.Generic;
using System.Linq;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Search.Extensions;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.Domain.DomainWorkers
{
    public class DomainWorkersRepository : AbstractRepository, IDomainWorkersRepository
    {
        public IList<Worker> FindAuthWorkers(IList<ZmskAuthentication> auths, bool isBePresent)
        {
            List<Worker> workers = new List<Worker>();
            List<ZmskAuthentication> auths1 = auths.DistinctBy(a => new { a.Name, a.IdNumber }).ToList();


            using (var dataContext = DataContext)
            {
                workers= (from t in auths1
                          join tworker in dataContext.Workers on t.IdNumber equals tworker.WorkerIdentity.Code
                          where   tworker.IsDelete== isBePresent
                          select new Worker {  Name=t.Name,  BankCardCode= tworker.Team.Name,  IdentityId = tworker.WorkerIdentity.Code }).ToList();

                workers = workers.Where(a=>a.IsDelete== isBePresent).ToList();
            }



                return workers;
          
        }
    }
}
