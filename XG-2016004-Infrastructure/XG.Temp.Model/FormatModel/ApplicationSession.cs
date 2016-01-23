using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDF.Finance.Model.FormatModel
{
    [Serializable]
    public class ApplicationSession
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public int FinanceID { get; set; }
        public string FinanceName { get; set; }
        public int AgentID { get; set; }
        /// <summary>
        /// 直营还是合作店 ZY HZD
        /// </summary>
        public string CateName { get; set; }
        /// <summary>
        /// 现行年月
        /// </summary>
        public int CurrentYear { get; set; }
        /// <summary>
        /// 现行年月
        /// </summary>
        public int CurrentMonth { get; set; }
    }
}
