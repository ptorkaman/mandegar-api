using Mandegar.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.Departments
{
    /// <summary>
    /// دپارتمان
    /// </summary>
    public class Department : LoggableEntity<int>
    {
        public Department()
        {

        }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// کد پدر
        /// </summary>
        public int? ParentId { get; set; }

        #region Relation

        [ForeignKey(nameof(ParentId))]
        public virtual ICollection<Department> Departments { get; set; }

        public virtual ICollection<DepartmentMeetingMember> DepartmentMeetingMembers { get; set; }
        public Department Parent { get; set; }

        #endregion
    }
}
