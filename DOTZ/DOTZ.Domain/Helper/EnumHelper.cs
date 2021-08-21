using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DOTZ.Domain.Helper
{
    public static class EnumHelper
    {

        public static T GetFieldType<T>(this Enum valorEnum) where T : System.Attribute
        {
            var type = valorEnum.GetType();
            var memInfo = type.GetMember(valorEnum.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }

        public static string GetDescription(this Enum valorEnum)
        {
            return valorEnum.GetFieldType<DescriptionAttribute>().Description;
        }
    }
}
