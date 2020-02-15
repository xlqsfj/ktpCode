using System;
using System.Collections.Generic;
using System.Linq;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.FaceRecognition;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.AppService.FaceRecognition
{
    internal class FaceDeviceService : IFaceDeviceService
    {
        private readonly IFaceDeviceWorkerRepository _faceDeviceWorkerRepository;
        private readonly IFaceDeviceRepository _repository;

        public FaceDeviceService(
            IFaceDeviceRepository repository,
            IFaceDeviceWorkerRepository faceDeviceWorkerRepository)
        {
            _repository = repository;
            _faceDeviceWorkerRepository = faceDeviceWorkerRepository;
        }

        public FaceDevice Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(id)));
            }
            return _repository.First(id);
        }

        public FaceDevice GetByIdentityId(int identityId)
        {
            if (identityId <= 0)
            {
                throw new ArgumentOutOfRangeException(ExMessage.MustBeGreaterThanZero(nameof(identityId), identityId));
            }
            var searchCriteria = new SearchCriteria<FaceDevice>();
            searchCriteria.AddFilterCriteria(t => t.IdentityId == identityId);
            return _repository.FirstOrDefault(searchCriteria);
        }

        public FaceDevice GetByCode(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(code)));
            }
            var searchCriteria = new SearchCriteria<FaceDevice>();
            searchCriteria.AddFilterCriteria(t => t.Code == code);
            return _repository.FirstOrDefault(searchCriteria);
        }

        public bool Any(string code, string excludedId)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(code)));
            }
            return _repository.Any(code, excludedId);
        }

        public IList<FaceDevice> GetAll()
        {
            return _repository.FindAll().OrderBy(i => i.Code).ToList();
        }

        public void Change(FaceDevice dto, string deviceId)
        {
            if (deviceId != dto.Id)
            {
                throw new InvalidException("The Id field is invalid.");
            }
            _repository.Modify(dto, deviceId);
            _repository.AddAllWorkers(dto.Id);
        }

        public void ChangeIpAddress(string deviceId, string ipAddress)
        {
            if (string.IsNullOrEmpty(deviceId))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(deviceId)));
            }
            if (string.IsNullOrEmpty(ipAddress))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(ipAddress)));
            }
            _repository.ModifyIpAddress(deviceId, ipAddress);
        }

        public string Add(FaceDevice dto)
        {
            var now = DateTime.Now;
            dto.Id = ConfigHelper.NewGuid;
            dto.IsDelete = false;
            dto.CreateTime = now;
            dto.ModifiedTime = now;
            _repository.Add(dto);
            _repository.AddAllWorkers(dto.Id);
            FaceDeviceWorkerEntityService.SendDeviceSyncFaceLibrary(dto.Id);
            return dto.Id;
        }

        public void Remove(string deviceId)
        {
            _repository.Delete(deviceId);
        }

        public void ChangeDeviceUnSyncAddWorkersToNewState(string deviceId)
        {
            if (string.IsNullOrEmpty(deviceId))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(deviceId)));
            }
            var unSyncAddWorkers = _faceDeviceWorkerRepository.FindDeviceUnSyncAddWorkers(deviceId);
            if (unSyncAddWorkers == null || unSyncAddWorkers.Count == 0)
            {
                return;
            }
            IList<string> ids = unSyncAddWorkers.Select(i => i.Id).ToList();
            _faceDeviceWorkerRepository.ModifyStates(ids, FaceWorkerState.New);
        }

        public void ChangeDeviceUnSyncDelWorkersToNewDelState(string deviceId)
        {
            if (string.IsNullOrEmpty(deviceId))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(deviceId)));
            }
            var unSyncDelWorkers = _faceDeviceWorkerRepository.FindDeviceUnSyncDelWorkers(deviceId);
            if (unSyncDelWorkers == null || unSyncDelWorkers.Count == 0)
            {
                return;
            }
            IList<string> ids = unSyncDelWorkers.Select(i => i.Id).ToList();
            _faceDeviceWorkerRepository.ModifyStates(ids, FaceWorkerState.NewDel);
        }
    }
}