using Enyim.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XG.Temp.Common
{
    public class MemcachedHelper
    {
        private static volatile MemcachedClient instance = null;
        public static MemcachedClient GetInstance()
        {
            // 通用的必要代码 iBatisNet双校检机制,如果实例不存在
            if (instance == null)
            {
                lock (typeof(MemcachedHelper))
                {
                    // 如果实例不存在
                    if (instance == null)
                        // 创建一个的实例
                        instance = new MemcachedClient();
                }
            }
            // 返回业务逻辑对象
            return instance;
        }

    }
}
