using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.Dto;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Search.Extensions;
using KtpAcsMiddleware.Infrastructure.Search.Paging;

namespace KtpAcsMiddleware.Domain.KtpLibrary
{
    internal class WorkerSyncRepository : AbstractRepository, IWorkerSyncRepository
    {
        public WorkerSync FirstOrDefault(string id)
        {
            return DataContext.WorkerSyncs.FirstOrDefault(t => t.Id == id);
        }

        public IList<WorkerDto> FindCoverPushNews()
        {
            return DataContext.Workers.Where(
                    t => t.WorkerIdentity != null && t.IsDelete == false
                         && t.FacePicId != null && t.FacePicId != string.Empty
                         && t.WorkerIdentity.PicId != null && t.WorkerIdentity.PicId != string.Empty
                         && t.WorkerIdentity.BackPicId != null && t.WorkerIdentity.BackPicId != string.Empty)
                .Select(t => Mapper.Map<WorkerDto>(t)).ToList();
        }

        public PagedResult<Worker> FindPaged(SearchCriteria<Worker> searchCriteria)
        {
            var count = DataContext.Workers.FilterBy(searchCriteria.FilterCriterias).Count();
            var entities = DataContext.Workers.SearchBy(searchCriteria);
            return new PagedResult<Worker>(count, entities);
        }

        public void Add(WorkerSync dto)
        {
            using (var dataContext = DataContext)
            {
                var workerSync = dataContext.WorkerSyncs.FirstOrDefault(t => t.Id == dto.Id);
                if (workerSync == null)
                {
                    dto.CreateTime = DateTime.Now;
                    dto.ModifiedTime = DateTime.Now;
                    dataContext.WorkerSyncs.InsertOnSubmit(dto);
                }
                else
                {
                    if (workerSync.Status == (int) KtpSyncState.NewAdd)
                    {
                        workerSync.Type = (int) KtpSyncType.PushAdd;
                    }
                    if (workerSync.Status == (int) KtpSyncState.NewEdit)
                    {
                        workerSync.Type = (int) KtpSyncType.PushEdit;
                    }
                    workerSync.Status = dto.Status;
                    workerSync.FeedbackCode = dto.FeedbackCode;
                    workerSync.Feedback = dto.Feedback;
                    if (workerSync.ThirdPartyId == 0)
                    {
                        workerSync.ThirdPartyId = dto.ThirdPartyId;
                    }
                    workerSync.ModifiedTime = DateTime.Now;
                }
                dataContext.SubmitChanges();
            }
        }

        public void Modify(string id, WorkerSync dto)
        {
            using (var dataContext = DataContext)
            {
                var sync = dataContext.WorkerSyncs.First(t => t.Id == id);
                sync.Type = dto.Type;
                sync.Status = dto.Status;
                sync.FeedbackCode = dto.FeedbackCode;
                sync.Feedback = dto.Feedback;
                if (sync.ThirdPartyId == 0)
                {
                    sync.ThirdPartyId = dto.ThirdPartyId;
                }
                sync.ModifiedTime = DateTime.Now;
                dataContext.SubmitChanges();
            }
        }

        public void ModifyState(string id, KtpSyncState status)
        {
            using (var dataContext = DataContext)
            {
                var sync = dataContext.WorkerSyncs.First(t => t.Id == id);
                sync.Status = (int) status;
                sync.ModifiedTime = DateTime.Now;
                dataContext.SubmitChanges();
            }
        }
    }
}