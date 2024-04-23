using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacion.Filters
{
    public class CheckSessionFilter : IActionFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["centro educativo"] == null)
            {
#if DEBUG
                filterContext.HttpContext.Session["centro educativo"] = 1;
#else
                filterContext.Controller.TempData["ShowSessionExpiredToast"] = true;
                filterContext.Result = new RedirectResult("~/Home");
#endif
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // No necesitamos hacer nada aquí en este caso
        }
    }
}