using System;
using System.Web.Mvc;
using KtpAcsMiddleware.AppService.FaceRecognition;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.FaceRecognition;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;
using HtmlHelper = KtpAcsMiddleware.Infrastructure.Utilities.HtmlHelper;

namespace KtpAcsMiddleware.Controllers
{
    public class FaceDeviceController : ControllerBase
    {
        private readonly IFaceDeviceService _faceDeviceService;

        public FaceDeviceController(IFaceDeviceService faceDeviceService)
        {
            _faceDeviceService = faceDeviceService;
        }

        [HttpGet]
        public string GetDevice(string id)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }
                var device = _faceDeviceService.Get(id);
                return new FaceDevice
                {
                    Id = device.Id,
                    Code = device.Code,
                    IpAddress = device.IpAddress,
                    IdentityId = device.IdentityId,
                    IsCheckIn = device.IsCheckIn,
                    Description = device.Description,
                    CreateTime = device.CreateTime,
                    ModifiedTime = device.ModifiedTime,
                    IsDelete = device.IsDelete
                }.ToJson();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                var result = HtmlHelper.Encode(ex.Message);
                return Ok(false, result);
            }
        }

        [HttpPost]
        public string PostDevice(FaceDevice dto)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }
                if (_faceDeviceService.Any(dto.Code, dto.Id))
                {
                    throw new PreValidationException("编号(设备号)不允许重复");
                }
                var newId = _faceDeviceService.Add(dto);
                return Ok(newId);
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                var result = HtmlHelper.Encode(ex.Message);
                return Ok(false, result);
            }
        }

        [HttpPost]
        public string PutDevice(FaceDevice dto, string dtoId)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }
                if (_faceDeviceService.Any(dto.Code, dto.Id))
                {
                    throw new PreValidationException("编号(设备号)不允许重复");
                }
                _faceDeviceService.Change(dto, dtoId);
                return Ok();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                var result = HtmlHelper.Encode(ex.Message);
                return Ok(false, result);
            }
        }

        [HttpPost]
        public string DelDevice(string id)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }

                _faceDeviceService.Remove(id);
                LogHelper.EntryLog(SessionUserId, $"DelDevice,id={id}");
                return Ok();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                var result = HtmlHelper.Encode(ex.Message);
                return Ok(false, result);
            }
        }

        [HttpGet]
        public string PutAllDeviceSyncFaces(string id)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }

                FaceDeviceWorkerEntityService.SendAllDeviceSyncFaceLibrary();
                return Ok();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                var result = HtmlHelper.Encode(ex.Message);
                return Ok(false, result);
            }
        }

        [HttpPost]
        public string PutDeviceUnSyncAddWorkersToNewState(string deviceId)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }
                _faceDeviceService.ChangeDeviceUnSyncAddWorkersToNewState(deviceId);
                return Ok();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                var result = HtmlHelper.Encode(ex.Message);
                return Ok(false, result);
            }
        }
    }
}