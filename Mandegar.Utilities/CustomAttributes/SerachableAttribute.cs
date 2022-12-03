using Mandegar.Utilities.Enums;
using System;
using System.Collections.Generic;

namespace Mandegar.Utilities.CustomAttributes
{
    public class SerachableAttribute : Attribute
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public PropertyType PropertyType { get; set; }
        public string DataSourceUrl { get; set; }
        public string SuccessFunction { get; set; }
        public string DataSourceDataTextField { get; set; }
        public string DataSourceDataValueField { get; set; }
        public string Placeholder { get; set; }
        public int Maxlength { get; set; } = 50;
        public string Min { get; set; }
        public string Max { get; set; }
        public int Width { get; set; }=0;
        public string GetWith => (Width > 0) ? $"width:{Width}%;" : "";
        public Align Align { get; set; }= Align.Center;
        public int Order { get; set; } = 0;
        public bool Orderable { get; set; } = false;

        public bool IsSerach { get; set; } = false;
        public string GetIsSerach { get { return IsSerach ? "true" : "false"; } }

        public bool IsShowInGrid { get; set; } = true;
        public bool IsShowInDetail { get; set; } = false;
        public bool IsSum { get; set; } = false;

        public Dictionary<string,string> SimpleDropDownListItems { get; set; }

        public string GetIsShowInGrid { get { return IsShowInGrid ? "true" : "false"; } }
    }
}
