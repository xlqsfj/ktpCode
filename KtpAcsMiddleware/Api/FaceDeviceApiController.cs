using System;
using System.Web.Mvc;
using KtpAcsMiddleware.AppService.FaceRecognition;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.Api
{
    public class FaceDeviceApiController : ApiBaseController
    {
        private readonly IFaceDeviceService _faceDeviceService;

        public FaceDeviceApiController(IFaceDeviceService faceDeviceService)
        {
            _faceDeviceService = faceDeviceService;
        }

        /// <summary>
        ///     添加设备绑定信息
        /// </summary>
        /// <param name="deviceNumber">设备ID(对应到数据库标记的code)</param>
        /// <param name="deviceIP">IP地址</param>
        /// <returns></returns>
        [HttpGet]
        public string PutDevice(string deviceNumber, string deviceIP)
        {
            LogHelper.Info($"添加设备绑定信息:FaceDeviceApi.PutDevice:deviceNumber={deviceNumber}");
            try
            {
                if (deviceIP == null)
                {
                    deviceIP = GetIpaddress();
                }
                var device = _faceDeviceService.GetByCode(deviceNumber);
                if (device == null)
                {
                    _faceDeviceService.Add(new FaceDevice {Code = deviceNumber, IpAddress = deviceIP});
                }
                else
                {
                    _faceDeviceService.ChangeIpAddress(device.Id, deviceIP);
                }
                return Ok200Success();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                return OkFail();
            }
        }

        /// <summary>
        ///     获取请求的IP地址
        /// </summary>
        /// <returns></returns>
        private string GetIpaddress()
        {
            var result = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_CDN_SRC_IP"];
            if (string.IsNullOrEmpty(result))
                result = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            if (string.IsNullOrEmpty(result))
                result = System.Web.HttpContext.Current.Request.UserHostAddress;

            if (string.IsNullOrEmpty(result) || !ValidationHelper.IsIpAddress(result))
                return string.Empty;

            return result;
        }
    }
}