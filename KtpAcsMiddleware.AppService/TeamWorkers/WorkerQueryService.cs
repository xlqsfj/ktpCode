using System;
using System.Collections.Generic;
using System.Linq;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.Domain.Base;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.Workers;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Search.Paging;
using KtpAcsMiddleware.Infrastructure.Search.Sort;
using KtpAcsMiddleware.Infrastructure.Serialization;

namespace KtpAcsMiddleware.AppService.TeamWorkers
{
    internal class WorkerQueryService : IWorkerQueryService
    {
        private readonly IFileMapRepository _fileRepository;
        private readonly IWorkerQueryRepository _workerRepository;

        public WorkerQueryService(
            IWorkerQueryRepository workerRepository,
            IFileMapRepository fileRepository)
        {
            _workerRepository = workerRepository;
            _fileRepository = fileRepository;
        }

        public TeamWorkerDto Get(string workerId)
        {
            if (string.IsNullOrEmpty(workerId))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(workerId)));
            }
            var teamWorker = _workerRepository.Find(workerId);
            var result = new TeamWorkerDto
            {
                /***TeamWorker-Worker*************/
                Id = teamWorker.Id,
                TeamId = teamWorker.TeamId,
                WorkerId = teamWorker.Id,
                InTime = teamWorker.InTime,
                OutTime = teamWorker.OutTime,
                Mobile = teamWorker.Mobile,
                Status = teamWorker.Status,
                ContractPicId = teamWorker.ContractPicId,
                CreateTime = teamWorker.CreateTime,
                ModifiedTime = teamWorker.ModifiedTime,
                WorkerName = teamWorker.Name,
                IdentityId = teamWorker.IdentityId,
                IdentityFaceSim = teamWorker.IdentityFaceSim,
                AddressNow = teamWorker.AddressNow,
                FacePicId = teamWorker.FacePicId,
                WorkerCreatorId = teamWorker.CreatorId,
                WorkerCreateTime = teamWorker.CreateTime,
                WorkerIsDelete = teamWorker.IsDelete,
                BankCardTypeId = teamWorker.BankCardTypeId,
                BankCardCode = teamWorker.BankCardCode,
                /***WorkerIdentity*************/
                IdentityCode = teamWorker.WorkerIdentity.Code,
                Sex = teamWorker.WorkerIdentity.Sex,
                Nation = teamWorker.WorkerIdentity.Nation,
                Birthday = teamWorker.WorkerIdentity.Birthday,
                Address = teamWorker.WorkerIdentity.Address,
                IssuingAuthority = teamWorker.WorkerIdentity.IssuingAuthority,
                ActivateTime = teamWorker.WorkerIdentity.ActivateTime,
                InvalidTime = teamWorker.WorkerIdentity.InvalidTime,
                IdentityPicId = teamWorker.WorkerIdentity.PicId,
                IdentityBackPicId = teamWorker.WorkerIdentity.BackPicId,
                CreateType = teamWorker.WorkerIdentity.CreateType,
                IdentityCreateTime = teamWorker.WorkerIdentity.CreateTime,
                CreditGrade = teamWorker.WorkerIdentity.CreditGrade,
                IdentityCardIsDelete = teamWorker.WorkerIdentity.IsDelete,
                /***Team*************/
                ProjectId = teamWorker.Team.ProjectId,
                TeamName = teamWorker.Team.Name,
                TeamWorkTypeId = teamWorker.Team.WorkTypeId,
                TeamDescription = teamWorker.Team.Description,
                TeamCreateTime = teamWorker.Team.CreateTime,
                TeamModifiedTime = teamWorker.Team.ModifiedTime,
                TeamIsDelete = teamWorker.Team.IsDelete,
                /***Extension*************/
                TeamWorkTypValue = teamWorker.Team.TeamWorkType.Value,
                TeamWorkTypeName = teamWorker.Team.TeamWorkType.Name,
                //身份证头像
                u_sfzpic=teamWorker.WorkerIdentity.Base64Photo
                 
            };

            string[] fileIds = {result.ContractPicId, result.IdentityPicId, result.IdentityBackPicId, result.FacePicId};
            IList<FileMap> fileMaps = _fileRepository.Find(fileIds).ToList();
            result.ContractPicFileName = FileMapEntityService.GetFileSrc(fileMaps, result.ContractPicId);
            result.IdentityPicFileName = FileMapEntityService.GetFileSrc(fileMaps, result.IdentityPicId);
            result.IdentityBackPicFileName = FileMapEntityService.GetFileSrc(fileMaps, result.IdentityBackPicId);
            result.FacePicFileName = FileMapEntityService.GetFileSrc(fileMaps, result.FacePicId);
            return result;
        }

        public PagedResult<TeamWorkerPagedDto> GetPaged(
            int pageIndex, int pageSize, string teamId, string keywords, WorkerAuthenticationState state)
        {
            var searchCriteria = GetTeamWorkerGridSearchCriteria(teamId, keywords, state);
            searchCriteria.PagingCriteria = new PagingCriteria(pageIndex, pageSize);
            var pagedResult = _workerRepository.FindPaged(searchCriteria);
            return new PagedResult<TeamWorkerPagedDto>(
                pagedResult.Count, GetMaptoTeamWorkerGridDtos(pagedResult.Entities));
        }

        private SearchCriteria<Worker> GetTeamWorkerGridSearchCriteria(
            string teamId, string keywords, WorkerAuthenticationState state)
        {
            var searchCriteria = new SearchCriteria<Worker>();
            if (!string.IsNullOrEmpty(teamId))
            {
                searchCriteria.AddFilterCriteria(t => t.TeamId == teamId);
            }
            else
            {
                searchCriteria.AddFilterCriteria(t => t.Team != null && t.Team.IsDelete == false);
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                var keywordNationValue = IdentityNationService.GetValue(keywords);
                searchCriteria.AddFilterCriteria(
                    t => t.Name.Contains(keywords) ||
                         t.WorkerIdentity.Code.Contains(keywords) ||
                         t.Mobile.Contains(keywords) ||
                         t.AddressNow.Contains(keywords) ||
                         (keywordNationValue != null && t.WorkerIdentity.Nation == keywordNationValue));
            }
            if (state == WorkerAuthenticationState.Already)
            {
                searchCriteria.AddFilterCriteria(
                    t => t.FacePicId != null && t.FacePicId != string.Empty
                         && t.WorkerIdentity.PicId != null && t.WorkerIdentity.PicId != string.Empty
                         && t.WorkerIdentity.BackPicId != null && t.WorkerIdentity.BackPicId != string.Empty);
            }
            if (state == WorkerAuthenticationState.WaitFor)
            {
                searchCriteria.AddFilterCriteria(
                    t => t.FacePicId == null || t.FacePicId == string.Empty
                         || t.WorkerIdentity.PicId == null || t.WorkerIdentity.PicId == string.Empty
                         || t.WorkerIdentity.BackPicId == null ||
                         t.WorkerIdentity.BackPicId != string.Empty);
            }
            searchCriteria.AddSortCriteria(
                new ExpressionSortCriteria<Worker, string>(s => s.Name, SortDirection.Ascending));
            searchCriteria.AddSortCriteria(
                new ExpressionSortCriteria<Worker, DateTime>(s => s.CreateTime, SortDirection.Descending));
            return searchCriteria;
        }

        private List<TeamWorkerPagedDto> GetMaptoTeamWorkerGridDtos(IEnumerable<Worker> teamWorkers)
        {
            if (teamWorkers == null)
            {
                return new List<TeamWorkerPagedDto>();
            }
            return teamWorkers.Select(i => new TeamWorkerPagedDto
            {
                Id = i.Id,
                WorkerName = i.WorkerIdentity.Name,
                IdentityCode = i.WorkerIdentity.Code,
                Sex = i.WorkerIdentity.Sex,
                Mobile = i.Mobile,
                Nation = ((IdentityNation) i.WorkerIdentity.Nation).ToEnumText(),
                AddressNow = i.AddressNow,
                FacePicId = i.FacePicId,
                IdentityPicId = i.WorkerIdentity.PicId,
                IdentityBackPicId = i.WorkerIdentity.BackPicId,
                TeamId = i.TeamId,
                TeamName = i.Team.Name
            }).ToList();
        }
    }
}