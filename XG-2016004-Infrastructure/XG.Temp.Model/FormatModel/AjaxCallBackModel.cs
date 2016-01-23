using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDF.Finance.FormatModel
{
    /// <summary>
    /// Ajax 回调格式类
    /// </summary>
    public class AjaxCallBackModel
    {
        /// <summary>
        /// 回调消息
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 回调状态 error success nologin
        /// </summary>
        public AjaxStatus status { get; set; }
        /// <summary>
        /// 回调url
        /// </summary>
        public string backurl { get; set; }
        /// <summary>
        /// 回调数据
        /// </summary>
        public object data { get; set; }
    }

    /// <summary>
    /// Ajax状态
    /// </summary>
    public enum AjaxStatus
    {
        SUCCESS = 1,//成功
        ERROR,      //失败
        NOLOGIN     //没有登陆
    }
}
