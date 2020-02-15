using System;

namespace KtpAcsMiddleware.Infrastructure.Exceptions
{
    public class ExMessage
    {
        public static string Erro(string exMessage, string method)
        {
            if (string.IsNullOrEmpty(method))
                return $"has erro,ex.Message={exMessage}";
            return $"{method} erro,ex.Message={exMessage}";
        }

        public static string Exception(Exception ex, string method = null)
        {
            if (string.IsNullOrEmpty(method))
                return $"has exception,ex.Message={ex.Message},ex.StackTrace={ex.StackTrace}";
            return $"{method} exception,ex.Message={ex.Message},ex.StackTrace={ex.StackTrace}";
        }

        /// <summary>
        ///     ArgumentOutOfRangeException
        /// </summary>
        public static string MustBeGreaterThanOrEqualToZero(string name, object value)
        {
            return $"{name} must be greater than or equal to 0,value={value}";
        }

        /// <summary>
        ///     ArgumentOutOfRangeException
        /// </summary>
        public static string MustBeGreaterThanZero(string name, object value)
        {
            return $"{name} must be greater than 0,value={value}";
        }

        /// <summary>
        ///     ArgumentOutOfRangeException
        /// </summary>
        public static string MustNotBeOutOfRange(string name, object value)
        {
            return $"{name} must not be out of range,value={value}";
        }

        /// <summary>
        ///     ArgumentNullException
        /// </summary>
        public static string MustNotBeNull(string name)
        {
            return $"{name} must not be null";
        }

        /// <summary>
        ///     ArgumentNullException
        /// </summary>
        public static string MustNotBeNullOrEmpty(string name)
        {
            return $"{name} must not be null or empty";
        }

        /// <summary>
        ///     NotFoundException
        /// </summary>
        public static string NotFound(string name, string msg = null)
        {
            if (msg == null)
            {
                return $"Not found {name}";
            }
            return $"Not found {name}.{msg}";
        }
    }
}