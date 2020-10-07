using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using USDA.ARS.GRIN.Web.Models;

namespace USDA.ARS.GRIN.Web.WebUI.ViewModels
{
    public class RhizobiumDetailViewModel
    {
        public string HostPlantName { get; set; }
        public List<RhizobiumDescriptor> RhizobiumDescriptors { get; set; }

        public RhizobiumDetailViewModel()
        {
            this.RhizobiumDescriptors = new List<RhizobiumDescriptor>();
        }
    }
}