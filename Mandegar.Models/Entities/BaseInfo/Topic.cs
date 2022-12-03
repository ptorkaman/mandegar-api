using Mandegar.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.BaseInfo
{
    /// <summary>
    /// سرفصل
    /// </summary>
    public class Topic : LoggableEntity<int>
    {
        public Topic()
        {

        }

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

        #region Relation

        [ForeignKey(nameof(LessonId))]
        public virtual Lesson Lesson { get; set; }

        #endregion
    }
}
