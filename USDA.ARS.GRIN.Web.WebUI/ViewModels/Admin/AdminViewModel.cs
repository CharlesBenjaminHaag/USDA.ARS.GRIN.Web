using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using USDA.ARS.GRIN.Web.Models;

namespace USDA.ARS.GRIN.Web.WebUI.ViewModels.Admin
{
    public class AdminViewModel
    {
        public List<CropGermplasmCommitteeDocument> CGCDocuments { get; set; }
    }
}