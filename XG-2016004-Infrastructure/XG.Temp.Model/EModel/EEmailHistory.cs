//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace XG.Temp.Model.EModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class EEmailHistory
    {
        public int EmailHistoryID { get; set; }
        public string EmailTitle { get; set; }
        public int EmailUserID { get; set; }
        public string EmailAddress { get; set; }
        public int SEMTemplateID { get; set; }
        public string EmailContent { get; set; }
        public int EmailSendStatus { get; set; }
        public System.DateTime EmailSendTime { get; set; }
        public string EmailRemarks { get; set; }
    }
}
