using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDA.ARS.GRIN.Web.DataLayer
{
    public class SysApplicationSearch
    {
        public int ID { get; set; }
        public string ApplicationCode { get; set; }
        public string ApplicationTitle { get; set; }
        public int SysUserID { get; set; }
    }
}
