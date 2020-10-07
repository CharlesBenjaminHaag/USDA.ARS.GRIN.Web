using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using USDA.ARS.GRIN.Web.Models;

namespace USDA.ARS.GRIN.Web.WebUI.ViewModels
{
    public class PVPDetailListViewModel
    {
        public string DisplayFormat { get; set; }
        public List<ReferenceItem> ReferenceItems { get; set; }
        public PVPDetailListViewModel()
        {
            this.ReferenceItems = new List<ReferenceItem>();
        }

    }
}