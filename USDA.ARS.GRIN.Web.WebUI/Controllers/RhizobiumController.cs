using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using USDA.ARS.GRIN.Web.Models;
using USDA.ARS.GRIN.Web.WebUI.ViewModels;
using USDA.ARS.GRIN.Web.Repository;
using USDA.ARS.GRIN.Web.Service;

namespace USDA.ARS.GRIN.Web.WebUI.Controllers
{
    public class RhizobiumController : BaseController
    {
        private RhizobiumRepository _repository = new RhizobiumRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(RhizobiumSearchViewModel viewModel)
        {
            Session["RhizobiumSearchResults"] = null;
            viewModel.SearchResults = _repository.Search(viewModel.SearchString);
            Session["RhizobiumSearchResults"] = viewModel.SearchResults;
            return PartialView("~/Views/Rhizobium/_SearchResults.cshtml", viewModel);
        }

        public ActionResult _LeftNavRhizobium()
        {
            List<RhizobiumDescriptor> hostPlants = new List<RhizobiumDescriptor>();

            hostPlants = _repository.GetHostPlants();

            return PartialView(hostPlants);
        }

        public ActionResult Detail(string plantName)
        {
            RhizobiumDetailViewModel viewModel = new RhizobiumDetailViewModel();
            viewModel.HostPlantName = plantName;
            viewModel.RhizobiumDescriptors = _repository.Detail(plantName);
            return PartialView("~/Views/Rhizobium/_Detail.cshtml", viewModel);
        }

        public ActionResult Export()
        {
            return RenderExcel("RhizobiumSearchResults");
        }
       
    }
}