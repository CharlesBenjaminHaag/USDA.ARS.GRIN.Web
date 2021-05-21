using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace USDA.ARS.GRIN.Web.UI.v2.Controllers
{
    public class CollectionsController : Controller
    {
        // GET: Collections
        public ActionResult Index()
        {
            TempData["PAGE_CONTEXT"] = "Collections";
            return View("~/Views/Collections/Index.cshtml");
        }
    }
}