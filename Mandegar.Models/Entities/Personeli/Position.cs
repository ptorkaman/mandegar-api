using Mandegar.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.Personeli
{
    /// <summary>
    /// سمت
    /// </summary>
    public class Position : LoggableEntity<int>
    {
        public Position()
        {

        }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }

        #region Relation

        public int? ParentId { get; set; }
        public Position Parent { get; set; }
        [ForeignKey(nameof(ParentId))]
        public virtual ICollection<Position> Positions { get; set; }

        public virtual ICollection<AssignTask> AssignTasks { get; set; }
        public virtual ICollection<AssignPosition> AssignPositions { get; set; }

        #endregion
    }
}
