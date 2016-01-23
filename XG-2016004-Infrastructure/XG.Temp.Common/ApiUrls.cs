using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace XG.Temp.Common
{
    public class ApiUrls
    {
        private static volatile ApiUrls m_instance = null;

        public static ApiUrls GetInstance()
        {
            // 通用的必要代码 iBatisNet双校检机制,如果实例不存在
            if (m_instance == null)
            {
                lock (typeof(ApiUrls))
                {
                    // 如果实例不存在
                    if (m_instance == null)
                        // 创建一个的实例
                        m_instance = new ApiUrls();
                }
            }
            // 返回业务逻辑对象
            return m_instance;
        }

        public ApiUrls()
        {
            var path = HttpContext.Current.Server.MapPath("~/ApiUrls.xml");
            var xDoc = XDocument.Load(path);
            var rootNode = xDoc.Element("urls");
            this.PageURL = rootNode.Element("PageURL").Value;
            this.ActionURL = rootNode.Element("ActionURL").Value;
            this.LoginURL = rootNode.Element("LoginURL").Value;
            this.OrderURL = rootNode.Element("OrderURL").Value;
            this.OrgURL = rootNode.Element("OrgURL").Value;
            this.CateGroupUrl = rootNode.Element("CateGroupUrl").Value;
            this.AttrUrl = rootNode.Element("AttrUrl").Value;
            this.getOrder_SURL = rootNode.Element("getOrder_SURL").Value; //销售订单生成凭证
            this.GetAgentType = rootNode.Element("GetAgentType").Value;
            this.GetAgentsUrl = rootNode.Element("GetAgents").Value;
            this.ResetOrderStatu = rootNode.Element("ResetOrderStatu").Value;
            this.ResetStatus = rootNode.Element("ResetStatus").Value;
            this.Provinces = rootNode.Element("Provinces").Value;
            this.Citys = rootNode.Element("Citys").Value;
        }

        #region 地址变量

        /// <summary>
        /// 页面权限
        /// </summary>
        public string PageURL { get; set; }
        /// <summary>
        /// 功能权限
        /// </summary>
        public string ActionURL { get; set; }
        /// <summary>
        /// 登陆地址
        /// </summary>
        public string LoginURL { get; set; }
        /// <summary>
        /// 获取订单地址
        /// </summary>
        public string OrderURL { get; set; }
        /// <summary>
        /// 数据权限
        /// </summary>
        public string OrgURL { get; set; }

        /// <summary>
        /// 类别组 （获取科目关系组）
        /// </summary>
        public string CateGroupUrl { get; set; }
        /// <summary>
        /// 属性地址
        /// </summary>
        public string AttrUrl { get; set; }

        /// <summary>
        /// 销售订单生成凭证
        /// </summary>
        public string getOrder_SURL { get; set; }

        /// <summary>
        /// 分销商类别
        /// </summary>
        public string GetAgentType { get; set; }

        /// <summary>
        /// 根据条件获取分销商
        /// </summary>
        public string GetAgentsUrl { get; set; }

        /// <summary>
        /// 调单后重新设置 财务调单标记
        /// </summary>
        public string ResetOrderStatu { get; set; }

        public string ResetStatus { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        public string Provinces { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        public string Citys { get; set; }
        #endregion

        #region 获取数据方法
        public T GetWebApiToObject<T>(string url)
        {
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            using (HttpClient httpClient = new HttpClient(handler))
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = httpClient.GetAsync(url);
                var responseJson = response.Result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(responseJson);
            }
        }

        public T PostWebApiToObject<T>(string url, Dictionary<string, string> dic)
        {
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            using (HttpClient httpClient = new HttpClient(handler))
            {
                FormUrlEncodedContent httpContext = null;
                if (dic != null)
                    httpContext = new FormUrlEncodedContent(dic);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = httpClient.PostAsync(url, httpContext);
                var responseJson = response.Result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(responseJson);
            }
        }

        //public string PostWebApi(string url, Dictionary<string, string> dic)
        //{
        //    var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
        //    using (HttpClient httpClient = new HttpClient(handler))
        //    {
        //        FormUrlEncodedContent httpContext = null;
        //        if (dic != null)
        //            httpContext = new FormUrlEncodedContent(dic);
        //        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        var response = httpClient.PostAsync(url, httpContext);
        //        var responseJson = response.Result.Content.ReadAsStringAsync().Result;
        //        return responseJson;
        //    }
        //}
        #endregion
    }
}
