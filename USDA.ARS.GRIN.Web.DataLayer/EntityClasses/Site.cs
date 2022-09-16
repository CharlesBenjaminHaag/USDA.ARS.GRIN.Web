using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using USDA.ARS.GRIN.Web.AppLayer;

namespace USDA.ARS.GRIN.Web.DataLayer
{
    public class Site : AppEntityBase
    {
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public string AssembledName { get; set; }
        public string ProviderIdentifier { get; set; }
        public string OrganizationAbbrev { get; set; }
        public string IsInternal { get; set; }
        public bool IsInternalOption { get; set; }
        public string IsDistributionSite { get; set; }
        public bool IsDistributionSiteOption { get; set; }
        public string TypeCode { get; set; }
        public string FAOInstituteNumber { get; set; }
        public int CooperatorID { get; set; }
        public string PrimaryAddress1 { get; set; }
        public string PrimaryAddress2 { get; set; }
        public string PrimaryAddress3 { get; set; }
        public string PrimaryCity { get; set; }
        public string PrimaryPhone { get; set; }
        public string SecondaryAddress1 { get; set; }
        public string SecondaryAddress2 { get; set; }
        public string SecondaryAddress3 { get; set; }
        public string SecondaryCity { get; set; }
        public string SecondaryPhone { get; set; }
        public string EmailAddress { get; set; }
    }
}
