using System;
using System.Collections.Generic;
using System.Linq;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.FaceRecognition;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Search.Extensions;
using KtpAcsMiddleware.Infrastructure.Search.Paging;

namespace KtpAcsMiddleware.Domain.Organizations
{
    internal class DeletedFaceWorkerRepository : AbstractRepository, IDeletedFaceWorkerRepository
    {
        public IList<FaceDevice> FindDevices()
        {
            return DataContext.FaceDevices.Where(t => t.IsDelete).ToList();
        }

        public PagedResult<FaceDeviceWorker> FindPagedWorkers(SearchCriteria<FaceDeviceWorker> searchCriteria)
        {
            searchCriteria.AddFilterCriteria(t => t.IsDelete || t.FaceDevice.IsDelete || t.Worker.IsDelete);
            var count = DataContext.FaceDeviceWorkers.FilterBy(searchCriteria.FilterCriterias).Count();
            var entities = DataContext.FaceDeviceWorkers.SearchBy(searchCriteria);
            return new PagedResult<FaceDeviceWorker>(count, entities);
        }

        public void ResetDeletedState(string faceDeviceWorkerId)
        {
            using (var dataContext = DataContext)
            {
                var faceDeviceWorker = dataContext.FaceDeviceWorkers.First(t => t.Id == faceDeviceWorkerId);
                faceDeviceWorker.Status = (int) FaceWorkerState.NewDel;
                faceDeviceWorker.IsDelete = true;
                faceDeviceWorker.FaceDevice.IsDelete = true;
                faceDeviceWorker.ModifiedTime = DateTime.Now;
                dataContext.SubmitChanges();
            }
        }
    }
}