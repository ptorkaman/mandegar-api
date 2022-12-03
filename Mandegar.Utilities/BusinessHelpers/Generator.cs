using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Mandegar.Utilities.BusinessHelpers
{
    public static class Generator
    {
        public static string UniqueNameGenerator()
        {
            return Guid.NewGuid().ToString("N");
        }
        public static string CreateFatorNumber()
        {
            var Date = DateTime.Now;
            PersianCalendar pc = new PersianCalendar();
            var year = pc.GetYear(Date);
            var month = pc.GetMonth(Date);
            var day = pc.GetDayOfMonth(Date);
            var hour = pc.GetHour(Date);
            var min = pc.GetMinute(Date);
            var sec = pc.GetSecond(Date);

            string factorNo = $"{year.ToString().Substring(1)}{month}{day}{hour}{min}{sec}";

            return factorNo;
        }
        public static string ReplaceBase64(this string model)
        {
            Regex regex = new Regex(@"^[\w/\:.-]+;base64,");
            model = regex.Replace(model, string.Empty);
            return model;
        }

    }
}
