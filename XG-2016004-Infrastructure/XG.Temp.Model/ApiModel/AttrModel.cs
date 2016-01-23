using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDF.Finance.Model.ApiModel
{
    public class AttrModel
    {
        public int GoodAttrValID { get; set; }
        public string GoodAttrValue { get; set; }
        public string GoodAttrVal { get; set; }
        public string GoodAttValKey { get; set; }
        public string GoodAttrTag { get; set; }
    }
    public class TempProCity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 中文名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 拼音首字母
        /// </summary>
        public string NameF { get; set; }
        /// <summary>
        /// 全拼
        /// </summary>
        public string NameA { get; set; }
    }
    public class TempAgent
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int AgentID { get; set; }
        /// <summary>
        /// 分销商名称
        /// </summary>
        public string AgentName { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public string AgentNo { get; set; }
        /// <summary>
        /// 类型代码
        /// </summary>
        public string AgentTypeCode { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string AgentTypeName { get; set; }
    }
}
