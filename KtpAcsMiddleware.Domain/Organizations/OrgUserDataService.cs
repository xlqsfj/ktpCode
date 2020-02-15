using System.Linq;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.Domain.Organizations
{
    public class OrgUserDataService
    {
        private readonly IOrgUserRepository _userRepository;

        public OrgUserDataService()
        {
            _userRepository = new OrgUserRepository();
        }

        public static OrgUser Find(string id)
        {
            return UnitOfWork.DataContext.OrgUsers.First(t => t.Id == id);
        }

        public static OrgUser FindAdmin()
        {
            return UnitOfWork.DataContext.OrgUsers.First(t => t.Account == "admin");
        }

        #region 初始化(Init层)使用

        public OrgUser FirstOrDefaultAdmin()
        {
            return UnitOfWork.DataContext.OrgUsers.FirstOrDefault(t => t.Account == "admin");
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
                dto.Code = dto.Id;
            }
            _userRepository.Add(dto);
            return dto.Id;
        }

        #endregion
    }
}