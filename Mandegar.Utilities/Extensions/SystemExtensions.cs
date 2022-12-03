using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mandegar.Utilities.Extensions
{
    public static class SystemExtensions
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
        public static string BoolToString(this bool value)
        {
            return value ? "true" : "false";
        }

        public static string ObjectToQueryString(this object value)
        {
            var properties = from p in value.GetType().GetProperties()
                             where p.GetValue(value, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(value, null).ToString());

            return String.Join("&", properties.ToArray());
        }

        public static string FirstCharacterToLowercase(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return value;

            return value.Substring(0, 1).ToLower() + value.Substring(1);
        }

        public static bool ToBoolean(this string value)
        {
            return bool.TryParse(value, out _);
        }

        public static int ToInt(this string value)
        {
            var result = 0;
            int.TryParse(value, out result);
            return result;
        }
    }

}
