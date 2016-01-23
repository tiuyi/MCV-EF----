using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDF.Finance.FormatModel
{
    /// <summary>
    /// 数据提交类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SubmitRowData<T>
    {
        /// <summary>
        /// 添加行列表
        /// </summary>
        public List<T> AddList { get; set; }
        /// <summary>
        /// 编辑行列表
        /// </summary>
        public List<T> EditList { get; set; }
        /// <summary>
        /// 删除行列表
        /// </summary>
        public List<T> DelList { get; set; }
    }

}
