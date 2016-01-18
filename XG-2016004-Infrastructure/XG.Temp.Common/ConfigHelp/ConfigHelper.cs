using System;
using System.Configuration;
using System.Web;

namespace JDF.Finance.Common
{
    /// <summary>
    /// web.config操作类
    /// 李天平
    /// 2004.8
    /// </summary>
    public sealed class ConfigHelper
    {
        /// <summary>
        /// 得到AppSettings中的配置字符串信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConfigString(string key)
        {
            string CacheKey = "AppSettings-" + key;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                objModel = ConfigurationManager.AppSettings[key];
                if (objModel != null)
                {
                    DateTime dtNew = DateTime.Now;
                    DataCache.SetCache(CacheKey, objModel, dtNew.AddHours(2) - dtNew);
                }
            }
            return objModel.ToString();
        }

        /// <summary>
        /// 得到AppSettings中的配置Bool信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool GetConfigBool(string key)
        {
            bool result = false;
            string cfgVal = GetConfigString(key);
            if (null != cfgVal && string.Empty != cfgVal)
            {
                result = bool.Parse(cfgVal);
            }
            return result;
        }
        /// <summary>
        /// 得到AppSettings中的配置Decimal信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static decimal GetConfigDecimal(string key)
        {
            decimal result = 0;
            string cfgVal = GetConfigString(key);
            if (null != cfgVal && string.Empty != cfgVal)
            {
                result = decimal.Parse(cfgVal);
            }

            return result;
        }
        /// <summary>
        /// 得到AppSettings中的配置int信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int GetConfigInt(string key)
        {
            int result = 0;
            string cfgVal = GetConfigString(key);
            if (null != cfgVal && string.Empty != cfgVal)
            {
                result = int.Parse(cfgVal);
            }

            return result;
        }
        /// <summary>
        /// 设置AppSettings中的配置int信息 不存在则添加
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static void SetValue(string AppKey, string AppValue)
        {
            DataCache.RemoveCache("AppSettings-" + AppKey);
            System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();

            xDoc.Load(HttpContext.Current.Server.MapPath("/CommonLib.config"));

            System.Xml.XmlNode xNode;
            System.Xml.XmlElement xElem1;
            System.Xml.XmlElement xElem2;
            xNode = xDoc.SelectSingleNode("//appSettings");

            xElem1 = (System.Xml.XmlElement)xNode.SelectSingleNode("//add[@key='" + AppKey + "']");
            if (xElem1 != null) xElem1.SetAttribute("value", AppValue);
            else
            {
                xElem2 = xDoc.CreateElement("add");
                xElem2.SetAttribute("key", AppKey);
                xElem2.SetAttribute("value", AppValue);
                xNode.AppendChild(xElem2);
            }
            xDoc.Save(HttpContext.Current.Server.MapPath("/CommonLib.config"));
            DateTime dtNew = DateTime.Now;
            DataCache.SetCache("AppSettings-" + AppKey, AppValue, dtNew.AddHours(2) - dtNew);
        }
    }
}
