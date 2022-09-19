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
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult _CropGermplasmCommitteeList()
        {
            return PartialView("~/Views/Admin/CropGermplasmCommittee/_List.cshtml");
        }

        public PartialViewResult _CropGermplasmCommitteeDocumentList()
        {
            CropGermplasmCommitteeDocumentViewModel viewModel = new CropGermplasmCommitteeDocumentViewModel();
            viewModel.Search();
            return PartialView("~/Views/Admin/CropGermplasmCommitteeDocument/_List.cshtml", viewModel);
        }

        public ActionResult CropGermplasmCommitteeDocumentEdit(int entityId)
        {
            try
            {
                //TODO
                CropGermplasmCommitteeDocumentViewModel viewModel = new CropGermplasmCommitteeDocumentViewModel();
                viewModel.SearchEntity.ID = entityId;
                viewModel.Search();
                return View("~/Views/Admin/CropGermplasmCommitteeDocument/Edit.cshtml", viewModel);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}