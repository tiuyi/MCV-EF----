using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MemcachedProviders.Cache;
using Enyim.Caching;
using JDF.Finance.Model.FormatModel;
using Newtonsoft.Json;
 

namespace XG.Temp.Helper
{
    public class UserActionFilter : ActionFilterAttribute
    {
        public string ActionName { get; set; }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //string Flag = JDF_Common_Login.GetIfLogin("FIN");
            //if (Flag != "true")
            //{
            //    filterContext.Result = new RedirectResult(Flag);
            //}

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
