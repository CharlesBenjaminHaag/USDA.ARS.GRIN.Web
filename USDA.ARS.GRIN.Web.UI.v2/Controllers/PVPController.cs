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
                viewModel.GetTotals();
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

        public ActionResult Search(string status = "")
        {
            TempData["PAGE_CONTEXT"] = "PVP Application Search";
            PVPApplicationViewModel viewModel = new PVPApplicationViewModel();
          
            if (!String.IsNullOrEmpty(status))
            {
                viewModel.SearchEntity.CertificateStatus = status;
                viewModel.SearchEntity.StatusDateRange = "01Y";
                viewModel.Search();
            }
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Search(PVPApplicationViewModel viewModel)
        {
            try
            {
                TempData["PAGE_CONTEXT"] = "PVP Application Search";
                viewModel.Search();
                ModelState.Clear();
                return View(viewModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }
        }

        public PartialViewResult _List(FormCollection formCollection)
        {
            PVPApplicationViewModel viewModel = new PVPApplicationViewModel();
            TempData["PAGE_CONTEXT"] = "PVP Application Status Database";
            try
            {
                if (!String.IsNullOrEmpty(formCollection["TimeFrame"]))
                {
                    viewModel.SearchEntity.TimeFrame = formCollection["TimeFrame"];
                }

                if (!String.IsNullOrEmpty(formCollection["StatusList"]))
                {
                    viewModel.SearchEntity.CertificateStatusList = formCollection["StatusList"];
                }

                viewModel.Search();
                return PartialView("~/Views/PVP/_List.cshtml", viewModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return PartialView("~/Views/Error/_InternalServerError.cshtml");
            }
        }

        public PartialViewResult _ListTotals()
        {
            PVPApplicationViewModel viewModel = new PVPApplicationViewModel();
            try
            {
                viewModel.GetTotals();
                return PartialView("~/Views/PVP/_ListByStatus.cshtml", viewModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return PartialView("~/Views/Error/_InternalServerError.cshtml");
            }
        }
    }
}