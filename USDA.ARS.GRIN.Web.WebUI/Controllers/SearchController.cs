using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USDA.ARS.GRIN.Web.WebUI.ViewModels;
using USDA.ARS.GRIN.Web.Repository;
using USDA.ARS.GRIN.Web.Service;

namespace USDA.ARS.GRIN.Web.WebUI.Controllers
{
    public class SearchController : BaseController
    {
        Repository.GRINRepository _repository = new Repository.GRINRepository();

        // GET: Search
        public ActionResult rhizobium()
        {
            RhizobiumSearchViewModel viewModel = new RhizobiumSearchViewModel();
            viewModel.PageAction = "INIT";
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Rhizobium(RhizobiumSearchViewModel viewModel)
        {

            viewModel.SearchResults = _repository.SearchRhizobium(viewModel.SearchString);

            return View(viewModel);
        }
    }
}