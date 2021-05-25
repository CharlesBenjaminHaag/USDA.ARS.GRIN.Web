using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace USDA.ARS.GRIN.Web.UI.v2.Controllers
{
    public class RhizobiumController : Controller
    {
        // GET: Rhizobium
        public ActionResult Index()
        {
            TempData["PAGE_CONTEXT"] = "Rhizobium Collection";
            return View();
        }
    }
}