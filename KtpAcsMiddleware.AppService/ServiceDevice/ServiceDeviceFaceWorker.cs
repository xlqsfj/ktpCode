using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.AppService.ServiceModel;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.DomainDevice;
using KtpAcsMiddleware.Domain.FaceRecognition;
using KtpAcsMiddleware.Infrastructure.Serialization;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.AppService.ServiceDevice
{
    internal class ServiceDeviceFaceWorker : IServiceDeviceFaceWorker
    {
        private readonly IDomainDeviceRepository _deviceRepository;

        public ServiceDeviceFaceWorker(IDomainDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }
        /// <summary>
        /// 查询设备信息
        /// </summary>
        /// <returns></returns>
        public IList<HomeDeviceDto> GetDeviceList()
        {
            IList<FaceDevice> _devices = ServiceFactory.FaceDeviceService.GetAll();
            var list = _devices.Select(i => new HomeDeviceDto
            {
                Id = i.Id,
                IpAddress = i.IpAddress,
                Description = i.Description,
                DState = "",
                IsCheckIn = i.IsCheckIn == true ? "进门" : "出门",
                Code = i.Code,
                DCount = GetWorkerDeviceCount(i.Id),
                currentMag=GetDeviceErrorMag(i.Id)
                 


            }).ToList();
            return list;
        }

        public int GetWorkerDeviceCount(string deviceId)
        {
            return _deviceRepository.FindDeviceWorkers(deviceId).Count();
        }

        /// <summary>
        /// 返回设备返回的信息
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public string GetDeviceErrorMag(string deviceId) {
            var list = _deviceRepository.FindDeviceWorkers(deviceId);
            FaceDeviceWorker device = null;
            if (list.Count()>0)
             device = list.OrderByDescending(a => a.CreateTime).Where(a => a.ErrorCode != "").First();
            if (device == null)
                return string.Empty;
            int intErrorCode;
            if (int.TryParse(device.ErrorCode, out intErrorCode))
            {
                return $"{device.ErrorCode}.{((FaceDeviceWorkerErrorCode)intErrorCode).ToEnumText()}";
            }
            return device.ErrorCode;

           
        }

    }
}
