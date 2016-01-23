using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDF.Finance.FormatModel
{
    /// <summary>
    /// 查询Ajax返回的实体
    /// </summary>
    public class AjaxSearchModel
    {
        /// <summary>
        /// 请求匹配标识
        /// </summary>
        public int sEcho { get; set; }
        /// <summary>
        /// 返回的json数据
        /// </summary>
        public object data { get; set; }
        /// <summary>
        /// Number of records in the data set, not accounting for filtering
        /// 无过滤的条数
        /// </summary>
        public int iTotalRecords { get; set; }
        /// <summary>
        /// Number of records in the data set, accounting for filtering
        /// 已过滤之后的条数
        /// </summary>
        public int iTotalDisplayRecords { get; set; }
    }
}
