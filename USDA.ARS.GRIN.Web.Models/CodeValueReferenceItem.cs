using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDA.ARS.GRIN.Web.Models
{
    public class CodeValueReferenceItem
    {
            public string GroupName { get; set; }
            public int CodeValueID { get; set; }
            public string CodeValue { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
    }
}
