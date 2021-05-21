﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace USDA.ARS.GRIN.Web.UI.v2.Controllers
{
    public class CGCController : Controller
    {
        // GET: CGC
        public ActionResult Index()
        {
            TempData["PAGE_CONTEXT"] = "Crop Germplasm Committees";
            return View();
        }
    }
}