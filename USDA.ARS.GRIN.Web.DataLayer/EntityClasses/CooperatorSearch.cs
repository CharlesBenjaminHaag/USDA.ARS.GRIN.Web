using System;
using System.Text;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USDA.ARS.GRIN.Web.AppLayer;

namespace USDA.ARS.GRIN.Web.DataLayer
{
    public class CooperatorSearch: SearchEntityBase
    {
        public string StatusCode { get; set; }
        public string CreatedTimeFrame { get; set; }
        public string ModifiedTimeFrame { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string Organization { get; set; }
        public string PrimaryPhoneNumber { get; set; }
        public string SecondaryPhoneNumber { get; set; }
        public int SiteID { get; set; }
        public string SysUserIsEnabled { get; set; }
    }
}
