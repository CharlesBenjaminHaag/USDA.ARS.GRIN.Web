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
    public class ContactController : Controller
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        // GET: Contact
        public ActionResult Index()
        {
            TempData["PAGE_CONTEXT"] = "Contact Us";
            ContactViewModel viewModel = new ContactViewModel();
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Send(ContactViewModel viewModel)
        {
            try
            {
                viewModel.SendMessage();
                TempData["PAGE_CONTEXT"] = "Contact Us";
                return View("~/Views/Contact/Confirm.cshtml");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }
        }
    }
}