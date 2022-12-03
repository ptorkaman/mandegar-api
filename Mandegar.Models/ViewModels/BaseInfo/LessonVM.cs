using Mandegar.Models.Entities.User;
using System.Collections.Generic;

namespace Mandegar.Models.ViewModels.BaseInfo
{
    public class LessonVM
    {

        /// <summary>
        /// کد پایه تحصیلی
        /// </summary>
        public int StudyGradeId { get; set; }

        /// <summary>
        /// کد نوع درس
        /// </summary>
        public int LessonTypeId { get; set; }

        /// <summary>
        /// نام درس
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// کد درس آموزش و پرورش
        /// </summary>
        public string EducationCourseCode { get; set; }
        public int Id { get; set; }
        public string LessonTypeName { get; set; }
        public string StudyGradeName { get; set; }
        public int? CourseUnits { get; set; }

    }
}
