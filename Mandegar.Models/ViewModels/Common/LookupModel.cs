using System;

namespace Mandegar.Models.ViewModels.Common
{
    public class LookupModel
    {
        public object Obj { get; set; }
        public Type Type { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string GridName { get { return $"grd_{Name}"; } }
        public string FormName { get; set; }
        public string CallbackFunction { get; set; }
        public bool MultiSelect { get; set; } = false;
        public string SelectedValue { get; set; }
    }

    
}
