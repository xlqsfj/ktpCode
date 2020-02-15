using System;
using System.Collections.Generic;
using System.Linq;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Search.Extensions;
using KtpAcsMiddleware.Infrastructure.Search.Paging;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.Domain.FaceRecognition
{
    internal class FaceDeviceWorkerRepository : AbstractRepository, IFaceDeviceWorkerRepository
    {
        public FaceDeviceWorker Find(string id)
        {
            return DataContext.FaceDeviceWorkers.First(t => t.Id == id);
        }

        public bool FindAny(string workerId, string deviceId)
        {
            return DataContext.FaceDeviceWorkers.Any(
                t => t.WorkerId == workerId && t.DeviceId == deviceId && t.IsDelete == false);
        }

        public IList<FaceDeviceWorker> FindDeviceUnSyncAddWorkers(string deviceId)
        {
            //&&t.IsDelete == false && t.FaceDevice.IsDelete == false && t.Worker.IsDelete == false
            return DataContext.FaceDeviceWorkers.Where(t => t.DeviceId == deviceId &&
                                                            (t.Status == (int) FaceWorkerState.PrepareAdd ||
                                                             t.Status == (int) FaceWorkerState.FailAdd)).ToList();
        }

        public IList<FaceDeviceWorker> FindDeviceUnSyncDelWorkers(string deviceId)
        {
            return DataContext.FaceDeviceWorkers.Where(t => t.DeviceId == deviceId &&
                                                            (t.Status == (int) FaceWorkerState.PrepareDel ||
                                                             t.Status == (int) FaceWorkerState.FailDel)).ToList();
        }

        public PagedResult<FaceDeviceWorker> FindPaged(SearchCriteria<FaceDeviceWorker> searchCriteria)
        {
            searchCriteria.AddFilterCriteria(
                t => t.IsDelete == false || (t.IsDelete && t.Status != (int) FaceWorkerState.HasDel));
            var count = DataContext.FaceDeviceWorkers.FilterBy(searchCriteria.FilterCriterias).Count();
            var entities = DataContext.FaceDeviceWorkers.SearchBy(searchCriteria);
            return new PagedResult<FaceDeviceWorker>(count, entities);
        }

        public void Add(FaceDeviceWorker entity)
        {
            if (string.IsNullOrEmpty(entity.Id))
            {
                entity.Id = ConfigHelper.NewGuid;
            }
            var now = DateTime.Now;
            entity.CreateTime = now;
            entity.ModifiedTime = now;
            entity.IsDelete = false;
            using (var dataContext = DataContext)
            {
                dataContext.FaceDeviceWorkers.InsertOnSubmit(entity);
                dataContext.SubmitChanges();
            }
        }

        public void ModifyStates(IList<string> ids, FaceWorkerState state)
        {
            using (var dataContext = DataContext)
            {
                foreach (var id in ids)
                {
                    if (string.IsNullOrEmpty(id))
                    {
                        continue;
                    }
                    var faceDeviceWorker = dataContext.FaceDeviceWorkers.First(t => t.Id == id);
                    faceDeviceWorker.Status = (int) state;
                    faceDeviceWorker.ErrorCode = string.Empty;
                    faceDeviceWorker.ModifiedTime = DateTime.Now;
                }
                dataContext.SubmitChanges();
            }
        }

        public void ModifyState(string faceDeviceWorkerId, FaceWorkerState state)
        {
            using (var dataContext = DataContext)
            {
                var faceDeviceWorker = dataContext.FaceDeviceWorkers.First(t => t.Id == faceDeviceWorkerId);
                faceDeviceWorker.Status = (int) state;
                faceDeviceWorker.ErrorCode = string.Empty;
                faceDeviceWorker.ModifiedTime = DateTime.Now;
                dataContext.SubmitChanges();
            }
        }

        public void Delete(string id)
        {
            using (var dataContext = DataContext)
            {
                var target = dataContext.FaceDeviceWorkers.First(t => t.Id == id);
                target.IsDelete = true;
                target.Status = (int) FaceWorkerState.NewDel;
                dataContext.SubmitChanges();
            }
        }
    }
}