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
    public class CGCController : Controller
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        // GET: CGC
        public ActionResult Index()
        {
            try 
            { 
                CropGermplasmCommitteeViewModel viewModel = new CropGermplasmCommitteeViewModel();
                TempData["PAGE_CONTEXT"] = "Crop Germplasm Committees";
                return View();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }
        }

        public PartialViewResult _List()
        {
            try
            {
                CropGermplasmCommitteeViewModel viewModel = new CropGermplasmCommitteeViewModel();
                viewModel.Search();
                return PartialView(viewModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return PartialView("~/Views/Error/_InternalServerError.cshtml");
            }
        }

        public PartialViewResult _ListDocuments(int cropGermplasmCommitteeId)
        {
            try
            {
                CropGermplasmCommitteeDocumentViewModel viewModel = new CropGermplasmCommitteeDocumentViewModel();
                viewModel.SearchEntity.CropGermplasmCommitteeID = cropGermplasmCommitteeId;
                viewModel.Search();
                return PartialView(viewModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return PartialView("~/Views/Error/_InternalServerError.cshtml");
            }
        }
    }
}