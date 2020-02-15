using System;
using System.Collections.Generic;
using System.Linq;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.FaceRecognition;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Search.Extensions;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.Domain.Teams
{
    internal class TeamRepository : AbstractRepository, ITeamRepository
    {
        public Team Find(string id)
        {
            return DataContext.Teams.First(t => t.Id == id);
        }

        public IEnumerable<Team> FindAll()
        {
            return DataContext.Teams.Where(t => t.IsDelete == false && t.ProjectId == ConfigHelper.ProjectId);
        }

        public IEnumerable<Team> Find(SearchCriteria<Team> searchCriteria)
        {
            searchCriteria.AddFilterCriteria(t => t.IsDelete == false);
            return DataContext.Teams.SearchBy(searchCriteria);
        }

        public void Add(Team dto)
        {
            if (string.IsNullOrEmpty(dto.Id))
            {
                dto.Id = ConfigHelper.NewGuid;
            }
            var now = DateTime.Now;
            dto.IsDelete = false;
            dto.CreateTime = now;
            dto.ModifiedTime = now;
            using (var dataContext = DataContext)
            {
                dataContext.Teams.InsertOnSubmit(dto);
                dataContext.SubmitChanges();
            }
        }

        public void Modify(Team dto, string id)
        {
            using (var dataContext = DataContext)
            {
                var team = dataContext.Teams.First(t => t.Id == id);
                team.Name = dto.Name;
                team.WorkTypeId = dto.WorkTypeId;
                team.Description = dto.Description;
                team.ModifiedTime = DateTime.Now;
                if (team.TeamSync != null)
                {
                    if (team.TeamSync.ThirdPartyId > 0)
                    {
                        team.TeamSync.Status = (int) KtpSyncState.NewEdit;
                    }
                    else
                    {
                        team.TeamSync.Status = (int) KtpSyncState.NewAdd;
                    }
                }
                dataContext.SubmitChanges();
            }
        }

        public void ModifyLeaderId(string id, string newLeaderId)
        {
            using (var dataContext = DataContext)
            {
                var team = dataContext.Teams.First(t => t.Id == id);
                team.LeaderId = newLeaderId;
                team.ModifiedTime = DateTime.Now;
                if (team.TeamSync != null)
                {
                    if (team.TeamSync.ThirdPartyId > 0)
                    {
                        team.TeamSync.Status = (int) KtpSyncState.NewEdit;
                    }
                    else
                    {
                        team.TeamSync.Status = (int) KtpSyncState.NewAdd;
                    }
                }
                dataContext.SubmitChanges();
            }
        }

        public void Delete(string id)
        {
            using (var dataContext = DataContext)
            {
                var workerIds = dataContext.Workers.Where(
                    t => t.TeamId == id && t.IsDelete == false).Select(t => t.Id).ToList();
                var faceDeviceWorkerIds = dataContext.FaceDeviceWorkers.Where(
                    t => t.WorkerId == id && workerIds.Contains(t.WorkerId)
                         && t.IsDelete == false).Select(t => t.Id).ToArray();
                //删除班组
                var team = dataContext.Teams.First(t => t.Id == id);
                team.IsDelete = true;
                //标记同步状态为新删除
                if (team.TeamSync != null)
                {
                    team.TeamSync.Status = (int) KtpSyncState.NewDel;
                }
                //从设备中删除工人
                foreach (var deviceWorkerId in faceDeviceWorkerIds)
                {
                    var deviceWorker = dataContext.FaceDeviceWorkers.First(t => t.Id == deviceWorkerId);
                    deviceWorker.IsDelete = true;
                    deviceWorker.Status = (int) FaceWorkerState.NewDel;
                }
                //删除工人
                foreach (var workerId in workerIds)
                {
                    dataContext.Workers.First(t => t.Id == workerId).IsDelete = true;
                }
                dataContext.SubmitChanges();
            }
        }
    }
}