﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace USDA.ARS.GRIN.Web.WebUI.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult _TEMPLATE()
        {
            return View();
        }

        public ActionResult Index()
        {
            log.Info("TEST LOG ENTRY");
            return View();
        }

        public PartialViewResult _Banner()
        {
            return PartialView("~/Views/Shared/_Banner.cshtml");
        }

        public PartialViewResult _Breadcrumbs()
        {
            return PartialView("~/Views/Shared/_Breadcrumbs.cshtml");
        }
    }
}