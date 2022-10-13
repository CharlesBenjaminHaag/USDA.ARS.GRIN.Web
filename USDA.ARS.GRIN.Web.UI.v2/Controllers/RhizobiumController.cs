using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USDA.ARS.GRIN.Web.ViewModelLayer;
using NLog;

namespace USDA.ARS.GRIN.Web.UI.v2.Controllers
{
    public class RhizobiumController : Controller
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        public ActionResult Index()
        {
            TempData["PAGE_CONTEXT"] = "Rhizobium Collection";
           
            try
            {
                RhizobiumViewModel viewModel = new RhizobiumViewModel();
                viewModel.Search();
                return View(viewModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }
        }
    }
}