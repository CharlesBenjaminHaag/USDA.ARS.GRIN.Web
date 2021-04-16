using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;
using USDA.ARS.GRIN.Web;
using USDA.ARS.GRIN.Web.Models;
using USDA.ARS.GRIN.Web.WebUI;
using USDA.ARS.GRIN.Web.WebUI.ViewModels;
using USDA.ARS.GRIN.Web.WebUI.ViewModels.CGC;
using USDA.ARS.GRIN.Web.Repository;
using USDA.ARS.GRIN.Web.Service;
using System.Security.Authentication;
using System.Runtime.CompilerServices;

namespace USDA.ARS.GRIN.Web.WebUI.Controllers
{
    public class CGCController : BaseController
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        Repository.CGCRepository _repository = new Repository.CGCRepository();
        SecurityService _securityService = new SecurityService();

        public ActionResult Index()
        {
            List<CropGermplasmCommittee> cropGermplasmCommitteeList = new List<CropGermplasmCommittee>();

            try
            {
                cropGermplasmCommitteeList = _repository.List();
                return View(cropGermplasmCommitteeList);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                string errorText = "<label>Controller:</label>" + controllerName;
                errorText = errorText + "<br><label>Action:</label>" + actionName;
                errorText = errorText + "<br><label>Details:</label>" + ex.TargetSite + ex.Message;
                Session["ERROR_TEXT"] = errorText;
                return RedirectToAction("InternalServerError", "Error");
            }
        }

        public ActionResult Detail(int id)
        {
            CropGermplasmCommittee viewModel = new CropGermplasmCommittee();

            try
            {
                viewModel = _repository.Detail(id);
                return View(viewModel);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message + ex.StackTrace);
                return View("~/Views/Shared/Error.cshtml");
            }
        }
    }
}