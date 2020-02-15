using System;
using System.Collections.Generic;
using System.Linq;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.Organizations;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Search.Paging;
using KtpAcsMiddleware.Infrastructure.Search.Sort;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.AppService.Organizations
{
    internal class OrgUserService : IOrgUserService
    {
        private readonly IOrgUserRepository _userRepository;

        public OrgUserService(IOrgUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public OrgUser Get(string userId)
        {
            return _userRepository.Find(userId);
        }

        public OrgUser GetByAccount(string loginName)
        {
            return _userRepository.FindByAccount(loginName);
        }

        public bool AnyLoginName(string loginName, string excludedId)
        {
            if (string.IsNullOrEmpty(loginName))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(loginName)));
            }
            return _userRepository.AnyLoginName(loginName, excludedId);
        }

        public bool AnyCode(string code, string excludedId)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(code)));
            }
            return _userRepository.AnyCode(code, excludedId);
        }

        public PagedResult<OrgUserPagedDto> GetPaged(int pageIndex, int pageSize, int? userStatus, string keywords)
        {
            var searchCriteria = new SearchCriteria<OrgUser>();
            if (userStatus != null)
            {
                searchCriteria.AddFilterCriteria(t => t.Status == userStatus);
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                searchCriteria.AddFilterCriteria(t => t.Name.Contains(keywords) ||
                                                      t.Account.Contains(keywords) ||
                                                      t.Code.Contains(keywords) ||
                                                      t.Mobile.Contains(keywords));
            }
            //排除admin
            searchCriteria.AddFilterCriteria(t => t.Code != "adminitrator");
            searchCriteria.AddSortCriteria(
                new ExpressionSortCriteria<OrgUser, string>(s => s.Name, SortDirection.Ascending));
            searchCriteria.AddSortCriteria(
                new ExpressionSortCriteria<OrgUser, DateTime>(s => s.CreateTime, SortDirection.Descending));
            searchCriteria.PagingCriteria = new PagingCriteria(pageIndex, pageSize);
            var pagedResult = _userRepository.FindPaged(searchCriteria);
            IList<OrgUserPagedDto> users = pagedResult.Entities.Select(t => new OrgUserPagedDto
            {
                Id = t.Id,
                LoginName = t.Account,
                Name = t.Name,
                Mail = t.Mail,
                Mobile = t.Mobile,
                Birthday = t.Birthday,
                CreateTime = t.CreateTime,
                ModifiedTime = t.ModifiedTime
            }).ToList();
            return new PagedResult<OrgUserPagedDto>(pagedResult.Count, users);
        }

        public string AddUser(OrgUser dto)
        {
            var user = _userRepository.FindByAccount(dto.Account);
            if (user != null)
            {
                throw new NonUniqueException($"user account must be unique,account={dto.Account}");
            }
            user = _userRepository.FindByCode(dto.Code);
            if (user != null)
            {
                throw new NonUniqueException($"user code must be unique,code={dto.Code}");
            }
            dto.Id = ConfigHelper.NewGuid;
            dto.Password = CryptographicHelper.Hash(ConfigHelper.DefaultUserPwd);
            dto.Status = (int) OrgUserState.Normal;
            if (string.IsNullOrEmpty(dto.Code))
            {
                dto.Code = ConfigHelper.CurrentTimeNumberfff;
            }
            _userRepository.Add(dto);
            return dto.Id;
        }

        public void ChangeUser(OrgUser dto)
        {
            if (string.IsNullOrEmpty(dto.Id))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(dto.Id)));
            }
            var user = _userRepository.FindByAccount(dto.Account);
            if (user != null && user.Id != dto.Id)
            {
                throw new NonUniqueException($"user account must be unique,account={dto.Account}");
            }
            user = _userRepository.FindByCode(dto.Code);
            if (user != null && user.Id != dto.Id)
            {
                throw new NonUniqueException($"user code must be unique,code={dto.Code}");
            }
            _userRepository.Modify(dto, dto.Id);
        }

        public void ChangeUserPassword(string id, string password)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(id)));
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(password)));
            }
            _userRepository.ModifyPassword(id, CryptographicHelper.Hash(password));
        }

        public void CancleUser(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(id)));
            }
            _userRepository.ModifyState(id, OrgUserState.Cancle);
        }

        public void ReactivationUser(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception(ExMessage.MustNotBeNullOrEmpty(nameof(id)));
            }
            _userRepository.ModifyState(id, OrgUserState.Normal);
        }
    }
}