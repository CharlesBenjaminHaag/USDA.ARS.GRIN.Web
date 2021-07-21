using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USDA.ARS.GRIN.Web.Models;
using USDA.ARS.GRIN.Web.WebUI.ViewModels;
using USDA.ARS.GRIN.Web.Repository;

namespace USDA.ARS.GRIN.Web.WebUI.Controllers
{
    public class PagesController : BaseController
    {
        public CollectionRepository _collectionRepository = new CollectionRepository();

        // GET: Pages

        public ActionResult OperatingStatus()
        {
            return View();
        }
        
        public ActionResult Collections()
        {
            CollectionsViewModel viewModel = new CollectionsViewModel();
            viewModel.CollectionSites = _collectionRepository.List();
            return View(viewModel);
        }

        public ActionResult NGRAC()
        {
            return View();
        }

        public ActionResult NMGP()
        {
            return View();
        }

        public ActionResult NGRP()
        {
            return View();
        }

        public ActionResult NGODirectory()
        {
            return View();
        }

        public ActionResult Repositories()
        {
            return View();
        }

        public ActionResult CGC()
        {
            return View();
        }

        public ActionResult GRINU()
        {
            return View();
        }

    }
}