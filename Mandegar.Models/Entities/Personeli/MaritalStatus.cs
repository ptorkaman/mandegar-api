using Mandegar.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandegar.Models.Entities.Personeli
{
    /// <summary>
    /// وضعیت تاهل
    /// </summary>
    public class MaritalStatus : LoggableEntity<int>
    {
        public MaritalStatus()
        {

        }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }
    }
}
