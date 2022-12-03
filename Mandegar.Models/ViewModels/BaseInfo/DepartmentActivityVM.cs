using Mandegar.Models.Entities.User;
using System.Collections.Generic;

namespace Mandegar.Models.ViewModels.BaseInfo
{
    public class DepartmentActivityVM
    {
        public int Id { get; set; }
        /// <summary>
        /// کد دپارتمان
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// عنوان فعالیت
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// شرح فعالیت
        /// </summary>
        public string ActivityDescription { get; set; }

        /// <summary>
        /// فایل ضمیمه
        /// </summary>
        public string AttachmentFile { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
        public string DepartmentName { get; set; }




    }
}
