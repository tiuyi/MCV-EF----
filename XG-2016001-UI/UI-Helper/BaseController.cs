 
using JDF.Finance.Model.ApiModel;
using JDF.Finance.Model.FormatModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using XG.Temp.Common;

namespace XG.Temp.Helper
{
    [UserActionFilter]
    public class BaseController : Controller
    {

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

        public virtual ActionResult Index(int id = 0)
        {
            if (!GetPageAuth(id))
                return RedirectToAction("Page_404", "Main", new { area = "Admin" });
            return View();
        }

        public bool GetPageAuth(int PageID = 0)
        {
            if (PageID == 0) return false;
            if (GetAdminUser() == null) return false;
            string url = string.Format(ApiUrls.GetInstance().ActionURL, GetAdminUser().UserID, PageID);
            ViewBag.ActionPermission = ApiUrls.GetInstance().GetWebApiToObject<IList<ActionModel>>(url);
            return true;
        }

        /// <summary>
        /// 获取枚举选择列表
        /// </summary>
        /// <param name="t"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public List<SelectListItem> GetSelectList<T>(IList<T> sender, string valueField, string textField, SelectListItem item = null)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (item != null)
            {
                list.Add(item);
            }
            foreach (T m in sender)
            {
                PropertyInfo text = m.GetType().GetProperty(textField);
                PropertyInfo value = m.GetType().GetProperty(valueField);
                SelectListItem items = new SelectListItem()
                {
                    Text = text.GetValue(m, null).ToString(),
                    Value = value.GetValue(m, null).ToString()
                };
                list.Add(items);
            }
            return list;
        }

        /// <summary>
        /// 获取公司信息和账套信息
        /// </summary>
        /// <param name="isRedirect">是否自动跳转</param>
        /// <returns></returns>
        public ApplicationSession GetCurrentFinance(bool isRedirect = true)
        {
            ApplicationSession _ApplicationSession = null;
            if (Session["ApplicationSession"] == null)
            {
                if (isRedirect)
                    Response.Redirect("RedirectToCompany");
            }
            _ApplicationSession = Session["ApplicationSession"] as ApplicationSession;
            return _ApplicationSession;
            //else
            //{
            //    _ApplicationSession = Session["ApplicationSession"] as ApplicationSession;
            //    if (_ApplicationSession.FinanceID == 0)
            //    {
            //        if (isRedirect)
            //            Response.Redirect("RedirectToFinance");
            //    }
            //}
            //return _ApplicationSession;
        }

        public AdminUser GetAdminUser()
        {
            //string UserInfo = JDF_Common_Login.GetCurrentUser("FIN");
            //if (string.IsNullOrWhiteSpace(UserInfo))
            //    return null;
            //return JsonConvert.DeserializeObject<AdminUser>(UserInfo);
            return null;
        }

        public void ClearAdminUser()
        {
            //JDF_Common_Login.ClearCurrentUser("FIN");
        }

        public JavaScriptResult RedirectToFinance()
        {
            return JavaScript("window.top.changeFinance()");
        }

        public ActionResult RedirectToCompany()
        {
            return Content("window.top.changeCompany()", "text/javascript");
        }
    }
}
