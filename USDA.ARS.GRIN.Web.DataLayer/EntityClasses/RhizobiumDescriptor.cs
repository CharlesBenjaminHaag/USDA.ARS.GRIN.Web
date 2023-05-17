using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using USDA.ARS.GRIN.Web.AppLayer;

namespace USDA.ARS.GRIN.Web.DataLayer
{
    public class RhizobiumDescriptor : AppEntityBase
    {
        public int ID { get; set; }
        public string USDAAccessionCode { get; set; }
        public string HostPlantName { get; set; }
        public string CommonName { get; set; }
        public string Source { get; set; }
        public string GeoSource { get; set; }
        public string GenusSPP { get; set; }
       
    }
}
