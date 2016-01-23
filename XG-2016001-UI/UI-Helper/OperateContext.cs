 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using XG.Temp.Iservices;

namespace XG.Temp.Helper
{
    public class OperateContext
    {
        public IBLLSession BLLSession;

        public OperateContext()
        {
            BLLSession = DI.AutoFacHelper.GetObject<IBLLSession>("BLLSession");
        }

        /// <summary>
        /// 获取当前 操作上下文 (为每个处理浏览器请求的服务器线程 单独创建 操作上下文)
        /// </summary>
        public static OperateContext Current
        {
            get
            {
                OperateContext oContext = CallContext.GetData(typeof(OperateContext).Name) as OperateContext;
                if (oContext == null)
                {
                    oContext = new OperateContext();
                    CallContext.SetData(typeof(OperateContext).Name, oContext);
                }
                return oContext;
            }
        }
    }
}
