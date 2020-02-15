using KtpAcsMiddleware.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.Domain.DomainAuths
{
  public  interface IDomainAuthsRepository
    {
        /// <summary>
        /// aa
        /// </summary>
        /// <param name="authId"></param>
        /// <returns></returns>
        WorkerAuthCollectionDto FindNew(string authId);
    }
}
