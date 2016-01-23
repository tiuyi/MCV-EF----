 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace JDF.Finance.Services
{
    public partial class FinaProjectServices
    {
        /// <summary>
        /// 科目添加或编辑
        /// </summary>
        /// <param name="se"></param>
        /// <returns></returns>
        //public int Save(FinaProject se)
        //{ 
        //    se.NameA = ConvertPinYin.GetFullPinYin(se.Name);
        //    se.NameF = ConvertPinYin.GetFirstPinYin(se.Name);
        //    se.CreateDate = DateTime.Now;
        //    se.Level = (se.Code.Length - 4) / 2 + 1;
        //    if (se.Unit == "0")
        //    {
        //        se.Unit = null;
        //    }
        //    int count = 0;
        //    if (se.ID != 0) //编辑
        //    {
        //        //count = base.Modify(se,"FinID","Code","Name","NameA","NameF","Rank","ParentID","CreateDate","Level","IsStock","IsCarry","Direction","AccountItem","Unit","IsCash","Remark","IsContactID","BigCateName","IsBorrowLend");
        //        count = base.Modify(se, new string[] { "FCompanyID", "Code", "Name", "NameA", "NameF", "Rank", "ParentID", "CreateDate", "Level", "IsStock", "IsCarry", "Direction", "AccountItem", "Unit", "IsCash", "Remark", "IsContactID", "BigCateName", "IsBorrowLend" });
               
        //    }
        //    else//添加
        //    {
        //          count = base.Add(se); 
        //    }

        //    if (se.Level == 1)
        //    {
        //        ExecteNonQuery("update FinaProject set IsCarry="+se.IsCarry+", Direction ="+se.Direction+" where parentid ="+se.ID);
        //    }
        //    return count;
        //}

        ///// <summary>
        ///// 确认复制
        ///// </summary>
        ///// <param name="ids">要复制的科目id</param>
        ///// <param name="FinID">复制给谁（帐套id）</param>
        ///// <returns></returns>
        //public int Sure(int[] ids, int FinID)
        //{
        //    var list = DBSession.IFinaProjectRespositry.GetListBy(m => ids.Contains(m.ID));
        //    int c = 0;
        //    foreach (var l in list)
        //    {
        //        var fin = GetListBy(m=>m.FCompanyID==FinID&&m.Code==l.Code).FirstOrDefault();
        //        if (fin!=null) //已经存在
        //        {
        //            c++;
        //            continue;
        //        }
        //        l.FCompanyID = FinID;
        //        DBSession.IFinaProjectRespositry.Add(l);
        //    }
        //    DBSession.SaveChange();

        //    return c;

        //}

        ///// <summary>
        ///// 批量添加科目
        ///// </summary>
        ///// <param name="list"></param>
        ///// <returns></returns>
        //public int SaveAll(List<FinaProject> list)
        //{
        //    foreach (var l in list)
        //    {
        //        DBSession.IFinaProjectRespositry.Add(l);
        //    }

        //  return  DBSession.SaveChange();
            
        //}

        ///// <summary>
        ///// 过滤Where条件，统一查询
        ///// </summary>
        ///// <param name="search_model">查询实体</param>
        ///// <param name="rowCount">返回条数</param>
        ///// <param name="orderBy">排序</param>
        ///// <param name="isAsc">是否升序</param>
        ///// <returns></returns>
        //public IQueryable<FinaProject> GetFilterQueryable(SEFinaProject search_model, ref int rowCount, Expression<Func<FinaProject, FinaProject>> orderBy = null, bool isAsc = true)
        //{
        //    var whereLambda = SearchHelper.FilterWhere<FinaProject, SEFinaProject>(search_model);
        //    Type t_search_model = search_model.GetType();
        //    if (search_model.PageSize == 0)
        //        return base.GetListBy(whereLambda);
        //    else
        //    {
        //        if (orderBy == null)
        //            return base.GetPagedList(search_model.PageIndex, search_model.PageSize, ref rowCount, whereLambda, m => m.ID, isAsc);
        //        else
        //            return base.GetPagedList(search_model.PageIndex, search_model.PageSize, ref rowCount, whereLambda, orderBy, isAsc);
        //    }
        //}
    }
}
