using System.Linq;
using KtpAcsMiddleware.Infrastructure.Serialization;

namespace KtpAcsMiddleware.Domain.Workers
{
    /// <summary>
    /// 查询民族的信息
    /// </summary>
    public class IdentityNationService
    {
        public static string GetText(int value)
        {
            return ((IdentityNation) value).ToEnumText();
        }

        public static string GetText(IdentityNation value)
        {
            return value.ToEnumText();
        }

        public static int GetNotNullValue(string text)
        {
            var nationValue = GetValue(text);
            if (nationValue == null)
            {
                return (int) IdentityNation.Wu;
            }
            return nationValue.Value;
        }

        public static int? GetValue(string text)
        {
            var nation = IdentityNation.Wu.GetDescriptions()
                .FirstOrDefault(i => i.Value.Contains(text));
            if (nation == null)
            {
                return null;
            }
            return nation.Key;
        }
    }
}