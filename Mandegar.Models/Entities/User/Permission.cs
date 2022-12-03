using Mandegar.Models.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.User
{
    public class Permission : BaseEntity<int>
    {
        public Permission()
        {
        }

        [Display(Name = "نام نقش")]
        [DisplayName("نام نقش")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Name { get; set; } = "";
        public bool ShowInList { get; set; } = true;
        public int Index { get; set; }
        public int? ParentId { get; set; }

        #region Relations

        public ICollection<RolePermission> RolePermission { get; set; }

        [ForeignKey(nameof(ParentId))]
        public virtual ICollection<Permission> Permissions { get; set; }

        #endregion
    }
}