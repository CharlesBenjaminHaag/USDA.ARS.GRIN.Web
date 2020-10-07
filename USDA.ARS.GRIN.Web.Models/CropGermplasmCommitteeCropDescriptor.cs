using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDA.ARS.GRIN.Web.Models
{
    public class CropGermplasmCommitteeCropDescriptor
    {
        public int ID { get; set; }
        public int CropID { get; set; }

        public string CropName { get; set; }
    }
}
