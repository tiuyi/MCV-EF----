using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace JDF.Finance.Common
{
    /// <summary>
    /// Summary description for Log
    /// </summary>
    /// 
    public class Log
    {
        /// <summary>
        /// 业务操作记录
        /// </summary>
        /// <param name="Mess">输入要记录的信息</param>
        public void BussinessActionLog(string Mess)
        {
            Mess += "\r\n来源IP:" + Misc.GetRealIPAddress();
            log4net.ILog log = log4net.LogManager.GetLogger("WebLogger");
            log.Info(Mess);
          

        }
        /// <summary>
        /// 当前错误信息
        /// </summary>
        /// <param name="Mess">输入要记录的信息</param>
        public void ErrorMess(string Mess)
        {
            Mess += "\r\n来源IP:" + Misc.GetRealIPAddress() + ",来源页面:" + System.Web.HttpContext.Current.Request.Path;
            log4net.ILog log = log4net.LogManager.GetLogger("ErrorLogger");
            log.Error(Mess);

        }

        /// <summary>
        /// 操作信息
        /// </summary>
        /// <param name="Mess">输入要记录的信息</param>
        public void Action(string Mess)
        {
            Mess += "\r\n来源IP:" + Misc.GetRealIPAddress() + ",来源页面:" + System.Web.HttpContext.Current.Request.Path;
            log4net.ILog log = log4net.LogManager.GetLogger("ActionLogger");
            log.Info(Mess);
        }

    }
}