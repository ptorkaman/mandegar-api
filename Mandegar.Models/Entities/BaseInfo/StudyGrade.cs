using Mandegar.Models.Base;

namespace Mandegar.Models.Entities.BaseInfo
{
    /// <summary>
    /// پایه تحصیلی
    /// </summary>
    public class StudyGrade : LoggableEntity<int>
    {
        public StudyGrade()
        {

        }

        /// <summary>
        /// کد رشته تحصیلی
        /// </summary>
        public int StudyFieldId { get; set; }


        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// کد پایه آموزرش و پرورش
        /// </summary>
        public int EducationBasicCode { get; set; }


        #region Relation

        public virtual StudyField StudyField { get; set; }

        #endregion

    }
}
