using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDF.Finance.Model.ApiModel
{
    public class PageModel
    {
        public int PageID { get; set; }

        public string PageTitle { get; set; }

        public string PageURL { get; set; }

        public int? PageParentID { get; set; }

        public string PageRemark { get; set; }

        public int? PageRank { get; set; }

        public int? PageIsVisible { get; set; }

        public int? PageIsLock { get; set; }

        public string PageImgSrc { get; set; }
    }
}
