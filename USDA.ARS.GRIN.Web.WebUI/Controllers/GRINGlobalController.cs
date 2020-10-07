using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USDA.ARS.GRIN.Web.Models;
using USDA.ARS.GRIN.Web.WebUI.ViewModels;
using USDA.ARS.GRIN.Web.Repository;
using USDA.ARS.GRIN.Web.Service;
using System.Text;

namespace USDA.ARS.GRIN.Web.WebUI.Controllers
{
    public class GRINGlobalController : BaseController
    {
        // GET: GRINGlobal
        public ActionResult Index()
        {
            return View();
        }
    }
}

        //public ActionResult AccountRequest()
        //{
        //    AccountRequestViewModel viewModel = new AccountRequestViewModel();
        //    return View(viewModel);
        //}

        //[HttpPost]
        //public ActionResult AccountRequest(AccountRequestViewModel viewModel)
        //{
        //    MailService mailService = new MailService();
        //    StringBuilder sbEmailBody = new StringBuilder();

        //    if (!ModelState.IsValid)
        //    {
        //        return View("~/Views/GRINGlobal/AccountRequest.cshtml", viewModel);
        //    }

        //    try
        //    {
        //        if (viewModel != null)
        //        {
                    
        //            sbEmailBody.Append("<h4>GRIN Account Request</h4>");
        //            sbEmailBody.Append("<table>");
        //            sbEmailBody.Append("<tr>");
        //            sbEmailBody.Append("<td>");
        //            sbEmailBody.Append("<span style='font-weight:bold;'>");
        //            sbEmailBody.Append("Request Type");
        //            sbEmailBody.Append("</span>");
        //            sbEmailBody.Append("</td>");
        //            sbEmailBody.Append("<td>");
        //            sbEmailBody.Append(viewModel.RequestType);
        //            sbEmailBody.Append("</td>");
        //            sbEmailBody.Append("</tr>");

        //            sbEmailBody.Append("<tr>");
        //            sbEmailBody.Append("<td>");
        //            sbEmailBody.Append("<span style='font-weight:bold;'>");
        //            sbEmailBody.Append("Environment");
        //            sbEmailBody.Append("</span>");
        //            sbEmailBody.Append("</td>");
        //            sbEmailBody.Append("<td>");
        //            sbEmailBody.Append(viewModel.Environment);
        //            sbEmailBody.Append("</td>");
        //            sbEmailBody.Append("</tr>");

        //            sbEmailBody.Append("<tr>");
        //            sbEmailBody.Append("<td>");
        //            sbEmailBody.Append("<span style='font-weight:bold;'>");
        //            sbEmailBody.Append("Requestor Email");
        //            sbEmailBody.Append("</span>");
        //            sbEmailBody.Append("</td>");
        //            sbEmailBody.Append("<td>");
        //            sbEmailBody.Append(viewModel.RequestorEmail);
        //            sbEmailBody.Append("</td>");
        //            sbEmailBody.Append("</tr>");

        //            sbEmailBody.Append("<tr>");
        //            sbEmailBody.Append("<td>");
        //            sbEmailBody.Append("<span style='font-weight:bold;'>");
        //            sbEmailBody.Append("Requestor Name");
        //            sbEmailBody.Append("</span>");
        //            sbEmailBody.Append("</td>");
        //            sbEmailBody.Append("<td>");
        //            sbEmailBody.Append(viewModel.RequestorName);
        //            sbEmailBody.Append("</td>");
        //            sbEmailBody.Append("</tr>");

        //            sbEmailBody.Append("<tr>");
        //            sbEmailBody.Append("<td>");
        //            sbEmailBody.Append("<span style='font-weight:bold;'>");
        //            sbEmailBody.Append("Account Holder Email");
        //            sbEmailBody.Append("</span>");
        //            sbEmailBody.Append("</td>");
        //            sbEmailBody.Append("<td>");
        //            sbEmailBody.Append(viewModel.AccountHolderEmail);
        //            sbEmailBody.Append("</td>");
        //            sbEmailBody.Append("</tr>");

        //            sbEmailBody.Append("<tr>");
        //            sbEmailBody.Append("<td>");
        //            sbEmailBody.Append("<span style='font-weight:bold;'>");
        //            sbEmailBody.Append("Account Holder Name");
        //            sbEmailBody.Append("</span>");
        //            sbEmailBody.Append("</td>");
        //            sbEmailBody.Append("<td>");
        //            sbEmailBody.Append(viewModel.AccountHolderName);
        //            sbEmailBody.Append("</td>");
        //            sbEmailBody.Append("</tr>");

        //            sbEmailBody.Append("<tr>");
        //            sbEmailBody.Append("<td>");
        //            sbEmailBody.Append("<span style='font-weight:bold;'>");
        //            sbEmailBody.Append("Notes");
        //            sbEmailBody.Append("</span>");
        //            sbEmailBody.Append("</td>");
        //            sbEmailBody.Append("<td>");
        //            sbEmailBody.Append(viewModel.Notes);
        //            sbEmailBody.Append("</td>");
        //            sbEmailBody.Append("</tr>");

        //            sbEmailBody.Append("</table>");
        //        }
        //        mailService.SendMessage(sbEmailBody.ToString());
        //        log.Info("ACCOUNT REQUEST: " + sbEmailBody);
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex.Message + " " + ex.StackTrace);
        //    }
        //    viewModel.Status = "SUBMITTED";
        //    return View(viewModel);
        //}
   