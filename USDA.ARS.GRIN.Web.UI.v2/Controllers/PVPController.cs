using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USDA.ARS.GRIN.Web.ViewModelLayer;

namespace USDA.ARS.GRIN.Web.UI.v2.Controllers
{
    public class PVPController : Controller
    {
        
        // GET: PVP
        public ActionResult Index()
        {
            TempData["PAGE_CONTEXT"] = "PVP Application Status Database";
            return View();
        }

        public ActionResult Detail(int id)
        {
            TempData["PAGE_CONTEXT"] = "PVP Application Detail";
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        public PartialViewResult _List(FormCollection formCollection)
        {
            PVPApplicationViewModel viewModel = new PVPApplicationViewModel();

            //TODO

            return PartialView("~/Views/PVP/_List.cshtml",viewModel);
        }
    }
}