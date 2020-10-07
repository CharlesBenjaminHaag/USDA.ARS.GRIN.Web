using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using USDA.ARS.GRIN.Web.Models;

namespace USDA.ARS.GRIN.Web.WebUI.ViewModels
{
    public class RhizobiumSearchViewModel
    {
        public string PageAction { get; set; }
        public string SearchString { get; set; }
        public List<RhizobiumDescriptor> SearchResults { get; set; }

        public RhizobiumSearchViewModel()
        {
            this.SearchResults = new List<RhizobiumDescriptor>();
        }
    }
}