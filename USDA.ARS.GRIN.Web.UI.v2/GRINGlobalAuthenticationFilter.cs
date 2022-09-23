using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace USDA.ARS.GRIN.Web.WebUI
{
    public class GrinGlobalAuthentication : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            AuthenticatedUserSession authenticatedUserSession = filterContext.HttpContext.Session["AUTHENTICATED_USER_SESSION"] as AuthenticatedUserSession;
            if (authenticatedUserSession == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Login", action = "Index" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}