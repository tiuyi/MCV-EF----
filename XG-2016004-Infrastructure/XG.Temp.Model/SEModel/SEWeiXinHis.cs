//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace XG.Temp.Model.SEModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class SEWeiXinHis : SEBaseModel
    {
        public int? WXID { get; set; }
        public string WXRandNo { get; set; }
        public int? WXAgentID { get; set; }
        public string WXSendUserName { get; set; }
        public string WXRecUserName { get; set; }
        public string WXRecOpenID { get; set; }
        public int? WXStatus { get; set; }
        public System.DateTime? WXAddTime { get; set; }public System.DateTime? FromWXAddTime { get; set; }public System.DateTime? ToWXAddTime { get; set; }
        public string WXDetail { get; set; }
        public string WXRemark { get; set; }
    }
}
