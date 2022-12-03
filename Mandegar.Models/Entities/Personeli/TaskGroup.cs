using Mandegar.Models.Base;
using System.Collections.Generic;

namespace Mandegar.Models.Entities.Personeli
{
    /// <summary>
    /// گروه وظیفه
    /// </summary>
    public class TaskGroup : LoggableEntity<int>
    {
        public TaskGroup()
        {

        }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }

        #region Relation

        public virtual List<Tasks> Tasks { get; set; }

        #endregion
    }
}
