using System;
using System.Collections.Generic;
using System.Linq;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Search.Extensions;

namespace KtpAcsMiddleware.Domain.FaceRecognition
{
    internal class FaceDeviceRepository : AbstractRepository, IFaceDeviceRepository
    {
        public FaceDevice First(string id)
        {
            return DataContext.FaceDevices.First(t => t.Id == id);
        }

        public FaceDevice FirstOrDefault(SearchCriteria<FaceDevice> searchCriteria)
        {
            return DataContext.FaceDevices.SearchBy(searchCriteria).FirstOrDefault();
        }

        public bool Any(string code, string excludedId)
        {
            if (string.IsNullOrEmpty(excludedId))
            {
                return DataContext.FaceDevices.Any(t => t.Code == code && t.IsDelete == false);
            }
            return DataContext.FaceDevices.Any(t => t.Code == code && t.Id != excludedId && t.IsDelete == false);
        }

        public IList<FaceDevice> FindAll()
        {
            return DataContext.FaceDevices.Where(t => t.IsDelete == false).ToList();
        }

        public void Add(FaceDevice dto)
        {
            using (var dataContext = DataContext)
            {
                dataContext.FaceDevices.InsertOnSubmit(dto);
                dataContext.SubmitChanges();
            }
        }

        public void Modify(FaceDevice dto, string deviceId)
        {
            using (var dataContext = DataContext)
            {
                var device = dataContext.FaceDevices.First(t => t.Id == deviceId);
                device.Code = dto.Code;
                device.IpAddress = dto.IpAddress;
                device.IsCheckIn = dto.IsCheckIn;
                device.Description = dto.Description;
                device.ModifiedTime = DateTime.Now;
                dataContext.SubmitChanges();
            }
        }

        public void ModifyIpAddress(string deviceId, string ipAddress)
        {
            using (var dataContext = DataContext)
            {
                var device = dataContext.FaceDevices.First(t => t.Id == deviceId);
                device.IpAddress = ipAddress;
                device.ModifiedTime = DateTime.Now;
                dataContext.SubmitChanges();
            }
        }

        public void Delete(string deviceId)
        {
            using (var dataContext = DataContext)
            {
                var faceDeviceWorkerIds = dataContext.FaceDeviceWorkers.Where(
                    t => t.DeviceId == deviceId && t.IsDelete == false).Select(t => t.Id).ToArray();
                var device = dataContext.FaceDevices.First(t => t.Id == deviceId);
                device.IsDelete = true;
                //被删除的设备用最后更新时间来记录删除时间
                device.ModifiedTime = DateTime.Now;
                foreach (var faceDeviceWorkerId in faceDeviceWorkerIds)
                {
                    var deviceWorker = dataContext.FaceDeviceWorkers.First(t => t.Id == faceDeviceWorkerId);
                    //deviceWorker.IsDelete = true;
                    deviceWorker.Status = (int) FaceWorkerState.NewDel;
                }
                dataContext.SubmitChanges();
            }
        }

        public void AddAllWorkers(string deviceId)
        {
            using (var dataContext = DataContext)
            {
                var workerIds = dataContext.Workers.Where(t => t.IsDelete == false).Select(t => t.Id).ToArray();
                if (workerIds.Length == 0)
                {
                    return;
                }
                var deviceWorkers = dataContext.FaceDeviceWorkers.Where(
                    t => t.IsDelete == false && t.DeviceId == deviceId && workerIds.Contains(t.WorkerId)).ToArray();
                foreach (var workerId in workerIds)
                {
                    var faceDeviceWorker = deviceWorkers.FirstOrDefault(i => i.WorkerId == workerId);
                    if (faceDeviceWorker == null)
                    {
                        faceDeviceWorker = FaceDeviceWorkerEntityService.Create(deviceId, workerId);
                        dataContext.FaceDeviceWorkers.InsertOnSubmit(faceDeviceWorker);
                        continue;
                    }
                    if (faceDeviceWorker.Status > (int) FaceWorkerState.RepeatAdd)
                    {
                        var deviceWorker = dataContext.FaceDeviceWorkers.First(t => t.Id == faceDeviceWorker.Id);
                        deviceWorker.Status = (int) FaceWorkerState.New;
                        deviceWorker.ErrorCode = null;
                    }
                }
                dataContext.SubmitChanges();
            }
        }
    }
}