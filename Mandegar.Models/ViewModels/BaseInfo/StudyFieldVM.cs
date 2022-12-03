using Mandegar.Models.Entities.User;
using System.Collections.Generic;

namespace Mandegar.Models.ViewModels.BaseInfo
{
    public class StudyFieldVM
    {
        /// <summary>
        /// کد مقطع تحصیلی
        /// </summary>
        public int StudyDefreeId { get; set; }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }

        public int Id { get; set; }
        public string StudyDegreeName { get; set; }
    }
}
