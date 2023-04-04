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

        public PartialViewResult _List(string formatCode="")
        {
            try
            {
                SiteViewModel viewModel = new SiteViewModel();
                viewModel.SearchEntity.FormatCode = formatCode;
                viewModel.SearchEntity.IDList = "1,2,3,4,5,6,7,8,9,13,15,16,17,19,22,24,26,29,31,34,37,40";
                viewModel.Search();
                return PartialView(viewModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return PartialView("~/Views/Error/_InternalServerError.cshtml");
            }
        }
        [HttpPost]
        public PartialViewResult _Detail(int siteId)
        {
            SiteViewModel viewModel = new SiteViewModel();

            try
            {
                viewModel.Get(siteId);
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