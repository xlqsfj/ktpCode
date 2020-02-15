namespace KtpAcsMiddleware.Domain.Data
{
    public abstract class AbstractRepository
    {
        protected AbstractRepository()
        {
            FactoryContext = UnitOfWork.FactoryContext;
        }

        protected KtpAcsMiddlewareDataContext FactoryContext { get; }

        protected KtpAcsMiddlewareDataContext DataContext
        {
            get { return UnitOfWork.DataContext; }
        }
    }
}