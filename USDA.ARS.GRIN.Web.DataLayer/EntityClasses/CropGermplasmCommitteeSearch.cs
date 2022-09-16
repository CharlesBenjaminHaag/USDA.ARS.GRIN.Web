using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USDA.ARS.GRIN.Web.AppLayer;

namespace USDA.ARS.GRIN.Web.DataLayer
{
    public class CropGermplasmCommitteeSearch: SearchEntityBase
    {
        public string Name { get; set; }
        public string RosterURL { get; set; }
    }
}
