using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.Infrastructure.Serialization
{
    public static class EnumSerializationExtension
    {
        /// <summary>
        /// 扩展方法，获得枚举的Description
        /// </summary>
        /// <param name="value">枚举值</param>
        /// <param name="nameInstend">当枚举没有定义DescriptionAttribute,是否用枚举名代替，默认使用</param>
        /// <returns>枚举的Description</returns>
        public static string GetDescription(this Enum value, bool nameInstend = true)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name == null)
            {
                return null;
            }
            FieldInfo field = type.GetField(name);
            DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            if (attribute == null && nameInstend == true)
            {
                return name;
            }
            return attribute == null ? null : attribute.Description;
        }

        public static string ToEnumText<T>(this T enumValue)
        {
            var value = enumValue.ToString();
            var field = enumValue.GetType().GetField(value);
            var objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false); //获取描述属性
            if (objs.Length == 0) //当描述属性没有时，直接返回名称
                return value;
            var descriptionAttribute = (DescriptionAttribute) objs[0];
            return descriptionAttribute.Description;
        }

        /// <summary>
        ///     获取枚举所有值和描述
        ///     new Enum1().GetDescriptions(); or Enum1.Attribute1.GetDescriptions();
        /// </summary>
        /// <returns></returns>
        public static IList<DicKeyValueDto> GetDescriptions<T>(this T enumValue)
        {
            var enumType = enumValue.GetType();
            IList<DicKeyValueDto> valueDescriptions = new List<DicKeyValueDto>();
            //var valueDescriptions = new Dictionary<int, string>();
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
    }
}