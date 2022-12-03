using Mandegar.Models.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandegar.Models.ViewModels.EvaluationGroup
{
    public class EvaluationGroupSearchVM: PageListVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
