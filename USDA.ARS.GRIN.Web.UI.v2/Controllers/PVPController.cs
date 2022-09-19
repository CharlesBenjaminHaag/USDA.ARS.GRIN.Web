using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USDA.ARS.GRIN.Web.ViewModelLayer;
using NLog;

namespace USDA.ARS.GRIN.Web.UI.v2.Controllers
{
    public class PVPController : Controller
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        // GET: PVP
        public ActionResult Index()
        {
            PVPApplicationViewModel viewModel = new PVPApplicationViewModel();
            TempData["PAGE_CONTEXT"] = "PVP Application Status Database";
            try
            {
                return View(viewModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }
        }

        public ActionResult Detail(int id)
        {
            PVPApplicationViewModel viewModel = new PVPApplicationViewModel();
            TempData["PAGE_CONTEXT"] = "PVP Application Detail";
            return View(viewModel);
        }

        public ActionResult Search()
        {
            return View();
        }

        public PartialViewResult _List(FormCollection formCollection)
        {
            PVPApplicationViewModel viewModel = new PVPApplicationViewModel();
            TempData["PAGE_CONTEXT"] = "PVP Application Status Database";
            try
            {
                viewModel.Search();
                return PartialView("~/Views/PVP/_List.cshtml", viewModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return PartialView("~/Views/Error/_InternalServerError.cshtml");
            }
        }
    }
}