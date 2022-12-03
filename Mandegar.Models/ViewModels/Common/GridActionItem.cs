namespace Mandegar.Models.ViewModels.Common
{
    public class GridActionItem
    {
        public GridActionItem(string title, string functionName, string icon = null)
        {
            Title = title;
            FunctionName = functionName;
            Icon = icon;
        }

        public string Title { get; }
        public string FunctionName { get; }
        public string Icon { get; set; }
    }


}
