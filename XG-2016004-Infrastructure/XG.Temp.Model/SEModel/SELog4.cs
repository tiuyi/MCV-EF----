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
    
    public partial class SELog4 : SEBaseModel
    {
        public int? ID { get; set; }
        public System.DateTime? AddDate { get; set; }public System.DateTime? FromAddDate { get; set; }public System.DateTime? ToAddDate { get; set; }
        public string AddThread { get; set; }
        public string AddLevel { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
    }
}
