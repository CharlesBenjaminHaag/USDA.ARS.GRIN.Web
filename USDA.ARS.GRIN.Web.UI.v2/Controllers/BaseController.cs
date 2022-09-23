using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USDA.ARS.GRIN.Web.DataLayer;
using USDA.ARS.GRIN.Web.WebUI;
using NLog;

namespace USDA.ARS.GRIN.Web.UI.v2.Controllers
{
    public class BaseController : Controller
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        public SysUser AuthenticatedUser
        {
            get
            {
                AuthenticatedUserSession authenticatedUserSession = null;

                if (Session != null)
                {
                    if (Session["AUTHENTICATED_USER_SESSION"] != null)
                    {
                        authenticatedUserSession = Session["AUTHENTICATED_USER_SESSION"] as AuthenticatedUserSession;
                    }
                }
                return authenticatedUserSession.User;
            }
        }

        [HttpGet]
        public ActionResult Refresh()
        {
            if (Session["type"] != null && Session["resulttype"] != null)
                return View();
            else
                return Redirect(Request.UrlReferrer.ToString());
        }

        public string GetBaseUrl()
        {
            var request = Request;
            var appUrl = HttpRuntime.AppDomainAppVirtualPath;

            if (appUrl != "/")
                appUrl = "/" + appUrl;

            var baseUrl = string.Format("{0}://{1}{2}",
                request.Url.Scheme, //request.Url.Scheme gives https or http
                request.Url.Authority, //request.Url.Authority gives qawithexperts/com
                appUrl); //appUrl = /questions/111/ok-this-is-url

            return baseUrl; //this will return complete url
        }
    }
}