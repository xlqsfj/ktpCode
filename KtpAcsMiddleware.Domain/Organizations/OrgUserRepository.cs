using System;
using System.Linq;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Search.Extensions;
using KtpAcsMiddleware.Infrastructure.Search.Paging;

namespace KtpAcsMiddleware.Domain.Organizations
{
    internal class OrgUserRepository : AbstractRepository, IOrgUserRepository
    {
        public OrgUser Find(string id)
        {
            return DataContext.OrgUsers.First(t => t.Id == id);
        }

        public OrgUser FindByAccount(string loginName)
        {
            using (var dataContext = DataContext)
            {
                return dataContext.OrgUsers.FirstOrDefault(t => t.Account == loginName);
            }
        }

        public OrgUser FindByCode(string code)
        {
            return DataContext.OrgUsers.FirstOrDefault(t => t.Code == code);
        }

        public bool AnyLoginName(string loginName, string excludedId)
        {
            if (!string.IsNullOrEmpty(excludedId))
                return DataContext.OrgUsers.Any(t => t.Account == loginName && t.Id != excludedId);
            return DataContext.OrgUsers.Any(t => t.Account == loginName);
        }

        public bool AnyCode(string code, string excludedId)
        {
            if (!string.IsNullOrEmpty(excludedId))
                return DataContext.OrgUsers.Any(t => t.Code == code && t.Id != excludedId);
            return DataContext.OrgUsers.Any(t => t.Code == code);
        }

        public PagedResult<OrgUser> FindPaged(SearchCriteria<OrgUser> searchCriteria)
        {
            var count = DataContext.OrgUsers.FilterBy(searchCriteria.FilterCriterias).Count();
            var entities = DataContext.OrgUsers.SearchBy(searchCriteria);
            return new PagedResult<OrgUser>(count, entities);
        }

        public void Add(OrgUser dto)
        {
            dto.CreateTime = dto.ModifiedTime = DateTime.Now;
            using (var dataContext = DataContext)
            {
                dataContext.OrgUsers.InsertOnSubmit(dto);
                dataContext.SubmitChanges();
            }
        }

        public void Modify(OrgUser dto, string id)
        {
            using (var dataContext = DataContext)
            {
                var user = dataContext.OrgUsers.First(t => t.Id == id);
                user.Code = dto.Code;
                user.Name = dto.Name;
                user.Account = dto.Account;
                user.Mobile = dto.Mobile;
                user.Mail = dto.Mail;
                user.Birthday = dto.Birthday;
                user.Status = dto.Status;
                user.ModifiedTime = DateTime.Now;
                dataContext.SubmitChanges();
            }
        }

        public void ModifyPassword(string id, string password)
        {
            using (var dataContext = DataContext)
            {
                var user = dataContext.OrgUsers.First(t => t.Id == id);
                user.Password = password;
                user.ModifiedTime = DateTime.Now;
                dataContext.SubmitChanges();
            }
        }

        public void ModifyState(string id, OrgUserState state)
        {
            using (var dataContext = DataContext)
            {
                var user = dataContext.OrgUsers.First(t => t.Id == id);
                user.Status = (int) state;
                user.ModifiedTime = DateTime.Now;
                dataContext.SubmitChanges();
            }
        }
    }
}