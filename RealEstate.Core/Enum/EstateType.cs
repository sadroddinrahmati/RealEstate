using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RealEstate.Core.Enum
{
    public static class EnumTypes
    {
        public enum EstateType
        {
            [Description("شمالی")]
            Northern = 1,

            [Description("جنوبی")]
            Southern = 2
        }
        public static string GetDescription(System.Enum value)
        {
            var description = "";
            var type = value.GetType();
            var name = System.Enum.GetName(type, value);
            var field = type.GetField(name);
            var fds = field.GetCustomAttributes(typeof(DescriptionAttribute), true);
            foreach (DescriptionAttribute fd in fds)
            {
                description = fd.Description;
            }

            return description;
        }

        public static List<KeyValuePair<string, int>> GetEnumValuesAndDescriptions<T>()
        {
            Type enumType = typeof(T);

            if (enumType.BaseType != typeof(System.Enum))
                throw new ArgumentException("T is not System.Enum");

            List<KeyValuePair<string, int>> enumValList = new List<KeyValuePair<string, int>>();

            foreach (var e in System.Enum.GetValues(typeof(T)))
            {
                var fi = e.GetType().GetField(e.ToString());
                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                enumValList.Add(new KeyValuePair<string, int>((attributes.Length > 0) ? attributes[0].Description : e.ToString(), (int)e));
            }

            return enumValList;
        } 
    }
}
