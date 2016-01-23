using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDF.Finance.Model.ApiModel
{
    public class OrgModel
    {
        public int? OrgID { get; set; }
        public string OrgName { get; set; }
        public string OrgTypeNo { get; set; }
        public int OriOrgID { get; set; }
        public int? OriParentOrgID { get; set; }
        public string OrgNo { get; set; }

        /// <summary>
        /// DEP = 部门
        /// ACC = 账套
        /// COM = 公司
        /// CUS = 客户
        /// </summary>
        public enum OrgType
        {
            /// <summary>
            /// 部门
            /// </summary>
            DEP,
            /// <summary>
            /// 账套
            /// </summary>
            ACC,
            /// <summary>
            /// 公司
            /// </summary>
            COM,
            /// <summary>
            /// 客户
            /// </summary>
            CUS,
            /// <summary>
            /// 用户权限
            /// </summary>
            ADMINUSER
        }
    }
}
