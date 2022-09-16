using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using USDA.ARS.GRIN.Web.AppLayer;

namespace USDA.ARS.GRIN.Web.DataLayer 
{
    public class SiteSearch: SearchEntityBase
    {
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public string DisplayName { get; set; }
        public string ProviderIdentifier { get; set; }
        public string OrganizationAbbrev { get; set; }
        public string IsInternal { get; set; }
        public string IsDistributionSite { get; set; }
        public string TypeCode { get; set; }
        public string FAOInstituteNumber { get; set; }
    }
}
