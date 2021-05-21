using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USDA.ARS.GRIN.Web.Service;
using USDA.ARS.GRIN.Web.Models;

namespace USDA.ARS.GRIN.Web.UI.v2.Controllers
{
    public class PVPController : Controller
    {
        
        // GET: PVP
        public ActionResult Index()
        {
            TempData["PAGE_CONTEXT"] = "PVP Application Status Database";
            return View();
        }

        public ActionResult Detail(int id)
        {
            TempData["PAGE_CONTEXT"] = "PVP Application Detail";
            return View();
        }

        public PartialViewResult _List(string context)
        {
            PVPService pVPService = new PVPService();
            List<PVPApplication> pVPApplications = new List<PVPApplication>();

            try 
            {
                pVPApplications = pVPService.List(context);
            }
            catch (Exception ex)
            {
            }
            return PartialView("~/Views/PVP/_List.cshtml", pVPApplications);
        }
    }
}