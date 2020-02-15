using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KtpAcsMiddleware.Domain.Data;

namespace KtpAcsMiddleware.Domain.DomainDevice
{
    public class DomainDeviceRepository : AbstractRepository, IDomainDeviceRepository
    {
        public IList<FaceDeviceWorker> FindDeviceWorkers(string deviceId)
        {
            return DataContext.FaceDeviceWorkers.Where(t => t.DeviceId == deviceId && t.IsDelete==false).ToList();
        }
    }
}
