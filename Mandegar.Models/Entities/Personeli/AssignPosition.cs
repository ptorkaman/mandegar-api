using Mandegar.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.Personeli
{
    /// <summary>
    /// تخصیص سمت
    /// </summary>
    public class AssignPosition
    {
        public int PositionId { get; set; }

        [ForeignKey(nameof(PositionId))]
        public Position Position { get; set; }

        public int StaffId { get; set; }

        [ForeignKey(nameof(StaffId))]
        public Staff Staff { get; set; }

       
    }
}
