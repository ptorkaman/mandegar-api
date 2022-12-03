using Mandegar.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.BaseInfo
{
    public class Lesson : LoggableEntity<int>
    {
        public Lesson()
        {

        }

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

        /// <summary>
        /// تعداد واحد
        /// </summary>
        public int? CourseUnits { get; set; }

        #region Relation

        [ForeignKey(nameof(StudyGradeId))]
        public virtual StudyGrade StudyGrade { get; set; }

        [ForeignKey(nameof(LessonTypeId))]
        public virtual LessonType LessonType { get; set; }

        #endregion
    }
}
