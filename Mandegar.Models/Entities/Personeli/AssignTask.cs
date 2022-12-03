using Mandegar.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.Personeli
{
    /// <summary>
    /// تخصیص وظایف
    /// </summary>
    public class AssignTask 
    {
        public int PositionId { get; set; }

        [ForeignKey(nameof(PositionId))]
        public Position Position { get; set; }

        public int TaskId { get; set; }

        [ForeignKey(nameof(TaskId))]
        public Tasks Task { get; set; }
    }
}
