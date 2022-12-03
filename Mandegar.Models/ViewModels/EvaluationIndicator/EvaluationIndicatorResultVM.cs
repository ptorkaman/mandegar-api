using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandegar.Models.ViewModels.EvaluationIndicator
{
    public class EvaluationIndicatorResultVM
    {
        public int Id { get; set; }
        public string EvaluationGroup { get; set; }
        public string Lesson { get; set; }
        public string Question { get; set; }
        public int ScoreCeiling { get; set; }
    }
}
