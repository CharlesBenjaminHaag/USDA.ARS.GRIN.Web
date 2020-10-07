using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using USDA.ARS.GRIN.Web.Models;


namespace USDA.ARS.GRIN.Web.WebUI.ViewModels
{
    public class PVPApplicationDetailViewModel
    {
        public int CropID { get; set; }
        public int StatusID { get; set; }
        public List<PVPApplication> Applications { get; set; }
    }
}