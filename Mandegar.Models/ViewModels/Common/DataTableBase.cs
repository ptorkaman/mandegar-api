using JqueryDataTables.ServerSide.AspNetCoreWeb.Attributes;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Models;
using Mandegar.Utilities.CustomAttributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Mandegar.Models.ViewModels.Common
{
    public class DataTableBase
    {
        [NotMapped]
        [JqueryDataTableColumn(Order = -1)]
        [Serachable(Label = "Row", Order = -1, IsSerach = false, IsShowInGrid = true, IsSum = false)]
        public int RowIndex { get; set; } = 0;
    }


    public class HafeleDataTablesParameters
    {
        public int Draw { get; set; }

        public DTColumn[] Columns { get; set; }

        public DTOrder[] Order { get; set; }

        public int Start { get; set; }

        public int Length { get; set; }

        public DTSearch Search { get; set; }

        public string SortOrder => Columns != null && Order != null && Order.Length > 0
                    ? (Columns[Order[0].Column].Data + (Order[0].Dir == DTOrderDir.DESC ? " " + Order[0].Dir : string.Empty))
                    : null;

        public IEnumerable<object> AdditionalValues { get; set; }

        public IEnumerable<object> GetAdditionalValues
        {
            get
            {
                try
                {
                    return AdditionalValues?.Select(x => x?.ToString()).ToList();
                }
                catch
                {
                    return null;
                }
            }
        }

    }
}
