using Mandegar.Models.Entities.User;
using System.Collections.Generic;

namespace Mandegar.Models.ViewModels.BaseInfo
{
    public class TopicVM
    {
        /// <summary>
        /// کد درس
        /// </summary>
        public int LessonId { get; set; }

        /// <summary>
        /// عنوان درس
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// کد سرفصل
        /// </summary>
        public string TopicCode { get; set; }

        public int Id { get; set; }
        public string LessonName { get; set; }

    }
}
