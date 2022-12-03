using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;


namespace Mandegar.Utilities.BusinessHelpers
{
    public static class Convertor
    {

        #region DateTime Convertor

        public static string ChangeDateTimeToPersianString(this DateTime Date)
        {
            PersianCalendar pc = new PersianCalendar();
            var year = pc.GetYear(Date);
            var month = pc.GetMonth(Date);
            var day = pc.GetDayOfMonth(Date);

            string PersianDate = $"{year}/{month}/{day}";

            return PersianDate;
        }
        public static string ChangeFullDateTimeToPersianString(this DateTime Date)
        {
            PersianCalendar pc = new PersianCalendar();
            var year = pc.GetYear(Date);
            var month = pc.GetMonth(Date);
            var day = pc.GetDayOfMonth(Date);
            var hour = pc.GetHour(Date);
            var min = pc.GetMinute(Date);

            string PersianDate = $"{year}/{month}/{day} - {hour}:{min} ";

            return PersianDate;
        }
        public static DateTime ChangePersianDateToMiladiDate(this DateTime dt)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.ToDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }

        public static DateTime? ChangePersianStringDateToMiladiDate(this string dt)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dt))
                {
                    return null;
                }

                var splittedDate = dt.Split('/');

                var date = "";

                foreach (var item in splittedDate)
                {
                    if (item.Length == 1)
                    {
                        date = date + item.PadLeft(2, '0');
                    }
                    else
                    {
                        date = date + item;
                    }
                }

                var year = int.Parse(date.Substring(0, 4));
                var month = int.Parse(date.Substring(4, 2));
                var day = int.Parse(date.Substring(6, 2));

                PersianCalendar pc = new PersianCalendar();
                return pc.ToDateTime(year, month, day, 0, 0, 0, 0);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region List To DataTable
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            object[] values = new object[props.Count];
            foreach (var item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }
        #endregion
    }
}
