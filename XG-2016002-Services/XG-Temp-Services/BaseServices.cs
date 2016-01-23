using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Reflection;
using XG.Temp.Iservices;
using XG.Temp.IRespositry;
 

namespace XG.Temp.Services
{
    /// <summary>
    /// 业务层父类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseServices<T> : IBaseServices<T> where T : class,new()
    {
        public BaseServices()
        {
            SetDAL();
            //iDbSession.IOu_UserInfoDAL.GetListBy(u => u.uId == 3);
        }

        //1.数据层接口 对象 - 等待 被实例化
        protected IRespositry.IBaseRespositry<T> idal;// = new idal.BaseDAL();
        /// <summary>
        /// 由子类实现，为 业务父类 里的 数据接口对象 设置 值！
        /// </summary>
        public abstract void SetDAL();

        /// <summary>
        /// 2.0 数据仓储接口（相当于数据层工厂，可以创建所有的数据子类对象）
        /// </summary>
        private IRespositry.IDBSession iDbSession;

        #region 数据仓储 属性 + IDBSession DBSession
        /// <summary>
        /// 数据仓储 属性
        /// </summary>
        public IRespositry.IDBSession DBSession
        {
            get
            {
                if (iDbSession == null)
                {
                    //1.读取配置文件
                    //string strFactoryDLL = System.Configuration.ConfigurationManager.AppSettings["DBSessionFatoryDLL"];
                    //string strFactoryType = System.Configuration.ConfigurationManager.AppSettings["DBSessionFatory"];
                    //2.1通过反射创建 DBSessionFactory 工厂对象
                    //Assembly dalDLL = Assembly.LoadFrom(strFactoryDLL);
                    //Type typeDBSessionFatory = dalDLL.GetType(strFactoryType);
                    //IRespositry.IDBSessionFactory sessionFactory = Activator.CreateInstance(typeDBSessionFatory) as IRespositry.IDBSessionFactory;
                    //2.根据配置文件内容 使用 DI层里的Spring.Net 创建 DBSessionFactory 工厂对象
                    IDBSessionFactory sessionFactory = DI.AutoFacHelper.GetObject<IDBSessionFactory>("DBSessionFactory");

                    ////3.通过 工厂 创建 DBSession对象
                    iDbSession = sessionFactory.GetDBSession();
                }
                return iDbSession;
            }
        }
        #endregion

        //2.增删改查方法
        #region 1.0 新增 实体 +int Add(T model)
        /// <summary>
        /// 新增 实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(T model)
        {
            idal.Add(model);
            return iDbSession.SaveChange();
        }
        #endregion

        #region 2。0 根据 用户 id 删除 +int Del(int uId)
        /// <summary>
        /// 根据 用户 id 删除
        /// </summary>
        /// <param name="uId"></param>
        /// <returns></returns>
        public int Del(T model)
        {
            idal.Del(model);
            return iDbSession.SaveChange();
        }
        #endregion

        #region 3.0 根据条件删除 +int DelBy(Expression<Func<T, bool>> delWhere)
        /// <summary>
        /// 3.0 根据条件删除
        /// </summary>
        /// <param name="delWhere"></param>
        /// <returns></returns>
        public int DelBy(Expression<Func<T, bool>> delWhere)
        {
            idal.DelBy(delWhere);
            return iDbSession.SaveChange();
        }
        #endregion

        #region 4.0 修改 +int Modify(T model, params string[] proNames)
        /// <summary>
        /// 4.0 修改，如：
        /// </summary>
        /// <param name="model">要修改的实体对象</param>
        /// <param name="proNames">要修改的 属性 名称</param>
        /// <returns></returns>
        public int Modify(T model, params string[] proNames)
        {
            idal.Modify(model, proNames);
            return iDbSession.SaveChange();
        }
        #endregion

        #region  4.0 批量修改 +int Modify(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames)
        /// <summary>
        ///  4.0 批量修改 +int Modify(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames)
        /// </summary>
        /// <param name="model"></param>
        /// <param name="whereLambda"></param>
        /// <param name="modifiedProNames"></param>
        /// <returns></returns>
        public int ModifyBy(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames)
        {
            idal.ModifyBy(model, whereLambda, modifiedProNames);
            return iDbSession.SaveChange();
        }
        #endregion

        #region 5.0 根据条件查询 +List<T> GetListBy(Expression<Func<T,bool>> whereLambda)
        /// <summary>
        /// 5.0 根据条件查询 +List<T> GetListBy(Expression<Func<T,bool>> whereLambda)
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> GetListBy(Expression<Func<T, bool>> whereLambda = null)
        {
            return idal.GetListBy(whereLambda);
        }
        #endregion

        #region 5.1 根据条件 排序 和查询 + List<T> GetListBy<TKey>
        /// <summary>
        /// 5.1 根据条件 排序 和查询
        /// </summary>
        /// <typeparam name="TKey">排序字段类型</typeparam>
        /// <param name="whereLambda">查询条件 lambda表达式</param>
        /// <param name="orderLambda">排序条件 lambda表达式</param>
        /// <returns></returns>
        public IQueryable<T> GetListBy<TKey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda)
        {
            return idal.GetListBy(whereLambda, orderLambda);
        }
        #endregion

        #region 6.0 分页查询 + List<T> GetPagedList<TKey>
        /// <summary>
        /// 6.0 分页查询 + List<T> GetPagedList<TKey>
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="whereLambda">条件 lambda表达式</param>
        /// <param name="orderBy">排序 lambda表达式</param>
        /// <returns></returns>
        public IQueryable<T> GetPagedList<TKey>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderBy)
        {
            return idal.GetPagedList(pageIndex, pageSize, whereLambda, orderBy);
        }
        #endregion

        #region 6.1分页查询 带输出 +List<T> GetPagedList<TKey>
        /// <summary>
        /// 6.1分页查询 带输出
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderBy"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IQueryable<T> GetPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderBy, bool isAsc = true)
        {
            return idal.GetPagedList<TKey>(pageIndex, pageSize, ref rowCount, whereLambda, orderBy, isAsc);
        }
        #endregion

        public int GetProcedureByOne(string commandText, params Object[] parameters) {
            return idal.GetProcedureByOne(commandText, parameters);
        }
        public IList<T> GetProcedureList<T>(string commandText, params Object[] parameters)
        {
            return idal.GetProcedureList<T>(commandText, parameters);
        }

        public int ExecteNonQuery(string commandText, params Object[] parameters)
        {
            return idal.ExecteNonQuery(commandText, parameters);
        }

        //public IQueryable<T> GetFilterQueryable<T, V>(V search_model)
        //{
        //    var whereLambda = SearchHelper.FilterWhere<T, V>(search_model);
        //    Type t_search_model = search_model.GetType();
        //    int PageIndex = Convert.ToInt32(t_search_model.GetProperty("PageIndex").GetValue(search_model));
        //    int PageSize = Convert.ToInt32(t_search_model.GetProperty("PageSize").GetValue(search_model));
        //    return idal.GetPagedList<T>(PageIndex, PageSize, ref rowCount, whereLambda, orderBy, isAsc);
        //}
    }
}
