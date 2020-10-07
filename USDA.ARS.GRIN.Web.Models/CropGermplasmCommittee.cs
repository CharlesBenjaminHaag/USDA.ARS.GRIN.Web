using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDA.ARS.GRIN.Web.Models
{
    public class CropGermplasmCommittee
    {
        public int ID { get; set; } 
        public string Name { get; set; }
        public string RosterURL { get; set; }

        public List<CropGermplasmCommitteeDocument> Documents { get; set; }

        public List<CropGermplasmCommitteeCropDescriptor> CropDescriptors { get; set; }

        public CropGermplasmCommittee()
        {
            this.Documents = new List<CropGermplasmCommitteeDocument>();
            this.CropDescriptors = new List<CropGermplasmCommitteeCropDescriptor>();
        }
    }
}
