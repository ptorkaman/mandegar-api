using Mandegar.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.Departments
{
    /// <summary>
    /// ارزشیابی دبیر
    /// </summary>
    public class SecretaryEvaluation : BaseEntity<int>
    {
        public int DepartmentMemberId { get; set; }

        [ForeignKey(nameof(DepartmentMemberId))]
        public DepartmentMember DepartmentMember { get; set; }

        public int DepartmentEvaluationGroupId { get; set; }

        [ForeignKey(nameof(DepartmentEvaluationGroupId))]
        public DepartmentEvaluationGroup DepartmentEvaluationGroup { get; set; }

        public int EvaluationCourseId { get; set; }

        [ForeignKey(nameof(EvaluationCourseId))]
        public EvaluationCourse EvaluationCourse { get; set; }
    }
}
