using System.Collections.Generic;

namespace Mandegar.Models.ViewModels.Common
{

    public class TreeNode
    {
        public string label { get; set; }
        public int? data { get; set; }
        public string expandedIcon { get; set; }
        public string collapsedIcon { get; set; }
        public List<TreeNode> children { get; set; }
    }

    public class Root
    {
        public Root()
        {
            data = new List<TreeNode>();
        }
        public List<TreeNode> data { get; set; }
    }


}
