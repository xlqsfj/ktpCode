using System;
using System.Runtime.Serialization;

namespace KtpAcsMiddleware.Infrastructure.Exceptions
{
    /// <summary>
    ///     WebApiBadRequestException
    /// </summary>
    public class BadRequestException : Exception
    {
        //demo
        //if (id != item.Id)
        //{
        //    throw new BadRequestException("The Id field is invalid.");
        //}
        public BadRequestException()
        {
        }

        public BadRequestException(string message) : base(message)
        {
        }

        public BadRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BadRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}