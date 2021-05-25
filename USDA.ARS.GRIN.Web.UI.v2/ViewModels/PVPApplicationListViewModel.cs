using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using USDA.ARS.GRIN.Web.Models;


namespace USDA.ARS.GRIN.Web.UI.v2.ViewModels
{
    public class PVPApplicationListViewModel
    {
        public List<PVPApplication> PVPApplications { get; set; }

        public string GetBooleanDisplayString(bool value)
        {
            if (value)
                return "<span class='label label-success'>Yes</span>";
            else
                return "<span class='label label-danger'>No</span>";
        }
    }
}