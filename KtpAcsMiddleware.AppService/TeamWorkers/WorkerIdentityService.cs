using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.Workers;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.AppService.TeamWorkers
{
    internal class WorkerIdentityService : IWorkerIdentityService
    {
        private readonly IWorkerIdentityRepository _repository;

        public WorkerIdentityService(IWorkerIdentityRepository repository)
        {
            _repository = repository;
        }

        public WorkerIdentity ReaderAdd(IdentitySynDto dto)
        {
            var newIdentity = new WorkerIdentity
            {
                CreateType = (int) WorkerIdentityCreateType.Reader,
                Code = dto.CardNo,
                Name = dto.NameA,
                Sex = dto.Sex == 1 ? (int) WorkerSex.Man : (int) WorkerSex.Lady,
                Nation = dto.Nation,
                Birthday = FormatHelper.GetNonNullNumDateValue(dto.Born),
                Address = dto.Address,
                IssuingAuthority = dto.Police,
                ActivateTime = FormatHelper.GetNonNullNumDateValue(dto.UserLifeB),
                //InvalidTime = FormatHelper.GetNonNullNumDateValueNotErro(dto.UserLifeE),
                Base64Photo = dto.Base64Photo
            };
            if (dto.UserLifeE.Trim() == "长期")
            {
                newIdentity.InvalidTime = newIdentity.ActivateTime.AddYears(50);
            }
            else
            {
                newIdentity.InvalidTime = FormatHelper.GetNonNullNumDateValue(dto.UserLifeE);
            }
            var identity = _repository.FindByCode(newIdentity.Code);
            if (identity == null)
            {
                _repository.Add(newIdentity);
            }
            else
            {
                _repository.Modify(identity.Id, newIdentity);
            }
            return newIdentity;
        }

        public WorkerIdentity Add(WorkerIdentity dto)
        {
            _repository.Add(dto);
            return dto;
        }
    }
}