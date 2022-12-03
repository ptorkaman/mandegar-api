using Mandegar.Models.Entities.BaseInfo;
using Mandegar.Models.Entities.Departments;
using Mandegar.Models.Entities.User;
using System.Collections.Generic;

namespace Mandegar.Models.ViewModels.BaseInfo
{
    public class DepartmentLessonVM
    {
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public int LessonId { get; set; }

        public Lesson Lesson { get; set; }
        public string LessonName { get; set; }
        public string DepartmentName { get; set; }
        public int Id { get; set; }
    }
}
