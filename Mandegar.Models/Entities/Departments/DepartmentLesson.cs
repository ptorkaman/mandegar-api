using Mandegar.Models.Base;
using Mandegar.Models.Entities.BaseInfo;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.Departments
{
    /// <summary>
    /// دروس دپارتمان
    /// </summary>
    public class DepartmentLesson : BaseEntity<int>
    {
        public int DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public Department Department { get; set; }

        public int LessonId { get; set; }

        [ForeignKey(nameof(LessonId))]
        public Lesson Lesson { get; set; }

    }
}
