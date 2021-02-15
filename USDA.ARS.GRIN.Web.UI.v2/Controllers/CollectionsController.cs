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
            return View("~/Views/Collections/Index.cshtml");
        }
    }
}