using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacion.Filters
{
    public class CheckSessionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["centro educativo"] == null)
            {
                filterContext.Controller.TempData["ShowSessionExpiredToast"] = true;
                filterContext.Result = new RedirectResult("~/Home");
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // No necesitamos hacer nada aquí en este caso
        }
    }
}