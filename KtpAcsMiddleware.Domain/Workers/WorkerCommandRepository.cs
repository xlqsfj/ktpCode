using System;
using System.Collections.Generic;
using System.Linq;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.FaceRecognition;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.Domain.Workers
{
    internal class WorkerCommandRepository : AbstractRepository, IWorkerCommandRepository
    {
        public void Add(Worker dto)
        {
            if (string.IsNullOrEmpty(dto.Id))
            {
                dto.Id = ConfigHelper.NewGuid;
            }
            dto.CreateTime = DateTime.Now;
            dto.ModifiedTime = DateTime.Now;
            dto.IsDelete = false;
            using (var dataContext = DataContext)
            {
                dataContext.Workers.InsertOnSubmit(dto);
                dataContext.SubmitChanges();
            }
        }

        public void ModifySimple(Worker dto, string id)
        {
            var isModifyFacePicId = false;
            using (var dataContext = DataContext)
            {
                var worker = dataContext.Workers.First(t => t.Id == id);
                if (worker.TeamId != dto.TeamId)
                {
                    //改变班组则需要添加历史数据添加历史数据
                    var newHistoryWorker = new Worker
                    {
                        Id = $"{worker.Id}_{DateTime.Now:yyyyMMddHHmmss}",
                        IdentityId = worker.IdentityId,
                        TeamId = worker.TeamId,
                        InTime = worker.InTime,
                        OutTime = DateTime.Now,
                        Name = worker.Name,
                        Mobile = worker.Mobile,
                        Status = worker.Status,
                        IdentityFaceSim = worker.IdentityFaceSim,
                        AddressNow = worker.AddressNow,
                        ContractPicId = worker.ContractPicId,
                        FacePicId = worker.FacePicId,
                        CreatorId = worker.CreatorId,
                        CreateTime = worker.CreateTime,
                        ModifiedTime = worker.ModifiedTime,
                        IsDelete = true
                    };
                    dataContext.Workers.InsertOnSubmit(newHistoryWorker);
                    worker.InTime = DateTime.Now;
                }
                worker.TeamId = dto.TeamId;
                worker.Mobile = dto.Mobile;
                worker.Name = dto.Name;
                worker.IdentityId = dto.IdentityId;
                worker.AddressNow = dto.AddressNow;
                if (!string.IsNullOrEmpty(dto.FacePicId))
                {
                    if (worker.FacePicId != dto.FacePicId)
                    {
                        worker.FacePicId = dto.FacePicId;
                        isModifyFacePicId = true;
                    }
                }
                worker.ModifiedTime = DateTime.Now;
                dataContext.SubmitChanges();
            }
            if (isModifyFacePicId)
            {
                //更新人脸数据，则从所有设备中删除原有数据，删除完成后再重新添加(重新添加逻辑在删除完成后api处理)
                ModifyFaceDevicesStateNewDel(id);
                FaceDeviceWorkerEntityService.SendAllDeviceSyncFaceLibrary();
            }
        }

        public void ModifyIdentityAuth(
            string workerId, string facePicId, string identityPicId, string identityBackPicId)
        {
            var isModifyFacePicId = false;
            using (var dataContext = DataContext)
            {
                var worker = dataContext.Workers.First(t => t.Id == workerId);
                if (!string.IsNullOrEmpty(facePicId))
                {
                    isModifyFacePicId = true;
                    worker.FacePicId = facePicId;
                }
                if (!string.IsNullOrEmpty(identityPicId))
                {
                    worker.WorkerIdentity.PicId = identityPicId;
                }
                if (!string.IsNullOrEmpty(identityBackPicId))
                {
                    worker.WorkerIdentity.BackPicId = identityBackPicId;
                }
                worker.ModifiedTime = DateTime.Now;
                if (worker.WorkerSync != null)
                {
                    worker.WorkerSync.Status = (int) KtpSyncState.NewEdit;
                }
                dataContext.SubmitChanges();
            }
            if (isModifyFacePicId)
            {
                //更新人脸数据，则从所有设备中删除原有数据，删除完成后再重新添加(重新添加逻辑在删除完成后api处理)
                ModifyFaceDevicesStateNewDel(workerId);
                FaceDeviceWorkerEntityService.SendAllDeviceSyncFaceLibrary();
            }
        }

        public void ModifyTeamId(string workerId, string teamId)
        {
            using (var dataContext = DataContext)
            {
                var worker = dataContext.Workers.First(t => t.Id == workerId);
                //改变班组则需要添加历史数据添加历史数据
                var newHistoryWorker = new Worker
                {
                    Id = $"{worker.Id}_{DateTime.Now:yyyyMMddHHmmss}",
                    IdentityId = worker.IdentityId,
                    TeamId = worker.TeamId,
                    InTime = worker.InTime,
                    OutTime = DateTime.Now,
                    Name = worker.Name,
                    Mobile = worker.Mobile,
                    Status = worker.Status,
                    IdentityFaceSim = worker.IdentityFaceSim,
                    AddressNow = worker.AddressNow,
                    ContractPicId = worker.ContractPicId,
                    FacePicId = worker.FacePicId,
                    CreatorId = worker.CreatorId,
                    CreateTime = worker.CreateTime,
                    ModifiedTime = worker.ModifiedTime,
                    IsDelete = true
                };
                dataContext.Workers.InsertOnSubmit(newHistoryWorker);
                worker.InTime = DateTime.Now;
                worker.TeamId = teamId;
                worker.ModifiedTime = DateTime.Now;
                //更改开太平同步状态
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
                dataContext.SubmitChanges();
            }
        }

        public void Delete(string workerId, WorkerSync sync = null)
        {
            using (var dataContext = DataContext)
            {
                //删除工人、修改同步状态到新删除
                var woker = dataContext.Workers.First(t => t.Id == workerId);
                woker.IsDelete = true;
                woker.ModifiedTime = DateTime.Now;
                if (woker.WorkerSync != null)
                {
                    if (sync == null)
                    {
                        if (woker.WorkerSync.TeamThirdPartyId > 0)
                        {
                            woker.WorkerSync.Status = (int) KtpSyncState.NewDel;
                        }
                        else
                        {
                            woker.WorkerSync.Status = (int) KtpSyncState.Ignore;
                        }
                    }
                    else
                    {
                        woker.WorkerSync.Type = sync.Type;
                        woker.WorkerSync.Status = sync.Status;
                    }
                }
                else
                {
                    if (sync != null)
                    {
                        woker.WorkerSync = sync;
                    }
                }
                //从所有设备中删除该工人
                var faceDeviceIds = dataContext.FaceDevices.Where(t => t.IsDelete == false).Select(t => t.Id).ToArray();
                var faceDeviceWorkerIds = dataContext.FaceDeviceWorkers.Where(
                    t => t.WorkerId == workerId && faceDeviceIds.Contains(t.DeviceId)).Select(t => t.Id).ToArray();
                if (faceDeviceWorkerIds.Length > 0)
                {
                    foreach (var deviceWorkerId in faceDeviceWorkerIds)
                    {
                        var deviceWorker = dataContext.FaceDeviceWorkers.First(t => t.Id == deviceWorkerId);
                        deviceWorker.IsDelete = true;
                        if (deviceWorker.Status == (int) FaceWorkerState.New)
                        {
                            deviceWorker.Status = (int) FaceWorkerState.HasDel;
                        }
                        else if (deviceWorker.Status != (int) FaceWorkerState.PrepareDel &&
                                 deviceWorker.Status != (int) FaceWorkerState.HasDel)
                        {
                            deviceWorker.Status = (int) FaceWorkerState.NewDel;
                        }
                    }
                }
                //提交修改
                dataContext.SubmitChanges();
            }
        }
     
        /// <summary>
        ///     设置当前工人在所有设备的状态为新删除
        ///     更新人脸数据，则从所有设备中删除原有数据，删除完成后再重新添加(重新添加逻辑在删除完成后api处理)
        /// </summary>
        public void ModifyFaceDevicesStateNewDel(string workerId)
        {
            IList<FaceDeviceWorker> deviceWorkers;
            using (var dataContext = DataContext)
            {
                var worker = dataContext.Workers.First(t => t.Id == workerId);
                if (string.IsNullOrEmpty(worker.FacePicId))
                {
                    return;
                }
                deviceWorkers = dataContext.FaceDeviceWorkers.Where(
                    t => t.IsDelete == false && t.WorkerId == workerId && t.FaceDevice.IsDelete == false).ToArray();
                if (deviceWorkers.Count == 0)
                {
                    return;
                }
                foreach (var faceDeviceWorker in deviceWorkers)
                {
                    if (faceDeviceWorker == null)
                    {
                        continue;
                    }
                    if (faceDeviceWorker.Status != (int) FaceWorkerState.NewDel ||
                        faceDeviceWorker.Status != (int) FaceWorkerState.PrepareDel ||
                        faceDeviceWorker.Status != (int) FaceWorkerState.HasDel)
                    {
                        var deviceWorker = dataContext.FaceDeviceWorkers.First(t => t.Id == faceDeviceWorker.Id);
                        deviceWorker.Status = (int) FaceWorkerState.NewDel;
                        deviceWorker.ErrorCode = null;
                    }
                }
                dataContext.SubmitChanges();
            }
        }

   

        public void AddToAllFaceDevice(string workerId)
        {
            IList<string> faceDeviceIds;
            using (var dataContext = DataContext)
            {
                var worker = dataContext.Workers.First(t => t.Id == workerId);
                if (string.IsNullOrEmpty(worker.FacePicId))
                {
                    return;
                }
                //查询所有设备列表
                faceDeviceIds = dataContext.FaceDevices.Where(t => t.IsDelete == false).Select(t => t.Id).ToList();
                if (faceDeviceIds.Count == 0)
                {
                    return;
                }
                //查询这个是否未删除并且存在设备
                var deviceWorkers = dataContext.FaceDeviceWorkers.Where(
                        t => t.IsDelete == false && t.WorkerId == workerId &&
                             faceDeviceIds.ToArray().Contains(t.DeviceId))
                    .ToArray();
                foreach (var deviceId in faceDeviceIds)
                {
                    var faceDeviceWorker = deviceWorkers.FirstOrDefault(i => i.DeviceId == deviceId);
                    if (faceDeviceWorker == null)
                    {//如果不存在创建
                        faceDeviceWorker = FaceDeviceWorkerEntityService.Create(deviceId, workerId);
                        dataContext.FaceDeviceWorkers.InsertOnSubmit(faceDeviceWorker);
                        continue;
                    }
                    if (faceDeviceWorker.Status > (int)FaceWorkerState.RepeatAdd )
                    {
                        var deviceWorker = dataContext.FaceDeviceWorkers.First(t => t.Id == faceDeviceWorker.Id);
                        deviceWorker.Status = (int)FaceWorkerState.New;
                        deviceWorker.ErrorCode = null;
                    }
                }
                dataContext.SubmitChanges();
            }
        }
    }
}