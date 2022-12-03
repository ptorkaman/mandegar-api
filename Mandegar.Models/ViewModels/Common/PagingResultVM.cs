using System.Collections.Generic;

namespace Mandegar.Models.ViewModels.Common
{
    public class PagingResultVM<T>
    {
        public PagingResultVM()
        {
            this.Rows = new List<T>();
        }

        public IEnumerable<T> Rows { get; set; }
        public int Total { get; set; }
    }
}
