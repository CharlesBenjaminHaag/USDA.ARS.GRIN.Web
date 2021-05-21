using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace USDA.ARS.GRIN.Web.UI.v2.Controllers
{
    public class SiteController : Controller
    {
        // GET: Site
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _Detail(int id)
        {
            return PartialView("~/Views/Site/_Detail.cshtml");
        }
    }
}