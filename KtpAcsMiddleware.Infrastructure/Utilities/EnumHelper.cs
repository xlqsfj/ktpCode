using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace KtpAcsMiddleware.Infrastructure.Utilities
{
    public class EnumHelper
    {
        /// <summary>
        ///     根据枚举值得到属性Description中的描述,如果没有定义此属性则返回空串
        /// </summary>
        /// <param name="value">数字型枚举值</param>
        /// <param name="enumType">枚举类型:typeof(枚举对象)</param>
        /// <returns>枚举值对应的Description中的描述</returns>
        public static string GetDescription(int value, Type enumType)
        {
            return GetAllValueDescriptions(enumType).First(i => i.Key == value).Value;
        }

        /// <summary>
        ///     根据枚举类型得到其所有的值与枚举定义Description属性的集合
        /// </summary>
        /// <param name="enumType">枚举类型:typeof(枚举对象)</param>
        /// <returns>枚举类型对应的所有的值与枚举定义Description属性的集合</returns>
        public static IList<DicKeyValueDto> GetAllValueDescriptions(Type enumType)
        {
            IList<DicKeyValueDto> valueDescriptions = new List<DicKeyValueDto>();
            var typeDescription = typeof(DescriptionAttribute);
            var fields = enumType.GetFields();
            foreach (var field in fields)
                if (field.FieldType.IsEnum)
                {
                    var strText = string.Empty;
                    var strValue = (int) enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null);
                    var arr = field.GetCustomAttributes(typeDescription, true);
                    if (arr.Length > 0)
                    {
                        var descriptionAttribute = (DescriptionAttribute) arr[0];
                        strText = descriptionAttribute.Description;
                    }
                    valueDescriptions.Add(new DicKeyValueDto
                    {
                        Key = strValue,
                        Value = strText
                    });
                }
            return valueDescriptions;
        }

        /// <summary>
        ///     根据枚举值得到相应的枚举定义字符串（属性名称）
        /// </summary>
        /// <param name="value">数字型枚举值</param>
        /// <param name="enumType">枚举类型:typeof(枚举对象)</param>
        /// <returns>枚举值对应的枚举定义字符串（属性名称）</returns>
        public static string GetAttribute(int value, Type enumType)
        {
            return GetAllValueAttributes(enumType).First(i => i.Key == value).Value;
        }

        /// <summary>
        ///     根据枚举类型得到其所有的值与枚举定义字符串（属性名称）的集合
        /// </summary>
        /// <param name="enumType">枚举类型:typeof(枚举对象)</param>
        /// <returns>枚举类型对应的所有的值与枚举定义字符串（属性名称）的集合</returns>
        public static IList<DicKeyValueDto> GetAllValueAttributes(Type enumType)
        {
            IList<DicKeyValueDto> valueAttributes = new List<DicKeyValueDto>();
            var fields = enumType.GetFields();
            foreach (var field in fields)
                if (field.FieldType.IsEnum)
                    valueAttributes.Add(new DicKeyValueDto
                    {
                        Key = (int) enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null),
                        Value = field.Name
                    });
            return valueAttributes;
        }
    }
}