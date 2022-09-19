using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using USDA.ARS.GRIN.Web.AppLayer;

namespace USDA.ARS.GRIN.Web.DataLayer
{
    public class PVPApplicationSearch: SearchEntityBase
    {
        public int ApplicationNumber { get; set; }
        public string Variety { get; set; }
        public string ExperimentalName { get; set; }
        public string ScientificName { get; set; }
        public string CommonName { get; set; }
        public string Applicant { get; set; }
        public DateTime ApplicationDate { get; set; }
        public bool IsCertifiedSeed { get; set; }
        public string CertificateStatus { get; set; }
        public DateTime StatusDate { get; set; }
        public DateTime IssuedDate { get; set; }
        public int YearsProtected { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsAvailableInGRIN { get; set; }
        public string TimeFrame { get; set; }
    }
}
