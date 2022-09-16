using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USDA.ARS.GRIN.Web.AppLayer;

namespace USDA.ARS.GRIN.Web.DataLayer 
{
    public class CropGermplasmCommitteeDocument: AppEntityBase
    {
        public int CropGermplasmCommitteeID { get; set; }
        public string CommitteeName { get; set; }
        public string URL { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryDescription { get; set; }
    }
}
