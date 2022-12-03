using Mandegar.Models.Base;
using Mandegar.Models.Entities.Personeli;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.Departments
{
    /// <summary>
    /// اعضاء دپارتمان
    /// </summary>
    public class DepartmentMember : LoggableEntity<int>
    {
        public DepartmentMember()
        {

        }

        /// <summary>
        /// کد دپارتمان
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// کد پرسنل
        /// </summary>
        public int StaffId { get; set; }

        /// <summary>
        /// کد سمت
        /// </summary>
        public int PositionId { get; set; }

        #region Relation

        [ForeignKey(nameof(DepartmentId))]
        public virtual Department Department { get; set; }

        [ForeignKey(nameof(StaffId))]
        public virtual Staff Staff { get; set; }

        [ForeignKey(nameof(PositionId))]
        public virtual Position Position { get; set; }

        public virtual ICollection<DepartmentActivityMember> DepartmentActivityMembers { get; set; }

        public virtual ICollection<DepartmentMeetingMember> DepartmentMeetingMembers { get; set; }

        public virtual ICollection<MeetingMember> MeetingMembers { get; set; }

        #endregion
    }
}
