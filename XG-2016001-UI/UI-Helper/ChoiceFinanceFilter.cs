using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MemcachedProviders.Cache;
using Enyim.Caching;
using JDF.Finance.Model.FormatModel;

namespace XG.Temp.Helper
{
    public class ChoiceFinanceFilter : ActionFilterAttribute
    {
        public string ActionName { get; set; }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ApplicationSession _ApplicationSession = null;
            if (filterContext.HttpContext.Session["ApplicationSession"] == null)
            {
                filterContext.Result = new JavaScriptResult() { Script = "parent.changeCompany()" };
            }
            else
            {
                _ApplicationSession = filterContext.HttpContext.Session["ApplicationSession"] as ApplicationSession;
                if (_ApplicationSession.FinanceID == 0)
                {
                    filterContext.Result = new JavaScriptResult() { Script = "parent.changeCompany()" };
                }
            }
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //string contentType = filterContext.HttpContext.Response.ContentType;
            //if (contentType == "application/json")
            //{
            //    filterContext.HttpContext.Response.ContentType = "text/html";
            //}
            base.OnResultExecuted(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }
    }
}
