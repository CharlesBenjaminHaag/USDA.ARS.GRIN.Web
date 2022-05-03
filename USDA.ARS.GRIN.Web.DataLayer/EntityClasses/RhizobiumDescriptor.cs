using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDA.ARS.GRIN.Web.DataLayer
{
    public class RhizobiumDescriptor
    {
        public int RhyID { get; set; }
        public string Identifier { get; set; }
        public int USDAAccession { get; set; }
        public string Synonym1 { get; set; }
        public string Synonym2 { get; set; }
        public string Synonym3 { get; set; }
        public string Synonym4 { get; set; }
        public string HostPlant { get; set; }
        public string CommonName { get; set; }
        public string Source { get; set; }
        public string GeoSource { get; set; }
        public string SeroGroup { get; set; }
        public string HostsNodu { get; set; }
        public string Comments { get; set; }
        public string GenusSPP { get; set; }
    }
}
