using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.AppService.FaceRecognition;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.Api
{
    public class FaceDeviceWorkerApiController : ApiBaseController
    {
        private readonly IFaceDeviceService _faceDeviceService;
        private readonly IFaceDeviceWorkerApiService _faceDeviceWorkerApiService;

        public FaceDeviceWorkerApiController(
            IFaceDeviceWorkerApiService faceDeviceWorkerApiService,
            IFaceDeviceService faceDeviceService)
        {
            _faceDeviceWorkerApiService = faceDeviceWorkerApiService;
            _faceDeviceService = faceDeviceService;
        }

        /// <summary>
        ///     获取设备对应未同步的人脸库
        /// </summary>
        /// <param name="deviceNumber">设备ID(对应到数据库标记的code)</param>
        /// <returns></returns>
        [HttpGet]
        public string GetFaceLibraryUnsync(string deviceNumber)
        {
            LogHelper.Info($"添加人脸库:FaceDeviceWorkerApi.GetFaceLibraryUnsync:deviceNumber={deviceNumber}");
            try
            {
                var faces = _faceDeviceWorkerApiService.GetFaceLibraryUnsync(deviceNumber);
                if (faces == null)
                {
                    return Ok200Success(new List<FaceLibraryUnsyncUserDto>().ToArray());
                }
                var ids = string.Empty;
                foreach (var id in faces.Select(t => t.id))
                {
                    ids = ids + id + "|";
                }
                LogHelper.Info(
                    $"FaceDeviceWorkerApi.GetFaceLibraryUnsync:faces.Count={faces.Count},deviceNumber={deviceNumber},ids={ids.TrimEnd('|')}");
                return Ok200Success(faces.ToArray());
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                return OkFail(new List<FaceLibraryUnsyncUserDto>().ToArray());
            }
        }

        [HttpGet]
        public string GetFaceLibraryUnsyncInt(int deviceId)
        {
            try
            {
                var device = _faceDeviceService.GetByIdentityId(deviceId);
                return GetFaceLibraryUnsync(device.Code);
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                return OkFail(new List<FaceLibraryUnsyncUserDto>().ToArray());
            }
        }

        /// <summary>
        ///     标记人脸库同步记录
        /// </summary>
        /// <param name="id">FaceLibraryUnsyncUserDto.Id</param>
        /// <returns></returns>
        [HttpPost]
        public string PutFlagSynced(string id)
        {
            LogHelper.Info($"标记人脸库同步记录:FaceDeviceWorkerApi.PutFlagSynced:id={id}");
            try
            {
                int identityId;
                if (int.TryParse(id, out identityId))
                {
                    id = _faceDeviceWorkerApiService.GetId(identityId);
                }
                _faceDeviceWorkerApiService.SaveSyncedState(id);
                return Ok200Success();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                return OkFail();
            }
        }

        /// <summary>
        ///     标记无效人脸库
        /// </summary>
        /// <param name="id">FaceLibraryUnsyncUserDto.Id</param>
        /// <param name="errorCode">错误码：1、下载人脸库失败，2、人脸重复添加 ，3、 未发现人脸特征</param>
        /// <returns></returns>
        [HttpPost]
        public string PutFlagSyncFail(string id, string errorCode)
        {
            LogHelper.Info($"添加人脸无效:FaceDeviceWorkerApi.PutFlagSyncFail:id={id},errorCode={errorCode}");
            try
            {
                int identityId;
                if (int.TryParse(id, out identityId))
                {
                    id = _faceDeviceWorkerApiService.GetId(identityId);
                }
                if (!string.IsNullOrEmpty(errorCode))
                {
                    errorCode = errorCode.Trim();
                }
                _faceDeviceWorkerApiService.SaveSyncFailState(id, errorCode);
                return Ok200Success();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                return OkFail();
            }
        }
    }
}