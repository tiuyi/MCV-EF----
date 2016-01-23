using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDF.Finance.Model.FormatModel
{
    public class CateGroup
    {
        
        public int CateGroupID
        {
            get;
            set;
        }

        [DisplayName("父分类")]
        public int? CGParentID
        {
            get;
            set;
        }

        [DisplayName("组名")]
        public string CGName
        {
            get;
            set;
        }

        [DisplayName("代码Code")]
        public string CGCode
        {
            get;
            set;
        }


        [DisplayName("排序")]
        public int? CGRank
        {
            get;
            set;
        }

        [DisplayName("类型")]
        public int? CGType
        {
            get;
            set;
        }
    }
}
