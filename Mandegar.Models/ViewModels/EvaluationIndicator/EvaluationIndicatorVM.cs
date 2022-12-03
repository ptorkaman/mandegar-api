using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandegar.Models.ViewModels.EvaluationIndicator
{
    public class EvaluationIndicatorVM
    {
        public int Id { get; set; }
        public int DepartmentEvaluationGroupId { get; set; }
        public int DepartmentLessonId { get; set; }
        public string Question { get; set; }
        public int ScoreCeiling { get; set; }
    }
}
