using Mandegar.Models.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mandegar.Models.Entities.User
{
    public class Role : LoggableEntity<int>
    {
        public Role()
        {
        }

        [Display(Name = "نام نقش")]
        [DisplayName("نام نقش")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Name { get; set; } = "";

        public bool ShowInList { get; set; } = true;

        #region Relations

        public ICollection<RolePermission> RolePermissions { get; set; }

        #endregion
    }
}