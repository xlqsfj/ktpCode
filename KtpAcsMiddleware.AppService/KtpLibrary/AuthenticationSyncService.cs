using System;
using System.Collections.Generic;
using System.Linq;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.FaceRecognition;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Domain.WorkerAuths;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Search.Paging;
using KtpAcsMiddleware.Infrastructure.Search.Sort;

namespace KtpAcsMiddleware.AppService.KtpLibrary
{
    internal class AuthenticationSyncService : IAuthenticationSyncService
    {
        private readonly IFaceDeviceRepository _faceDeviceRepository;
        private readonly IAuthenticationSyncRepository _repository;

        public AuthenticationSyncService(
            IAuthenticationSyncRepository repository,
            IFaceDeviceRepository faceDeviceRepository)
        {
            _repository = repository;
            _faceDeviceRepository = faceDeviceRepository;
        }

        public PagedResult<AuthenticationSyncPagedDto> GetPaged(
            int pageIndex, int pageSize, string keywords, string deviceCode, KtpSyncState? state)
        {
            var searchCriteria = new SearchCriteria<ZmskAuthentication>();
            if (!string.IsNullOrEmpty(deviceCode))
            {
                searchCriteria.AddFilterCriteria(t => t.DeviceNumber == deviceCode);
            }
            if (state != null)
            {
                if (state == KtpSyncState.NewAdd)
                {
                    searchCriteria.AddFilterCriteria(t => t.ZmskAuthenticationSync == null
                                                          || t.ZmskAuthenticationSync.Status == (int) state);
                }
                else
                {
                    searchCriteria.AddFilterCriteria(t => t.ZmskAuthenticationSync != null &&
                                                          t.ZmskAuthenticationSync.Status == (int) state);
                }
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                searchCriteria.AddFilterCriteria(
                    t => t.Name.Contains(keywords) || t.IdNumber.Contains(keywords));
            }
            searchCriteria.AddSortCriteria(
                new ExpressionSortCriteria<ZmskAuthentication, DateTime>(s => s.CreateTime, SortDirection.Descending));
            searchCriteria.PagingCriteria = new PagingCriteria(pageIndex, pageSize);
            var pagedResult = _repository.FindPaged(searchCriteria);
            IList<AuthenticationSyncPagedDto> authenticationSyncPagedDtos = pagedResult.Entities
                .Select(t => new AuthenticationSyncPagedDto
                {
                    Id = t.Id,
                    WorkerName = t.Name,
                    IdentityCode = t.IdNumber,
                    DeviceCode = t.DeviceNumber,
                    ClockType = null,
                    AuthTimeStamp = t.AuthTimeStamp,
                    ClockState = t.Result,
                    State = t.ZmskAuthenticationSync == null
                        ? (int) KtpSyncState.NewAdd
                        : t.ZmskAuthenticationSync.Status,
                    FeedbackCode = t.ZmskAuthenticationSync == null ? null : t.ZmskAuthenticationSync.FeedbackCode,
                    Feedback = t.ZmskAuthenticationSync == null
                        ? string.Empty
                        : t.ZmskAuthenticationSync.Feedback ?? string.Empty
                }).ToList();
            //补全AuthenticationSyncPagedDto
            var allDevices = _faceDeviceRepository.FindAll();
            var authWorkers = _repository.FindAuthWorkers(pagedResult.Entities.ToList());
            foreach (var authenticationSyncPagedDto in authenticationSyncPagedDtos)
            {
                var authDevice = allDevices.FirstOrDefault(i => i.Code == authenticationSyncPagedDto.DeviceCode);
                if (authDevice == null)
                {
                    continue;
                }
                if (authDevice.IsCheckIn == null)
                {
                    continue;
                }
                if (authDevice.IsCheckIn == true)
                {
                    authenticationSyncPagedDto.ClockType = (int) WorkerAuthClockType.JinZhaji;
                }
                else
                {
                    authenticationSyncPagedDto.ClockType = (int) WorkerAuthClockType.ChuZhaji;
                }
                if (authWorkers == null || authWorkers.Count == 0)
                {
                    continue;
                }
                var authWorker = authWorkers.FirstOrDefault(i => i.Name == authenticationSyncPagedDto.WorkerName);
                if (authWorker == null)
                {
                    continue;
                }
                authenticationSyncPagedDto.WorkerId = authWorker.Id;
            }
            return new PagedResult<AuthenticationSyncPagedDto>(pagedResult.Count, authenticationSyncPagedDtos);
        }

        public void ResetSyncState(string authenticationSyncId)
        {
            if (string.IsNullOrEmpty(authenticationSyncId))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(authenticationSyncId)));
            }
            var sync = _repository.FirstOrDefault(authenticationSyncId);
            if (sync == null)
            {
                throw new NotFoundException(
                    ExMessage.NotFound(nameof(sync), $"authenticationSyncId={authenticationSyncId}"));
            }
            _repository.ModifyState(authenticationSyncId, KtpSyncState.NewAdd);
        }
    }
}