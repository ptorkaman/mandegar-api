using Mandegar.Models.Entities.User;
using System.Collections.Generic;

namespace Mandegar.Models.ViewModels.BaseInfo
{
    public class StudyGradeVM
    {
        /// <summary>
        /// کد رشته تحصیلی
        /// </summary>
        public int StudyFieldId { get; set; }
        public string StudyFieldName { get; set; }


        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// کد پایه آموزرش و پرورش
        /// </summary>
        public int EducationBasicCode { get; set; }

        public int Id { get; set; }


    }
}
