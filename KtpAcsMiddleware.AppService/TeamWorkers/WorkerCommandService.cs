using System;
using System.Collections.Generic;
using System.Linq;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.Dto;
using KtpAcsMiddleware.Domain.FaceRecognition;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Domain.Workers;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.AppService.TeamWorkers
{
    internal class WorkerCommandService : IWorkerCommandService
    {
        private readonly IWorkerIdentityRepository _identityRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWorkerCommandRepository _workerCommandRepository;
        private readonly IWorkerQueryRepository _workerQueryRepository;

        public WorkerCommandService(
            IWorkerQueryRepository workerQueryRepository,
            IWorkerCommandRepository workerCommandRepository,
            IWorkerIdentityRepository identityRepository,
            IUnitOfWork unitOfWork)
        {
            _workerQueryRepository = workerQueryRepository;
            _workerCommandRepository = workerCommandRepository;
            _identityRepository = identityRepository;
            _unitOfWork = unitOfWork;
        }

        public bool AnyIdentityCode(string identityCode, string excludedId)
        {
            if (string.IsNullOrEmpty(identityCode))
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(identityCode)));
            return _workerQueryRepository.FindAnyIdentityCode(identityCode, excludedId);
        }

        public bool AnyMobile(string mobile, string excludedId)
        {
            if (string.IsNullOrEmpty(mobile))
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(mobile)));
            return _workerQueryRepository.FindAnyMobile(mobile, excludedId);
        }

        public IList<WorkerDto> GetAll()
        {
            return _workerQueryRepository.FindAll().ToList();
        }

        public string Add(TeamWorkerDto dto)
        {
            var now = DateTime.Now;
            var workerIdentityId = string.Empty;
            if (string.IsNullOrEmpty(dto.WorkerCreatorId))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(dto.WorkerCreatorId)));
            }
            //Save Identity
            var workerIdentity = _identityRepository.FindByCode(dto.IdentityCode);
            if (workerIdentity != null)
            {
                workerIdentityId = workerIdentity.Id;
            }
            else
            {
                workerIdentity = new WorkerIdentity();
            }
            if (string.IsNullOrEmpty(workerIdentityId) ||
                workerIdentity.CreateType == (int) WorkerIdentityCreateType.Manual ||
                dto.CreateType == (int) WorkerIdentityCreateType.Reader)
            {
                workerIdentity.CreateType = dto.CreateType;
                workerIdentity.Code = dto.IdentityCode.Trim();
                workerIdentity.Name = dto.WorkerName.Trim();
                workerIdentity.Sex = dto.Sex;
                workerIdentity.Nation = dto.Nation;
                workerIdentity.Address = dto.Address != null ? dto.Address.Trim() : string.Empty;
                workerIdentity.Birthday = dto.Birthday;
                workerIdentity.IssuingAuthority = dto.IssuingAuthority.Trim();
                workerIdentity.ActivateTime = dto.ActivateTime;
                workerIdentity.InvalidTime = dto.InvalidTime;
                workerIdentity.PicId = dto.IdentityPicId ?? string.Empty;
                workerIdentity.BackPicId = dto.IdentityBackPicId ?? string.Empty;
                workerIdentity.Base64Photo = dto.u_sfzpic;
            }
            if (string.IsNullOrEmpty(workerIdentityId))
            {
                workerIdentity.Id = ConfigHelper.NewGuid;
                _identityRepository.Add(workerIdentity);
                workerIdentityId = workerIdentity.Id;
            }
            else
            {
                _identityRepository.Modify(workerIdentityId, workerIdentity);
            }
            //Save Worker
            var newWorker = new Worker
            {
                InTime = now,
                Status = (int) WorkerPositionState.Zaichang,
                TeamId = dto.TeamId,
                Mobile = dto.Mobile.Trim(),
                ContractPicId = dto.ContractPicId ?? string.Empty,
                CreatorId = dto.WorkerCreatorId,
                Name = dto.WorkerName.Trim(),
                IdentityId = workerIdentityId,
                AddressNow = dto.AddressNow,
                FacePicId = dto.FacePicId,
                Id = ConfigHelper.NewGuid,
                BankCardTypeId = dto.BankCardTypeId,
                BankCardCode = dto.BankCardCode
            };
            _workerCommandRepository.Add(newWorker);
            _workerCommandRepository.AddToAllFaceDevice(newWorker.Id);
            return newWorker.Id;
        }

        public void Change(TeamWorkerDto dto, string dtoId)
        {
            if (dtoId != dto.Id)
            {
                throw new InvalidException("The Id field is invalid.");
            }
            var worker = _workerQueryRepository.First(dtoId);
            var now = DateTime.Now;
            //update worker
            worker.Name = dto.WorkerName.Trim();
            worker.AddressNow = dto.AddressNow.Trim();
            if (!string.IsNullOrEmpty(dto.FacePicId))
            {
                worker.FacePicId = dto.FacePicId;
            }
            worker.BankCardTypeId = dto.BankCardTypeId;
            worker.BankCardCode = dto.BankCardCode;
            worker.Mobile = dto.Mobile;
            worker.ContractPicId = dto.ContractPicId ?? string.Empty;
            worker.ModifiedTime = now;
            //update workerIdentity
            if (worker.WorkerIdentity.CreateType == (int) WorkerIdentityCreateType.Manual ||
                dto.CreateType == (int) WorkerIdentityCreateType.Reader)
            {
                worker.WorkerIdentity.Code = dto.IdentityCode.Trim();
                worker.WorkerIdentity.Name = dto.WorkerName.Trim();
                worker.WorkerIdentity.Sex = dto.Sex;
                worker.WorkerIdentity.Nation = dto.Nation;
                worker.WorkerIdentity.Address = dto.Address?.Trim() ?? string.Empty;
                worker.WorkerIdentity.Birthday = dto.Birthday;
                worker.WorkerIdentity.IssuingAuthority = dto.IssuingAuthority.Trim();
                worker.WorkerIdentity.ActivateTime = dto.ActivateTime;
                worker.WorkerIdentity.InvalidTime = dto.InvalidTime;
            }
            if (!string.IsNullOrEmpty(dto.IdentityPicId))
            {
                worker.WorkerIdentity.PicId = dto.IdentityPicId;
            }
            if (!string.IsNullOrEmpty(dto.IdentityBackPicId))
            {
                worker.WorkerIdentity.BackPicId = dto.IdentityBackPicId;
            }
            //身份证图片
            if (!string.IsNullOrEmpty(dto.u_sfzpic)) {

                worker.WorkerIdentity.Base64Photo = dto.u_sfzpic;
            }
            //update workerSync
            if (worker.WorkerSync != null)
            {
                if (worker.WorkerSync.TeamThirdPartyId > 0)
                {
                    worker.WorkerSync.Status = (int) KtpSyncState.NewEdit;
                }
                else
                {
                    worker.WorkerSync.Status = (int) KtpSyncState.NewAdd;
                }
            }
            _unitOfWork.Commit();
            _workerCommandRepository.AddToAllFaceDevice(dto.WorkerId);
        }

        public void ChangeTeam(string workerId, string teamId)
        {
            if (string.IsNullOrEmpty(workerId))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(workerId)));
            }
            if (string.IsNullOrEmpty(teamId))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(teamId)));
            }
            _workerCommandRepository.ModifyTeamId(workerId, teamId);
        }

        public void SaveAuthenticationIdentity(WorkerIdentityAuthenticationDto dto)
        {
            var facePicId = _workerQueryRepository.Find(dto.WorkerId).FacePicId;
            _workerCommandRepository.ModifyIdentityAuth(
                dto.WorkerId, dto.FacePicId, dto.IdentityPicId, dto.IdentityBackPicId);

            if (string.IsNullOrEmpty(facePicId))
            {
                //原来没有人脸数据，刚添加的人脸照片，把工人人脸数据添加到所有设备
                _workerCommandRepository.AddToAllFaceDevice(dto.WorkerId);
            }
        }

        public void Remove(string workerId)
        {
            if (string.IsNullOrEmpty(workerId))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(workerId)));
            }
            _workerCommandRepository.Delete(workerId);
            FaceDeviceWorkerEntityService.SendAllDeviceSyncFaceLibrary();
        }

        public void ChangeWorkerFaceDeviceStatesToReAdd(string workerId)
        {
            _workerCommandRepository.ModifyFaceDevicesStateNewDel(workerId);
            FaceDeviceWorkerEntityService.SendAllDeviceSyncFaceLibrary();
        }
    }
}