using System;
using System.Runtime.Serialization;

namespace KtpAcsMiddleware.Infrastructure.Exceptions
{
    /// <summary>
    ///     前置验证异常对象
    /// </summary>
    public class PreValidationException : Exception
    {
        public PreValidationException()
        {
        }

        public PreValidationException(string message) : base(message)
        {
        }

        public PreValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PreValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}