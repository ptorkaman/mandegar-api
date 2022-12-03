using System;
using System.Linq;

namespace Mandegar.Utilities.Extensions
{
    public static class IQueryableExtension
    {
        public static IQueryable<T> ToPagedList<T>(this IQueryable<T> source, int pageIndex = 1, int pageSize = 10, int? totalCount = null)
        {
            //min allowed page size is 1
            pageSize = Math.Max(pageSize, 1);


            var result = totalCount != null ? source : source.Skip((pageIndex) * pageSize).Take(pageSize);

            return result;
        }

        public static IQueryable<T> ToPagedListGrid<T>(this IQueryable<T> source, int start = 0, int length = 10)
        {
            var result = source.Skip(start).Take(length);

            return result;


        }
    }
}
