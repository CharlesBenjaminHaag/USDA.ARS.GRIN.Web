using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USDA.ARS.GRIN.Web.AppLayer;

namespace USDA.ARS.GRIN.Web.DataLayer
{
    public class CodeValue: AppEntityBase
    {
        public int CodeValueID { get; set; }
        public int CodeValueLangID { get; set; }
        public string GroupName { get; set; }
        public string Code { get; set; }
        public string CodeTitle { get; set; }
        public string CodeDescription { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
