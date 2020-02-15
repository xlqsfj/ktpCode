using System.Threading;
using System.Web;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.Domain.Data
{
    public static class DataContextFactory
    {
        private const string DataContextKey = "KtpAcsMiddlewareDataContext";

        public static KtpAcsMiddlewareDataContext CreateDataContext()
        {
            var connectionString = ConfigHelper.Conn;

            var httpContext = HttpContext.Current;
            if (httpContext != null)
            {
                if (httpContext.Items[DataContextKey] == null)
                {
                    httpContext.Items[DataContextKey] = new KtpAcsMiddlewareDataContext(connectionString);
                }

                return httpContext.Items[DataContextKey] as KtpAcsMiddlewareDataContext;
            }

            var localDataStoreSlot = Thread.GetNamedDataSlot(DataContextKey);

            var dataContext = Thread.GetData(localDataStoreSlot);

            if (dataContext == null)
            {
                dataContext = new KtpAcsMiddlewareDataContext(connectionString);

                Thread.SetData(localDataStoreSlot, dataContext);
            }

            return dataContext as KtpAcsMiddlewareDataContext;
        }
    }
}