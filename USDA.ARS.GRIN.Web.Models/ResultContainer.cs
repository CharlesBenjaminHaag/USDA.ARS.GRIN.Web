using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDA.ARS.GRIN.Web.Models
{
    public class ResultContainer
    {
        public int EntityID { get; set; }
        public string ResultCode { get; set; }
        public string ResultDescription { get; set; }
    }
}
