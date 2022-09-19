using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USDA.ARS.GRIN.Web.AppLayer;

namespace USDA.ARS.GRIN.Web.DataLayer
{
    public class SysGroupUserMap: AppEntityBase
    {
        public int SysGroupID { get; set; }
        public int SysUserID { get; set; }
        public string GroupTag { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
