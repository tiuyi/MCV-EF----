using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XG.Temp.IRespositry
{
    /// <summary>
    /// 数据仓储工厂
    /// </summary>
    public interface IDBSessionFactory
    {
        IDBSession GetDBSession();
    }
}
