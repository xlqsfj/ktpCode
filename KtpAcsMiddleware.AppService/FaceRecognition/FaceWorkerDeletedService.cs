using System;
using System.Collections.Generic;
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
    internal class FaceWorkerDeletedService : IFaceWorkerDeletedService
    {
        private readonly IDeletedFaceWorkerRepository _repository;


        public FaceWorkerDeletedService(IDeletedFaceWorkerRepository repository)
        {
            _repository = repository;
        }

        public IList<FaceDevice> GetDevices()
        {
            return _repository.FindDevices().OrderBy(i => i.Code).ToList();
        }

        public PagedResult<FaceDeviceWorkerDeletedPagedDto> GetPaged(
            int pageIndex, int pageSize, string deviceId, string keywords, int state)
        {
            var searchCriteria = new SearchCriteria<FaceDeviceWorker>();
            if (!string.IsNullOrEmpty(deviceId))
            {
                searchCriteria.AddFilterCriteria(t => t.DeviceId == deviceId);
            }
            if (state >= 0)
            {
                searchCriteria.AddFilterCriteria(t => t.Status == state);
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                var keywordNationValue = IdentityNationService.GetValue(keywords);
                searchCriteria.AddFilterCriteria(
                    t => t.Worker.Name.Contains(keywords) ||
                         t.Worker.Mobile.Contains(keywords) ||
                         t.Worker.WorkerIdentity.Code.Contains(keywords) ||
                         t.Worker.AddressNow.Contains(keywords) ||
                         (keywordNationValue != null && t.Worker.WorkerIdentity.Nation == keywordNationValue));
            }
            searchCriteria.AddSortCriteria(
                new ExpressionSortCriteria<FaceDeviceWorker, string>(s => s.Worker.Name,
                    SortDirection.Ascending));
            searchCriteria.AddSortCriteria(
                new ExpressionSortCriteria<FaceDeviceWorker, DateTime>(s => s.Worker.CreateTime,
                    SortDirection.Descending));
            searchCriteria.PagingCriteria = new PagingCriteria(pageIndex, pageSize);
            var pagedResult = _repository.FindPagedWorkers(searchCriteria);
            var list = pagedResult.Entities.Select(i => new FaceDeviceWorkerDeletedPagedDto
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
                DeviceCode = i.FaceDevice.Code
            }).ToList();
            return new PagedResult<FaceDeviceWorkerDeletedPagedDto>(pagedResult.Count, list);
        }

        public void ResetDeletedState(string faceDeviceWorkerId)
        {
            if (string.IsNullOrEmpty(faceDeviceWorkerId))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(faceDeviceWorkerId)));
            }
            _repository.ResetDeletedState(faceDeviceWorkerId);
        }
    }
}