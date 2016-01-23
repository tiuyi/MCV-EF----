using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDF.Finance.Model.FormatModel
{
    [Serializable]
    public class OrderModel
    {
        public int sEcho { get; set; }
        /// <summary>
        /// 分页索引
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 分页数量
        /// </summary>
        public int PageSize { get; set; }
        public int AdminUserID { get; set; }
        public string OrderType { get; set; }
        public DateTime? AddTime_From { get; set; }
        public DateTime? AddTime_To { get; set; }

        public string OrderNo { get; set; }
        public DateTime AddTime { get; set; }
        public string AddUserName { get; set; }
        public decimal TotalPrice { get; set; }
        public int TotalQuantity { get; set; }
        public int CateID { get; set; }
        public int CateGroupID { get; set; }
        public string CGName { get; set; }
        public int FromAgentId { get; set; }
        public int AgentId { get; set; }
        public int Status { get; set; }
        public int IsHasCale { get; set; }
        public string FromAgentName { get; set; }
        public string AgentName { get; set; }
        public decimal TotalWeight { get; set; }

        public decimal GoodSettlePrice { get; set; }


        public string AgentNo_From { get; set; }

        public string AgentNo_To { get; set; } 
    }
}
