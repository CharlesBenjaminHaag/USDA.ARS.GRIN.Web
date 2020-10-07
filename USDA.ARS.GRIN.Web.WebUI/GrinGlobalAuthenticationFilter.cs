using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using USDA.ARS.GRIN.Web.Models;

namespace USDA.ARS.GRIN.Web
{
    public class GrinGlobalAuthentication : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            GRINUser authenticatedUser = filterContext.HttpContext.Session["AUTHENTICATED_USER"] as GRINUser;

            if (authenticatedUser == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Admin", action = "Login" }));
            }
          
            base.OnActionExecuting(filterContext);
        }
    }
}