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
    
    public partial class EAdminPageAuth
    {
        public int AdminPageAuthID { get; set; }
        public int AdminPageID { get; set; }
        public int AdminPageRelID { get; set; }
        public int AdminPageRelType { get; set; }
        public int AdminPageDicType { get; set; }
        public bool AdminPageAuthIsLock { get; set; }
        public int AdminPageAuthRank { get; set; }
    
        public virtual AdminPage AdminPage { get; set; }
    }
}
