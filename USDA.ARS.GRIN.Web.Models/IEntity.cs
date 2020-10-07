using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDA.ARS.GRIN.Web.Models
{
    public interface IEntity
    {
         int ID { get; set; }
        DateTime CreatedDate { get; set; }

        int CreatedByCooperatorID { get; set; }

        DateTime ModifiedDate { get; set; }

        int ModifiedByCooperatorID { get; set; }

        DateTime OwnedDate { get; set; }

        int OwnedByCooperatorID { get; set; }
    }
}
