using System.Linq;
using KtpAcsMiddleware.Domain.Data;

namespace KtpAcsMiddleware.Domain.Workers
{
    /// <summary>
    ///     独立的身份证信息数据服务类(服务于身份证信用分)
    /// </summary>
    public class WorkerIdentityDataService
    {
        public WorkerIdentity FindByCode(string code)
        {
            return UnitOfWork.DataContext.WorkerIdentities.FirstOrDefault(t => t.Code == code);
        }

        public void ModifyCreditGrade(string identityId, decimal creditGrade)
        {
            using (var dataContext = UnitOfWork.DataContext)
            {
                var identity = dataContext.WorkerIdentities.First(t => t.Id == identityId);
                identity.CreditGrade = creditGrade;
                dataContext.SubmitChanges();
            }
        }
    }
}