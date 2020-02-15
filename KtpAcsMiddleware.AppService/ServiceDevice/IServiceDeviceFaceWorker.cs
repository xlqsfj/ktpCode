using KtpAcsMiddleware.AppService.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.AppService.ServiceDevice
{
    public interface IServiceDeviceFaceWorker
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        int GetWorkerDeviceCount(string deviceId);

        IList<HomeDeviceDto> GetDeviceList();



    }
}
