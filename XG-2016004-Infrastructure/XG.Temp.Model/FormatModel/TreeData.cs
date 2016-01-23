using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDF.Finance.Model.FormatModel
{
    public class TreeNode
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Cls { get; set; }
        public string Url { get; set; }
        public List<TreeNode> Child { get; set; }
    }
}
