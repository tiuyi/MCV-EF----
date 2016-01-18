using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDF.Finance.Common
{
    #region 通用除去重复数据类
    /// <summary>
    ///  List<ColumnDicModel> listResult = list.Distinct(new Compare<ColumnDicModel>((x, y) => (x != null && y != null) && (x.DicCode == y.DicCode))).ToList();
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public delegate bool CompareDelegate<T>(T x, T y);
    public class Compare<T> : IEqualityComparer<T>
    {
        private CompareDelegate<T> _compare;
        public Compare(CompareDelegate<T> d)
        {
            this._compare = d;
        }

        public bool Equals(T x, T y)
        {
            if (_compare != null)
            {
                return this._compare(x, y);
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(T obj)
        {
            return obj.ToString().GetHashCode();
        }
    }
    #endregion
}
