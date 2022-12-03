using Mandegar.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.Personeli
{
    /// <summary>
    /// ایثارگری
    /// </summary>
    public class Sacrifice : LoggableEntity<int>
    {
        public Sacrifice()
        {

        }

        /// <summary>
        /// کد پرسنل
        /// </summary>
        public int StaffId { get; set; }

        /// <summary>
        /// خانواده شهید
        /// </summary>
        public bool IsMartyrFamily { get; set; }

        /// <summary>
        /// کد نسب
        /// </summary>
        public int? RelationId { get; set; }

        /// <summary>
        /// آزاده
        /// </summary>
        public bool IsFreedMan { get; set; }

        /// <summary>
        /// مدت اسارت
        /// </summary>
        public int? CaptivityDuration { get; set; }

        /// <summary>
        /// جانباز
        /// </summary>
        public bool IsVeteran { get; set; }

        /// <summary>
        /// درصد جانبازی
        /// </summary>
        public int? VeteranPercentage { get; set; }

        /// <summary>
        /// ایثارگر
        /// </summary>
        public bool IsSacrificer { get; set; }

        /// <summary>
        /// مدت زمان حضور در جبهه
        /// </summary>
        public int? BattlefieldPresenceDuration { get; set; }

        #region Relation

        [ForeignKey(nameof(StaffId))]
        public virtual Staff Staff { get; set; }

        [ForeignKey(nameof(RelationId))]
        public virtual Relation Relation { get; set; }

        #endregion
    }
}
