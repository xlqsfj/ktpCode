using KtpAcsMiddleware.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.Domain.DomainWorkers
{
 public    interface IDomainWorkersRepository
    {
        IList<Worker> FindAuthWorkers(IList<ZmskAuthentication> auths,bool isBePresent);
    }
}
