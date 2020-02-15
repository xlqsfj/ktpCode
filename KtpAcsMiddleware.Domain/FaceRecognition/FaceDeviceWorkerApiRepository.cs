using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.Dto;

namespace KtpAcsMiddleware.Domain.FaceRecognition
{
    internal class FaceDeviceWorkerApiRepository : AbstractRepository, IFaceDeviceWorkerApiRepository
    {
        public FaceDeviceWorker Find(string id)
        {
            return DataContext.FaceDeviceWorkers.First(t => t.Id == id);
        }

        public string FindId(int identityId)
        {
            var faceDeviceWorker = DataContext.FaceDeviceWorkers.FirstOrDefault(
                t => t.IdentityId == identityId);
            if (faceDeviceWorker == null)
            {
                return null;
            }
            return faceDeviceWorker.Id;
        }

        public IList<ApiFaceWorkerUnsyncDto> FindFaceLibraryNewAddUnsyncs(string deviceCode)
        {
            using (var dataContext = DataContext)
            {
                return dataContext.FaceDeviceWorkers.Where(
                        t => t.FaceDevice.Code == deviceCode
                             && (t.Status == (int) FaceWorkerState.New ||
                                 (t.Status == (int) FaceWorkerState.PrepareAdd &&
                                  t.ModifiedTime < DateTime.Now.AddMinutes(-30)))
                             && t.IsDelete == false && t.FaceDevice.IsDelete == false && t.Worker.IsDelete == false
                             && t.Worker.FacePicId != null && t.Worker.FacePicId != string.Empty)
                    .OrderBy(t => t.CreateTime).Take(3)
                    .Select(t => Mapper.Map<ApiFaceWorkerUnsyncDto>(t)).ToList();
            }
        }

        public IList<ApiFaceWorkerUnsyncDto> FindFaceLibraryNewDelUnsyncs(string deviceCode)
        {
            using (var dataContext = DataContext)
            {
                return dataContext.FaceDeviceWorkers.Where(
                        t => t.FaceDevice.Code == deviceCode
                             && (t.Status == (int) FaceWorkerState.NewDel ||
                                 (t.Status == (int) FaceWorkerState.PrepareDel &&
                                  t.ModifiedTime < DateTime.Now.AddMinutes(-30))))
                    .Select(t => Mapper.Map<ApiFaceWorkerUnsyncDto>(t)).ToList();
            }
        }

        public void ModifyState(string id, FaceWorkerState state, string errorCode)
        {
            using (var dataContext = DataContext)
            {
                var faceDeviceWorker = dataContext.FaceDeviceWorkers.First(t => t.Id == id);
                faceDeviceWorker.Status = (int) state;
                faceDeviceWorker.ErrorCode = errorCode;
                faceDeviceWorker.ModifiedTime = DateTime.Now;
                dataContext.SubmitChanges();
            }
        }
    }
}