using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using USDA.ARS.GRIN.Web.Models;

namespace USDA.ARS.GRIN.Web.WebUI.ViewModels
{
    public class PVPHomeViewModel
    {
        public string ViewFormatName { get; set; }
        public int CropID { get; set; }
        public List<PVPScientificName> CropList { get; set; }
        public List<PVPApplicationStatus> ApplicationStatusList { get; set; }
        public List<ReferenceItem> ReferenceItems { get; set; }

        public List<PVPApplication> PVPApplications { get; set; }

        public PVPHomeViewModel()
        {
            this.CropList = new List<PVPScientificName>();
            this.PVPApplications = new List<PVPApplication>();
        }

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