using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDA.ARS.GRIN.GGTools.AppLayer
{
    public class SearchEntityBase
    {
        public int ID { get; set; }
        public string IDList { get; set; }
        public string TableName { get; set; }
        public int CreatedByCooperatorID { get; set; }
        public string DateRangeFilter { get; set; }
        public string Note { get; set; }
    }
}
