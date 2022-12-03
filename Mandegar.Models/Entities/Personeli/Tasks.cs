using Mandegar.Models.Base;
using System.Collections.Generic;

namespace Mandegar.Models.Entities.Personeli
{
    /// <summary>
    /// وظیفه
    /// </summary>
    public class Tasks : LoggableEntity<int>
    {
        public Tasks()
        {

        }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// شناسه گروه وظیفه
        /// </summary>
        public int TaskGroupId { get; set; }

        #region Relation

        public virtual TaskGroup TaskGroup { get; set; }

        public virtual ICollection<AssignTask> AssignTasks { get; set; }


        #endregion
    }
}
