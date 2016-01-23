using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDF.Finance.Model.ApiModel
{
    public class ActionModel
    {
        /// <summary>
        /// 标识列
        /// </summary>
        public int ActionID { get; set; }
        /// <summary>
        /// 图片地址：本系统为class="fa fa-add"
        /// </summary>
        public string ActionImgSrc { get; set; }
        /// <summary>
        /// 功能名称
        /// </summary>
        public string ActionName { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int ActionRank { get; set; }
        /// <summary>
        /// 功能描述
        /// </summary>
        public string ActionRemark { get; set; }
        /// <summary>
        /// 功能标识方法：Add()
        /// </summary>
        public string ActionTag { get; set; }
        /// <summary>
        /// 功能颜色
        /// </summary>
        public string ActionColor { get; set; }
    }
}
