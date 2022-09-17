using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace USDA.ARS.GRIN.Web.UI.v2.Controllers
{
    public class PagesController : Controller
    {
        // GET: Pages
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NGRAC()
        {
            TempData["PAGE_CONTEXT"] = "National Genetic Resources Advisory Council (NGRAC)";
            return View();
        }
        public ActionResult GRINU()
        {
            TempData["PAGE_CONTEXT"] = "GRIN-U";
            return View();
        }
    }
}