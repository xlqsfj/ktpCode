using System;
using System.Runtime.Serialization;

namespace KtpAcsMiddleware.Infrastructure.Exceptions
{
    public class NonUniqueException : Exception
    {
        public NonUniqueException()
        {
        }

        public NonUniqueException(string message) : base(message)
        {
        }

        public NonUniqueException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NonUniqueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}