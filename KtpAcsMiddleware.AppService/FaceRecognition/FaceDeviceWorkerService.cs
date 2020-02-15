using System;
using System.Linq;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.FaceRecognition;
using KtpAcsMiddleware.Domain.Workers;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Search.Paging;
using KtpAcsMiddleware.Infrastructure.Search.Sort;

namespace KtpAcsMiddleware.AppService.FaceRecognition
{
    internal class FaceDeviceWorkerService : IFaceDeviceWorkerService
    {
        private readonly IFaceDeviceWorkerRepository _repository;

        public FaceDeviceWorkerService(IFaceDeviceWorkerRepository repository)
        {
            _repository = repository;
        }

        public PagedResult<FaceDeviceWorkerPagedDto> GetPaged(
            int pageIndex, int pageSize, string deviceId, string keywords, int state)
        {
            var searchCriteria = new SearchCriteria<FaceDeviceWorker>();
            if (!string.IsNullOrEmpty(deviceId))
            {
                searchCriteria.AddFilterCriteria(t => t.DeviceId == deviceId);
            }
            else
            {
                searchCriteria.AddFilterCriteria(t => t.FaceDevice.IsDelete == false);
            }
            searchCriteria.AddFilterCriteria(t => t.Worker.IsDelete == false);
            if (state >= 0)
            {
                searchCriteria.AddFilterCriteria(t => t.Status == state);
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                var keywordNationValue = IdentityNationService.GetValue(keywords);
                searchCriteria.AddFilterCriteria(
                    t => t.Worker.Name.Contains(keywords) ||
                         t.Worker.WorkerIdentity.Code.Contains(keywords) ||
                         t.Worker.AddressNow.Contains(keywords) ||
                         t.Worker.WorkerIdentity.Address.Contains(keywords) ||
                         (keywordNationValue != null && t.Worker.WorkerIdentity.Nation == keywordNationValue));
            }
            //searchCriteria.AddSortCriteria(
            //    new ExpressionSortCriteria<FaceDeviceWorker, int>(s => s.Status, SortDirection.Descending));
            searchCriteria.AddSortCriteria(
                new ExpressionSortCriteria<FaceDeviceWorker, DateTime>(s => s.Worker.CreateTime,
                    SortDirection.Descending));
            searchCriteria.AddSortCriteria(
                new ExpressionSortCriteria<FaceDeviceWorker, string>(s => s.Worker.Name,
                    SortDirection.Ascending));
            searchCriteria.PagingCriteria = new PagingCriteria(pageIndex, pageSize);
            var pagedResult = _repository.FindPaged(searchCriteria);
            var list = pagedResult.Entities.Select(i => new FaceDeviceWorkerPagedDto
            {
                Id = i.Id,
                WorkerId = i.Worker.Id,
                WorkerName = i.Worker.Name,
                IdentityCode = i.Worker.WorkerIdentity.Code,
                Mobile = i.Worker.Mobile,
                Sex = i.Worker.WorkerIdentity.Sex,
                Nation = i.Worker.WorkerIdentity.Nation,
                AddressNow = i.Worker.AddressNow,
                Status = i.Status,
                ErrorCode = i.ErrorCode,
                FacePicId = i.Worker.FacePicId,
                DeviceCode = i.FaceDevice.Code
            }).ToList();
            return new PagedResult<FaceDeviceWorkerPagedDto>(pagedResult.Count, list);
        }

        public FaceDeviceWorker Add(string workerId, string deviceId)
        {
            if (_repository.FindAny(workerId, deviceId))
            {
                throw new BusinessException(
                    $"FaceDeviceWorker already existed. workerId={workerId}. deviceId={deviceId}");
            }
            var newFaceDeviceWorker = new FaceDeviceWorker
            {
                WorkerId = workerId,
                DeviceId = deviceId,
                Status = (int) FaceWorkerState.New
            };
            _repository.Add(newFaceDeviceWorker);
            return newFaceDeviceWorker;
        }

        public void ChangeState(string faceDeviceWorkerId, FaceWorkerState state)
        {
            if (string.IsNullOrEmpty(faceDeviceWorkerId))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(faceDeviceWorkerId)));
            }
            _repository.ModifyState(faceDeviceWorkerId, state);
        }

        public void Remove(string faceDeviceWorkerId)
        {
            if (string.IsNullOrEmpty(faceDeviceWorkerId))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(faceDeviceWorkerId)));
            }
            _repository.Delete(faceDeviceWorkerId);
            var targetFaceDeviceId = _repository.Find(faceDeviceWorkerId).DeviceId;
            FaceDeviceWorkerEntityService.SendDeviceSyncFaceLibrary(targetFaceDeviceId);
        }
    }
}