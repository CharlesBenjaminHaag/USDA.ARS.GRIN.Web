using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace USDA.ARS.GRIN.Web.WebUI.ViewModels
{
    public class PVPBaseViewModel
    {
        public string GetApplicationStatusCSSClass(string applicationStatusDescription)
        {
            string applicationStatusCSSClass = String.Empty;

            switch (applicationStatusDescription)
            {
                case "Certificate Expired":
                case "Certificate Abandoned":
                case "Application Withdrawn":

                    applicationStatusCSSClass = "badge badge-success";
                    break;
                default:
                    applicationStatusCSSClass = "badge badge-danger";
                    break;
            }
            return applicationStatusCSSClass;
        }

        public string GetCertificateURL(int pVPNumber, string applicationStatusDescription)
        {
            string convertedPVPNumber = pVPNumber.ToString();
            string certificateUrl = String.Empty;

            if (applicationStatusDescription == "Certificate Expired" || applicationStatusDescription == "Certificate Issued")
            {
                if (convertedPVPNumber.Length < 9)
                {
                    certificateUrl = String.Format("https://apps.ams.usda.gov/CMS/AdobeImages/00{0}.pdf", convertedPVPNumber);
                }
            }
            return certificateUrl;
        }
    }
}