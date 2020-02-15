
using System;
using System.Runtime.Serialization;

namespace KtpAcsMiddleware.Infrastructure.Exceptions
{
    public class NotFoundException : Exception
    {
        //demo
        //Item item = _itemService.Get(id);
        //if (item == null)
        //{
        //    throw new NotFoundException(string.Format("Not found item. Id: {0}", id));
        //}
        public NotFoundException()
        {
        }

        public NotFoundException(string message) : base(message)
        {
           
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}