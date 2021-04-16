using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDA.ARS.GRIN.Web.Models
{
    public class CropGermplasmCommitteeDocument: BaseModel
    {
        public int ID { get; set; }

        public string Title { get; set; }
        public string URL { get; set; }
        public string Category { get; set; }
        public int Year { get; set; }
        public DateTime CreatedDate { get; set; }
        public CropGermplasmCommittee Committee { get; set; }

        public CropGermplasmCommitteeDocument()
        {
            Committee = new CropGermplasmCommittee();
        }
    }
}
