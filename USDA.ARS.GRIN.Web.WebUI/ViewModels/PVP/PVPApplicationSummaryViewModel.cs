using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using USDA.ARS.GRIN.Web.Models;

namespace USDA.ARS.GRIN.Web.WebUI.ViewModels
{
    public class PVPApplicationSummaryViewModel : PVPBaseViewModel
    {
        public int ApplicationNumber { get; set; }
        public string CultivarName { get; set; }
        public string ExperimentalName { get; set; }
        public string ScientificName { get; set; }
        public string CommonName { get; set; }
        public string ApplicantName { get; set; }
        public DateTime ApplicationDate { get; set; }
        public bool IsCertifiedSeed { get; set; }
        public string ApplicationStatus { get; set; }
        public DateTime ApplicationStatusDate { get; set; }
        public DateTime CertificateIssuedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int YearsProtected { get; set; }
        public int AccessionID { get; set; }
        public string CertificateURL
        {
            get
            {
                return String.Format("https://apps.ams.usda.gov/CMS/AdobeImages/00{0}.pdf", ApplicationNumber);
            }
        }
        public string GRINGlobalAccessionURL {get; set; }
       
        public List<PVPApplication> RelatedApplications { get; set; }

        public PVPApplicationSummaryViewModel()
        {
            this.RelatedApplications = new List<PVPApplication>();
        }
    }
}