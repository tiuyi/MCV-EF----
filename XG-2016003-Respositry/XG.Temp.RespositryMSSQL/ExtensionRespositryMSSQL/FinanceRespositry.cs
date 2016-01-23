using JDF.Finance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XG.Temp.RespositryMSSQL
{
    public partial class FinanceRespositry
    {

        public string Login()
        {
            //db.Set<Model.Finance>().Where(t=>t.ID > 0).Update()
            return "";
        }

        /// <summary>
        /// 调用存储过程
        /// </summary>
        /// <returns></returns>
        //public Finance.Model.FinancePro_Result SelectPro()
        //{
        //    var finProRelEntity = db.Set<Finance.Model.FinProRel>();
        //    var finProRelEntity1 = db.Set<Finance.Model.Finance>();
        //    var query = from a in finProRelEntity
        //                join b in finProRelEntity1 on a.FinID equals b.ID
        //                select new { };
        //    //var Proc_SelectList = ((JDF_FinanceEntities)db).FinancePro();
        //    //return Proc_SelectList.FirstOrDefault();
        //    return null;
        //}


    }
}
