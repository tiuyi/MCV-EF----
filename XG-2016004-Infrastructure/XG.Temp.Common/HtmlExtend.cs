using JDF.Finance.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;



namespace System.Web.Mvc
{
    public static class HtmlExtend
    {
        #region  帐套控件
        /// <summary>
        /// 帐套控件 HTML扩展方法
        /// </summary>
        /// <param name="html"></param>
        /// <param name="mutil"></param>
        /// <param name="inputId"></param>
        /// <param name="initAgentID"></param>
        /// <param name="initAgentName"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public static MvcHtmlString FinancePlugin(this HtmlHelper html, bool mutil = false, string inputId = "agents", bool IsHas = false, string initAgentID = "",
            string initAgentName = "", bool initCurrentYear = false, int height = 450, int width = 171)
        {          
            string txt = @"<span class='textbox'><input class='form-control input-sm' type='text' IsMutil=" + mutil +
                  " btnserchid='" + inputId + "search' IsHasValue='" + IsHas + "' initCurrentYear='" + initCurrentYear + "'   value='" + initAgentName + "'  id='" + inputId + "' name='" + inputId + "_name'  Financeids='" + initAgentID +
                  "' Financenames='" + initAgentName + "' /> <input type='hidden' id='" + inputId + "_s' value='" + initAgentID + "' name='" + inputId +
                  "' /> </span>";
            string a = @"<span class='textbox'><span  style=' position:absolute; top :0px; right: 1px;'>"
                   + "<a  onclick='AddFrnancePlug()'  class='AAtextbox-icon' icon-index='0' tabindex='-1'"
                   + "style='width: 15px; height: 34px;' DailogID=" + inputId + "ddAgent InputID=" + inputId + " id='" + inputId + "search'>"
                   + " <i class='fa fa-search'></i>  </a></span><input style='padding-right:24px;' class='form-control input-sm' type='text' IsMutil=" + mutil +
                   " btnserchid='" + inputId + "search' IsHasValue='" + IsHas + "' initCurrentYear='" + initCurrentYear + "'   value='" + initAgentName + "'  id='" + inputId + "' name='" + inputId + "_name'  Financeids='" + initAgentID + 
                   "' Financenames='" + initAgentName + "' /> <input type='hidden' id='" + inputId + "_s' value='" + initAgentID + "' name='" + inputId +
                   "' /> </span>";


            if (mutil)
                return MvcHtmlString.Create(a);
            else
                return MvcHtmlString.Create(txt);
        }
        #endregion


