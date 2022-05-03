using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDA.ARS.GRIN.Web.DataLayer
{
    public class CropGermplasmCommitteeDocument: BaseModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryTitle { get; set; }
        public int DocumentYear { get; set; }
        public CropGermplasmCommittee Committee { get; set; }
        public string URL { get; set; }
        public CropGermplasmCommitteeDocument()
        {
            Committee = new CropGermplasmCommittee();
        }
    }
}
