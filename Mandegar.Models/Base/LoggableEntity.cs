using Mandegar.Models.Entities.User;
using System;

namespace Mandegar.Models.Base
{
    public class LoggableEntity<T> : BaseEntity<T>
    {

        public int CreatedById { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedById { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual User ModifiedBy { get; set; }
    }
}
