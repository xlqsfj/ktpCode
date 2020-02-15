using System;
using System.Data.SqlClient;

namespace KtpAcsMiddleware.Domain.Data
{
    internal class EntityDataService
    {
        public static DateTime GetReaderValueTDateTimeNoNull(SqlDataReader reader, string key)
        {
            var value = GetReaderValue(reader, key);
            if (value == null)
            {
                return DateTime.MinValue;
            }
            return DateTime.Parse(value);
        }

        public static DateTime? GetReaderValueTDateTime(SqlDataReader reader, string key)
        {
            var value = GetReaderValue(reader, key);
            if (value == null)
            {
                return null;
            }
            return DateTime.Parse(value);
        }

        public static decimal GetReaderValueTDecimalNoNull(SqlDataReader reader, string key)
        {
            var value = GetReaderValue(reader, key);
            if (value == null)
            {
                return -1;
            }
            return decimal.Parse(value);
        }

        public static decimal? GetReaderValueTDecimal(SqlDataReader reader, string key)
        {
            var value = GetReaderValue(reader, key);
            if (value == null)
            {
                return null;
            }
            return decimal.Parse(value);
        }

        public static long GetReaderValueTLongNoNull(SqlDataReader reader, string key)
        {
            var value = GetReaderValue(reader, key);
            if (value == null)
            {
                return -1;
            }
            return long.Parse(value);
        }

        public static long? GetReaderValueTLong(SqlDataReader reader, string key)
        {
            var value = GetReaderValue(reader, key);
            if (value == null)
            {
                return null;
            }
            return long.Parse(value);
        }

        public static int GetReaderValueTIntNoNull(SqlDataReader reader, string key)
        {
            var value = GetReaderValue(reader, key);
            if (value == null)
            {
                return -1;
            }
            return int.Parse(value);
        }

        public static int? GetReaderValueTInt(SqlDataReader reader, string key)
        {
            var value = GetReaderValue(reader, key);
            if (value == null)
            {
                return null;
            }
            return int.Parse(value);
        }

        public static bool GetReaderValueTBoolNoNull(SqlDataReader reader, string key)
        {
            var value = GetReaderValue(reader, key);
            if (value == null)
            {
                return false;
            }
            return bool.Parse(value);
        }

        public static bool? GetReaderValueTBool(SqlDataReader reader, string key)
        {
            var value = GetReaderValue(reader, key);
            if (value == null)
            {
                return null;
            }
            return bool.Parse(value);
        }

        public static string GetNoNullReaderValue(SqlDataReader reader, string key)
        {
            var value = GetReaderValue(reader, key);
            if (value == null)
            {
                return string.Empty;
            }
            return value;
        }

        public static string GetReaderValue(SqlDataReader reader, string key)
        {
            var value = reader[key];
            if (value == null)
            {
                return null;
            }
            if (value != DBNull.Value)
            {
                return value.ToString();
            }
            return null;
        }
    }
}