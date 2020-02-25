using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.TeamWorkers
{
    public class DeviceInfo
    {

        public List<ContentItem> GetDeviceList()
        {

            List<ContentItem> Device = new List<ContentItem>();
            IMulePusher pusher = new DeviceGet() { RequestParam = new { projectId = ConfigHelper.KtpLoginProjectId } };
            PushSummary push = pusher.Push();
            if (push.Success)
            {

                Device = push.ResponseData;
            }

            return Device;
        }
    }
}
