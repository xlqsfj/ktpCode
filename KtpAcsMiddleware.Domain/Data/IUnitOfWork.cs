namespace KtpAcsMiddleware.Domain.Data
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}