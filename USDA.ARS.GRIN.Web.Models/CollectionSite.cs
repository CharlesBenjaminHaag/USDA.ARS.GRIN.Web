using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDA.ARS.GRIN.Web.Models
{
    public class CollectionSite 
    {
        public int CollectionSiteID { get; set; }
        public string CollectionSiteName { get; set; }

        public List<CollectionCrop> CollectionSiteCrops { get; set; }

        public CollectionSite()
        {
            this.CollectionSiteCrops = new List<CollectionCrop>();
        }
    }
}
