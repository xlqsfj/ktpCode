using System;
using System.Collections.Generic;
using System.Linq;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.Domain.Workers
{
    internal class WorkerIdentityRepository : AbstractRepository, IWorkerIdentityRepository
    {
        public WorkerIdentity FindByCode(string code)
        {
            return DataContext.WorkerIdentities.FirstOrDefault(t => t.Code == code);
        }

        public IList<WorkerIdentity> FindAll()
        {
            return DataContext.WorkerIdentities.Where(t => t.IsDelete != true).ToList();
        }

        public void Add(WorkerIdentity dto)
        {
            if (string.IsNullOrEmpty(dto.Id))
            {
                dto.Id = ConfigHelper.NewGuid;
            }
            dto.IsDelete = false;
            dto.CreateTime = DateTime.Now;
            dto.ModifiedTime = dto.CreateTime;
            using (var dataContext = DataContext)
            {
                dataContext.WorkerIdentities.InsertOnSubmit(dto);
                dataContext.SubmitChanges();
            }
        }

        public void Modify(string id, WorkerIdentity dto)
        {
            using (var dataContext = DataContext)
            {
                var identity = dataContext.WorkerIdentities.First(t => t.Id == id);
                //identity.Code = entity.Code;
                identity.Name = dto.Name;
                identity.Sex = dto.Sex;
                identity.Nation = dto.Nation;
                identity.Birthday = dto.Birthday;
                identity.Address = dto.Address;
                identity.IssuingAuthority = dto.IssuingAuthority;
                identity.ActivateTime = dto.ActivateTime;
                identity.InvalidTime = dto.InvalidTime;
                identity.Base64Photo = dto.Base64Photo;
                identity.ModifiedTime = DateTime.Now;
                if (identity.CreateType == (int) WorkerIdentityCreateType.Manual)
                {
                    identity.CreateType = dto.CreateType;
                }
                if (!string.IsNullOrEmpty(dto.PicId))
                {
                    identity.PicId = dto.PicId;
                }
                if (!string.IsNullOrEmpty(dto.BackPicId))
                {
                    identity.BackPicId = dto.BackPicId;
                }
                identity.ModifiedTime = DateTime.Now;
                dataContext.SubmitChanges();
            }
        }
    }
}