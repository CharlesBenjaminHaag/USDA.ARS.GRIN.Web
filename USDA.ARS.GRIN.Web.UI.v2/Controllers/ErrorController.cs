using System.Web.Mvc;
using System;
using System.Collections.Generic;
using USDA.ARS.GRIN.Web.ViewModelLayer;
using USDA.ARS.GRIN.Web.DataLayer;
using NLog;

namespace USDA.ARS.GRIN.Web.UI.v2.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult _Error()
        {
            var exception = Server.GetLastError();
            return PartialView();
        }

        [HttpGet]
        public ActionResult InternalServerError()
        {
            TempData["PAGE_CONTEXT"] = "Error";
            return View("~/Views/Error/Error500.cshtml");
        }
    }
}