using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDA.ARS.GRIN.Web.Models
{
    public class CollectionCrop
    {
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string SiteID { get; set; }
        public string SiteName { get; set; }
        public int CropDescriptorID { get; set; }
        public string CropDescriptor { get; set; }
    }
}
