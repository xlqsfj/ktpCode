using KtpAcsMiddleware.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.Domain.DomainDevice
{
  public  interface IDomainDeviceRepository
    {
        IList<FaceDeviceWorker> FindDeviceWorkers(string deviceId);
    }
}
