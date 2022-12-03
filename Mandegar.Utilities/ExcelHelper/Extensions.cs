using NPOI.SS.UserModel;
using System.Collections.Generic;

namespace Mandegar.Utilities.ExcelHelper
{
    static class Extensions
    {
        internal static IEnumerable<IRow> Rows(this ISheet sheet)
        {
            var e = sheet.GetRowEnumerator();
            while (e.MoveNext())
                yield return e.Current as IRow;
        }
    }
}
