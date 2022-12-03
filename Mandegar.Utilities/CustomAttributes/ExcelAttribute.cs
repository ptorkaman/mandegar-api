using System;

namespace Mandegar.Utilities.CustomAttributes
{
    public class ExcelAttribute : Attribute
    {
        public string Title { get; set; } = "";
        public int TabIndex { get; set; } = 0;
    }
}
