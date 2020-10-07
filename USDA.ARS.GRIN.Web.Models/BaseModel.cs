using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDA.ARS.GRIN.Web.Models
{
    public abstract class BaseModel
    {
        public DateTime CreatedDate { get; set; }
        public int CreatedByCooperatorID { get; set; }
        public string CreatedByCooperatorName { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedByCooperatorID { get; set; }
        public string ModifiedByCooperatorName { get; set; }
        public int OwnedByCooperatorID { get; set; }
        public string OwnedByCooperatorName { get; set; }
        public DateTime OwnedDate { get; set; }
    }
}
