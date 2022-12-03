using NPOI.SS.UserModel;
using System;

namespace Mandegar.Utilities.ExcelHelper
{
    /// <summary>
    /// Provides data for the <see cref="Map.Saving"/> event.
    /// </summary>
    public class SavingEventArgs: EventArgs
    {
        /// <summary>
        /// Gets or sets the sheet.
        /// </summary>
        /// <value>
        /// The sheet.
        /// </value>
        public ISheet Sheet { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SavingEventArgs"/> class.
        /// </summary>
        /// <param name="sheet">The sheet that is being saved.</param>
        public SavingEventArgs(ISheet sheet)
        {
            Sheet = sheet;
        }
    }
}
