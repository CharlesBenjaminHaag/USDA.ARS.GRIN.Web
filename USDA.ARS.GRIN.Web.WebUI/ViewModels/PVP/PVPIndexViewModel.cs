using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using USDA.ARS.GRIN.Web.Models;

namespace USDA.ARS.GRIN.Web.WebUI.ViewModels
{
    public class PVPIndexViewModel
    {
        public string SearchString { get; set; }

        public IEnumerable<PVPScientificName> Crops { get; set; }
        public IEnumerable<PVPApplication> SearchResults { get; set; }
    }
}