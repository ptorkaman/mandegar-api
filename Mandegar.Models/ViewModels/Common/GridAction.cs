using System;
using System.Collections.Generic;
using Mandegar.Utilities.Enums;
namespace Mandegar.Models.ViewModels.Common
{
    public class GridAction
    {
        public GridAction(string name, string icon, string callBack = null, ButtonType buttonType=ButtonType.Default)
        {
            this.Name = name;
            this.Icon = icon;
            this.CallBack = callBack ?? this.Name + "_CallBack";
            ButtonType = buttonType;
        }

        public GridAction(string title, List<GridActionItem> items, ButtonType buttonType = ButtonType.Default)
        {
            Title = title;
            Icon = "fa fa-ellipsis-h";
            Items = items;
            ButtonType = buttonType;
        }

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; }
        public string CallBack { get; }
        public ButtonType ButtonType { get; }
        public string Icon { get; }
        public string Title { get; }
        public List<GridActionItem> Items { get; } = new();
        
    }


}
