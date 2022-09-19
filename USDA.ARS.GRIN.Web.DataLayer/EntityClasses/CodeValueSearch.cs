using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USDA.ARS.GRIN.Web.AppLayer;

namespace USDA.ARS.GRIN.Web.DataLayer
{
    public class CodeValueSearch : SearchEntityBase
    {
        public string GroupName { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