        #region  科目控件
        /// <summary>
        /// 科目控件 HTML扩展方法
        /// </summary>
        /// <param name="html"></param>
        /// <param name="mutil"></param>
        /// <param name="inputId"></param>
        /// <param name="initProID"></param>
        /// <param name="initProName"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public static MvcHtmlString ProjectPlugin(this HtmlHelper html, bool mutil = false, string inputId = "agents",
            string initProID = "", string initProName = "", int height = 450, int width = 171)
        {
            string txt = @"<span class='textbox'><input class='form-control input-sm' type='text' IsMutil=" + mutil + " btnserchid='" + inputId + "search'    value='" +
                   initProName + "'  id='" + inputId + "'  name='" + inputId + "_name' Projectids='" + initProID + "' Projectnames='" + initProName +
                   "' /> <input type='hidden' id='" + inputId + "_s' value='" + initProID + "' name='" + inputId + "' /> </span>";

            string a = @"<span class='textbox'><span  style=' position:absolute; top :0px; right: 1px;'>"
                   + "<a  onclick='AddFinaProjectPlug()'  class='AAtextbox-icon' icon-index='0' tabindex='-1'"
                   + "style='width: 15px; height: 34px;' DailogID=" + inputId + "ddAgent InputID=" + inputId + " id='" + inputId +
                   "search'>  <i class='fa fa-search'></i>  </a></span><input style='padding-right:24px;' " +
                   " class='form-control input-sm' type='text' IsMutil=" + mutil + " btnserchid='" + inputId + "search'    value='" +
                   initProName + "'  id='" + inputId + "'  name='" + inputId + "_name' Projectids='" + initProID + "' Projectnames='" + initProName +
                   "' /> <input type='hidden' id='" + inputId + "_s' value='" + initProID + "' name='" + inputId + "' /> </span>";


            if (mutil)
                return MvcHtmlString.Create(a);
            else
                return MvcHtmlString.Create(txt);
        }
        #endregion

        #region  客户控件

        public static MvcHtmlString CustomPlugin(this HtmlHelper html, bool mutil = false, string inputId = "Costoms", bool IsHas = false, string initAgentID = "",
            string initAgentName = "", int height = 450, int width = 171)
        {
            string txt = @"<span class='textbox' style='width: " + (width + 8) +
                "px; height: 20px;'><input class='textbox-text txt_SelectAgent' IsMutil=" + mutil + " type='text' autocomplete='off' placeholder='' style='margin-left: 0px; margin-right: 0px; padding-top: 2px; padding-bottom: 2px; width: " + width + "px;' value='" + initAgentName + "' id='" + inputId + "' agentids='" + initAgentID + "' name='" + inputId + "_name' agentnames='" + initAgentName + "'><input type='hidden' value='" + initAgentID + "' name='" + inputId + "' /></span>";

            string a = @"<span class='textbox'><span  style=' position:absolute; top :0px; right: 1px;'>"
                   + "<a  onclick='AddCustomPlug()'  class='AAtextbox-icon' icon-index='0' tabindex='-1'"
                   + "style='width: 15px; height: 34px;' DailogID=" + inputId + "ddAgent InputID=" + inputId + " id='" + inputId + "search'>"
                   + " <i class='fa fa-search'></i>  </a></span><input style='padding-right:24px;' class='form-control input-sm'   type='text' IsMutil=" + mutil +
                   " btnserchid='" + inputId + "search'  IsHasValue='" + IsHas + "'  value='" + initAgentName + "'  id='" + inputId + "' name='" + inputId + "_name'  Customids='" + initAgentID +
                   "' Customnames='" + initAgentName + "' /> <input type='hidden' id='" + inputId + "_s' value='" + initAgentID + "' name='" + inputId +
                   "' /> </span>";


            if (mutil)
                return MvcHtmlString.Create(a);
            else
                return MvcHtmlString.Create(txt);
        }
        #endregion

        /// <summary>
        /// 科目配置
        /// </summary>
        /// <param name="html"></param>
        /// <param name="mutil">是否多选</param>
        /// <param name="inputId">文本ID</param>
        /// <param name="initProID"></param>
        /// <param name="initProName"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public static MvcHtmlString SetProjectPlugIn(this HtmlHelper html, bool mutil = false, string inputId = "agents",
         string initProID = "", string initProName = "", int height = 450, int width = 171)
        {
          //  string txt = @"<span class='textbox' style='width: " + (width + 8) +
          //      "px; height: 20px;'><input class='textbox-text txt_SelectAgent SetProjectPl' IsMutil=" + mutil +
          //      " type='text' autocomplete='off' placeholder=''  style='margin-left: 0px; margin-right: 0px;"
          //+ " padding-top: 2px; padding-bottom: 2px; width: " + width + "px;' value='" + initProName +
          //  "' id='" + inputId + "' Projectids='" + initProID + "' name='" + inputId + "_name' Projectnames='" + initProName +
          //      "'><input type='hidden' id='"+inputId+"_s'  value='" + initProID + "' name='" + inputId + "' /></span>";

            string txt = @"<span class='textbox' style='  height: 34px;'><input style='padding-right:24px;' " +
                   " class='form-control input-sm SetProjectPl' type='text' IsMutil=" + mutil + " btnserchid='" + inputId + "search'    value='" +
                   initProName + "'  id='" + inputId + "'  name='" + inputId + "_name' Projectids='" + initProID + "' Projectnames='" + initProName +
                   "' /> <input type='hidden' id='" + inputId + "_s' value='" + initProID + "' name='" + inputId + "' /> </span>";


            //if (mutil)
            //    return MvcHtmlString.Create(a);
            //else
                return MvcHtmlString.Create(txt);
        }



        /// <summary>
        ///  公司控件 HTML扩展方法
        /// </summary>
        /// <param name="html"></param>
        /// <param name="inputId"></param>
        /// <param name="initCompanyID"></param>
        /// <param name="initCompanyName"></param>
        /// <returns></returns>
        public static MvcHtmlString CompanyPlugin(this HtmlHelper html,  string inputId = "agents", string initCompanyID = "",
            string initCompanyName = "")
        {

            string txt = @"<span class='textbox'><input style='padding-right:24px;' class='form-control input-sm' type='text'  btnserchid='" + inputId +
                "search'    value='" + initCompanyName + "'  id='" + inputId + "' name='" + inputId + "_name'  /> <input type='hidden' id='" + inputId + "_s' value='" + initCompanyID + "' name='" + inputId +
                   "' /></span>";

//<input class='textbox-text txt_SelectAgent'  type='text' autocomplete='off' placeholder=''
//            style='margin-left: 0px; margin-right: 0px; padding-top: 2px; padding-bottom: 2px; width:180px;' value='" + initCompanyName + "' id='" + inputId +
//           "' name='" + inputId + "_name' ><input type='hidden' value='" + initCompanyID + "' name='" + inputId + "' /></span>";
             
                return MvcHtmlString.Create(txt);
        }


        /// <summary>
        /// 给JS或Css文件加上版本号
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="Js"></param>
        /// <returns></returns>
        public static MvcHtmlString JsCssRander(this HtmlHelper htmlHelper, string JsCss)
        {  //js版本号
            string v = ConfigHelper.GetConfigString("JSVersion");
            JsCss = JsCss.Replace(".js", ".js?v=" + v).Replace(".css", ".css?v=" + v);
            return MvcHtmlString.Create(JsCss);
        }

         

    }
}
