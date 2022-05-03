using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using USDA.ARS.GRIN.Web.AppLayer;

namespace USDA.ARS.GRIN.Web.DataLayer
{
    public class CropGermplasmCommittee : AppEntityBase
    {
        public string Name { get; set; }
        public string RosterURL { get; set; }
    }
}
