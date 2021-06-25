using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ElectronicInvoice.API.Extensions
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            DescriptionAttribute descriptionAttribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))
                                                            as DescriptionAttribute;

            return descriptionAttribute != null ? descriptionAttribute.Description : value.ToString();
        }
    }
}
