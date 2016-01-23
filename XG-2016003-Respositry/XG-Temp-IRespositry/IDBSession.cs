using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XG.Temp.IRespositry
{
    /// <summary>
    /// 数据层接口
    /// </summary>
    public partial interface IDBSession
    {
        int SaveChange();
    }
}
