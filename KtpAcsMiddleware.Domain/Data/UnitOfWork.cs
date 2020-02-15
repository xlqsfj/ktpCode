using System;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.Domain.Data
{
    internal class UnitOfWork : IUnitOfWork
    {
        static UnitOfWork()
        {
            FactoryContext = DataContextFactory.CreateDataContext();
        }

        public static KtpAcsMiddlewareDataContext FactoryContext { get; }

        public static KtpAcsMiddlewareDataContext DataContext
        {
            get { return new KtpAcsMiddlewareDataContext(ConfigHelper.Conn); }
        }

        public void Commit()
        {
            FactoryContext.SubmitChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                FactoryContext.Dispose();
        }
    }
}