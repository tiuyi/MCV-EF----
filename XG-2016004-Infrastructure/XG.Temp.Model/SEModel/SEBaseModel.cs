using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XG.Temp.Model.SEModel
{
    public class SEBaseModel
    {
        /// <summary>
        /// 分页索引
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 分页数量
        /// </summary>
        public int PageSize { get; set; }

        public int sEcho { get; set; }
    }
}
