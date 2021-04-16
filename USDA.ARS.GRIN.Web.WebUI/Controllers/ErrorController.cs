using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USDA.ARS.GRIN.Web.Models;

namespace USDA.ARS.GRIN.Web.WebUI.Controllers
{
    public class ErrorController : BaseController
    {
        [HttpGet]
        public ActionResult InternalServerError()
        {
            EmailMessage emailMessage = new EmailMessage();
            emailMessage.RecipientAddress = "benjamin.haag@usda.gov";
            emailMessage.SenderAddress = "benjamin.haag@usda.gov";
            emailMessage.Subject = "ARS-GRIN Site Error Notification";

            string errorDetailText = Session["ERROR_TEXT"].ToString();

            emailMessage.Body = "Error Message: " + errorDetailText;
            SendMessage(emailMessage);
            return View();
        }
    }
}