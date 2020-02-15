using System.Linq;
using KtpAcsMiddleware.Infrastructure.Serialization;

namespace KtpAcsMiddleware.Domain.KtpLibrary
{
    public class KtpSyncTypeService
    {
        public static int GetNotNullValue(string text)
        {
            var value = GetValue(text);
            if (value == null)
            {
                return -1;
            }
            return value.Value;
        }

        public static int? GetValue(string text)
        {
            var value = KtpSyncType.PushAdd.GetDescriptions()
                .FirstOrDefault(i => i.Value.Contains(text));
            if (value == null)
            {
                return null;
            }
            return value.Key;
        }
    }
}