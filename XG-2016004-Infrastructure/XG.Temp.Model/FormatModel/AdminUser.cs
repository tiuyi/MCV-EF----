using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDF.Finance.Model.FormatModel
{
    [Serializable]
    public class AdminUser
    {
        public int UserID { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserNo { get; set; }
        /// <summary>
        /// 用户角色
        /// </summary>
        public int? RoleID { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPass { get; set; }
    }
}
