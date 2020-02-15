using System;
using System.Collections.Generic;
using System.Linq;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.Domain.Base;
using KtpAcsMiddleware.Domain.FaceRecognition;
using KtpAcsMiddleware.Domain.Workers;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.AppService.FaceRecognition
{
    internal class FaceDeviceWorkerApiService : IFaceDeviceWorkerApiService
    {
        private readonly IFaceDeviceWorkerRepository _faceDeviceWorkerRepository;
        private readonly IFileMapRepository _fileMapRepository;
        private readonly IFaceDeviceWorkerApiRepository _repository;

        public FaceDeviceWorkerApiService(
            IFaceDeviceWorkerApiRepository repository,
            IFaceDeviceWorkerRepository faceDeviceWorkerRepository,
            IFileMapRepository fileMapRepository)
        {
            _repository = repository;
            _faceDeviceWorkerRepository = faceDeviceWorkerRepository;
            _fileMapRepository = fileMapRepository;
        }

        public string GetId(int identityId)
        {
            if (identityId <= 0)
            {
                throw new ArgumentOutOfRangeException(ExMessage.MustBeGreaterThanZero(nameof(identityId), identityId));
            }
            return _repository.FindId(identityId);
        }

        public IList<FaceLibraryUnsyncUserDto> GetFaceLibraryUnsync(string deviceCode)
        {
            //新添加数据处理
            var deviceNewWorkers = _repository.FindFaceLibraryNewAddUnsyncs(deviceCode).ToList();
            var avatarFileMaps = _fileMapRepository.Find(
                deviceNewWorkers.Select(i => i.Worker.FacePicId).ToArray()).ToList();
            IList<string> newAddIds = new List<string>();
            IList<FaceLibraryUnsyncUserDto> faceLibraryUnsyncUsers = new List<FaceLibraryUnsyncUserDto>();
            foreach (var deviceNewWorker in deviceNewWorkers)
            {
                try
                {
                    if (deviceNewWorker.Worker.FacePicId == null)
                    {
                        continue;
                    }
                    var avatarFileMap = avatarFileMaps.FirstOrDefault(i => i.Id == deviceNewWorker.Worker.FacePicId);
                    if (avatarFileMap == null)
                    {
                        continue;
                    }
                    var avatar =
                        FileIoHelper.GetFileBase64String(
                            $"{ConfigHelper.CustomFilesDir}{avatarFileMap.PhysicalFileName}");
                    var newDto = new FaceLibraryUnsyncUserDto
                    {
                        id = deviceNewWorker.Id,
                        name = deviceNewWorker.Worker.Name,
                        sex = deviceNewWorker.WorkerIdentity.Sex == ((int) WorkerSex.Man) ? 2 : 1,
                        idNumber = deviceNewWorker.WorkerIdentity.Code,
                        nation = ((IdentityNation) deviceNewWorker.WorkerIdentity.Nation).ToEnumText(),
                        address = deviceNewWorker.Worker.AddressNow,
                        avatar = avatar,
                        remark = string.Empty,
                        flag = 1,
                        organizationId = string.Empty,
                        operation = 1, //新添加的数据
                        libraryId = deviceNewWorker.IdentityId,
                        ctime = FormatHelper.GetDateTimeStamp(DateTime.Now),
                        groupId = string.Empty
                    };
                    faceLibraryUnsyncUsers.Add(newDto);
                    newAddIds.Add(newDto.id);
                }
                catch (Exception ex)
                {
                    LogHelper.ExceptionLog(ex, $"GetFaceLibraryUnsync.foreach-add Id={deviceNewWorker.Id}");
                }
            }
            //新删除数据处理
            var deviceNewDelWorkers = _repository.FindFaceLibraryNewDelUnsyncs(deviceCode).ToList();
            IList<string> newDelIds = new List<string>();
            foreach (var deviceNewDelWorker in deviceNewDelWorkers)
            {
                try
                {
                    var newDto = new FaceLibraryUnsyncUserDto
                    {
                        id = deviceNewDelWorker.Id,
                        name = deviceNewDelWorker.Worker.Name,
                        sex = deviceNewDelWorker.WorkerIdentity.Sex == ((int) WorkerSex.Man) ? 2 : 1,
                        idNumber = deviceNewDelWorker.WorkerIdentity.Code,
                        nation = ((IdentityNation) deviceNewDelWorker.WorkerIdentity.Nation).ToEnumText(),
                        address = deviceNewDelWorker.Worker.AddressNow,
                        avatar = string.Empty,
                        remark = string.Empty,
                        flag = 1,
                        organizationId = string.Empty,
                        operation = 2, //新删除的数据
                        libraryId = deviceNewDelWorker.IdentityId,
                        ctime = FormatHelper.GetDateTimeStamp(DateTime.Now),
                        groupId = string.Empty
                    };
                    faceLibraryUnsyncUsers.Add(newDto);
                    newDelIds.Add(newDto.id);
                }
                catch (Exception ex)
                {
                    LogHelper.ExceptionLog(ex, $"GetFaceLibraryUnsync.foreach-del Id={deviceNewDelWorker.Id}");
                }
            }
            try
            {
                _faceDeviceWorkerRepository.ModifyStates(newAddIds, FaceWorkerState.PrepareAdd);
                _faceDeviceWorkerRepository.ModifyStates(newDelIds, FaceWorkerState.PrepareDel);
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex, "GetFaceLibraryUnsync.ModifyStates");
            }
            return faceLibraryUnsyncUsers;
        }

        public void SaveSyncedState(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(id)));
            }
            var faceWorker = _repository.Find(id);
            var state = faceWorker.Status == (int) FaceWorkerState.PrepareDel
                ? FaceWorkerState.HasDel
                : FaceWorkerState.HasAdd;
            if (state == FaceWorkerState.HasDel && faceWorker.IsDelete == false)
            {
                //已从设备删除，数据库却没有删除，视为因编辑工人人脸识别相关数据而需要设备先删除人脸数据后重新添加(设备无编辑数据操作)
                state = FaceWorkerState.New;
            }
            _repository.ModifyState(faceWorker.Id, state, string.Empty);
        }

        public void SaveSyncFailState(string id, string errorCode)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(id)));
            }
            var faceWorker = _repository.Find(id);
            var state = faceWorker.Status == (int) FaceWorkerState.PrepareDel
                ? FaceWorkerState.FailDel
                : FaceWorkerState.FailAdd;
            if (state == FaceWorkerState.FailAdd && errorCode != null &&
                int.Parse(errorCode) == (int) FaceDeviceWorkerErrorCode.RepeatAdd)
            {
                //重复添加产生的异常视为已添加
                state = FaceWorkerState.RepeatAdd;
            }
            _repository.ModifyState(faceWorker.Id, state, errorCode);
        }
    }
}