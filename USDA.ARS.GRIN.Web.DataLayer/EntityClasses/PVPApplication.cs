using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using USDA.ARS.GRIN.Web.AppLayer;

namespace USDA.ARS.GRIN.Web.DataLayer
{
    public class PVPApplication: AppEntityBase
    {
        public int ApplicationNumber { get; set; }
        public string CultivarName { get; set; }
        public string ExperimentalName { get; set; }
        public string ScientificName { get; set; }
        public string CommonName { get; set; }
        public string ApplicantName { get; set; }
        public DateTime ApplicationDate { get; set; }
        public bool IsCertifiedSeed { get; set; }
        public bool IsAvailableInGRIN { get; set; }
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
                string convertedPVPNumber = ApplicationNumber.ToString();
                string certificateUrl = String.Empty;

                if (ApplicationStatus == "Certificate Expired" || ApplicationStatus == "Certificate Issued")
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
}
