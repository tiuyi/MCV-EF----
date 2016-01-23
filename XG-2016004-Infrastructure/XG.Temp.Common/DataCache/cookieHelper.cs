using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace XG.Temp.Common
{

    public class cookieHelper
    {
        #region cookie
        /// <summary>
        /// 删除cookie
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        public static bool DeleteCookie(string strName)
        {
            try
            {
                HttpCookie cookie = new HttpCookie(strName)
                {
                    Expires = DateTime.Now.AddDays(-1.0)
                };
                HttpContext.Current.Response.Cookies.Add(cookie);
                return true;
            }
            catch
            {
            }
            return false;
        }

        /// <summary>
        /// 获取cookie
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        public static string GetCookie(string strName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie != null)
            {
                return cookie.Value.ToString();
            }
            return "";
        }

        /// <summary>
        /// 设置cookie
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strValue"></param>
        /// <param name="strDay"></param>
        /// <returns></returns>
        public static bool SetCookie(string strName, string strValue, int strDay = 1)
        {
            try
            {
                HttpCookie cookie = new HttpCookie(strName)
                {
                    Expires = DateTime.Now.AddDays((double)strDay),
                    Value = strValue
                };
                HttpContext.Current.Response.Cookies.Add(cookie);
                return true;
            }
            catch
            {
            }
            return false;
        }
        #endregion
    }
}
