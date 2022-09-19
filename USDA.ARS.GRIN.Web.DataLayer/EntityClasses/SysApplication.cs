using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USDA.ARS.GRIN.Web.AppLayer;

namespace USDA.ARS.GRIN.Web.DataLayer
{
    public class SysApplication: AppEntityBase
    {
        public string ApplicationCode { get; set; }
        public string ApplicationTitle { get; set; }
        public string ApplicationDescription { get; set; }
        public string ApplicationURL { get; set; }
    }
}
