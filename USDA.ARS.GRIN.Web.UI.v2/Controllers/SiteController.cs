using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USDA.ARS.GRIN.Web.DataLayer;
using USDA.ARS.GRIN.Web.ViewModelLayer;
using NLog;

namespace USDA.ARS.GRIN.Web.UI.v2.Controllers
{
    public class SiteController : Controller
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult _Detail(FormCollection formCollection)
        {
            SiteViewModel viewModel = new SiteViewModel();

            try
            {
                if (!String.IsNullOrEmpty(formCollection["SiteID"]))
                {
                    viewModel.Get(Int32.Parse(formCollection["SiteID"]));
                }
                return PartialView("~/Views/Site/_Detail.cshtml", viewModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return PartialView("~/Views/Site/_Detail.cshtml");
            }
        }
    }
}