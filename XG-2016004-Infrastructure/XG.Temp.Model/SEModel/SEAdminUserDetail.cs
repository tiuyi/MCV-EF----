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
    
    public partial class SEAdminUserDetail : SEBaseModel
    {
        public int? AdminUserDetailID { get; set; }
        public int? AdminUserID { get; set; }
        public string AdminUseTel { get; set; }
        public string AdminUseEmail { get; set; }
        public System.DateTime? AdminUserAddTime { get; set; }public System.DateTime? FromAdminUserAddTime { get; set; }public System.DateTime? ToAdminUserAddTime { get; set; }
        public int? AdminDisGroupID { get; set; }
        public string WeiXinHao { get; set; }
        public string WeiXinOpenID { get; set; }
    
        public virtual AdminUser AdminUser { get; set; }
    }
}
