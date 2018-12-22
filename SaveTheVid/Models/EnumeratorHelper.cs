using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace SaveTheVid.Models
{
    static class EnumeratorHelper
    {
        public static string GetDescription(this Enum value)
        {
            var attributes = value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Any())
                return (attributes.First() as DescriptionAttribute).Description;

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return value.ToString();
        }

        public static IEnumerable<KeyValuePair<Enum, string>> GetAll(Type type)
        {
            if (!type.IsEnum)
                throw new ArgumentException("Must be an enum type.");

            return createPairs(type);
        }



        private static List<KeyValuePair<Enum, string>> createPairs(Type type)
        {
            List<KeyValuePair<Enum, string>> collection = new List<KeyValuePair<Enum, string>>();
            foreach (Enum e in Enum.GetValues(type).Cast<Enum>())
            {
                KeyValuePair<Enum, string> pair = new KeyValuePair<Enum, string>(e, e.GetDescription());
                collection.Add(pair);
            }
            return collection;
        }

    }
}
