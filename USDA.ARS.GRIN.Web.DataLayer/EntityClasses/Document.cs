using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using USDA.ARS.GRIN.Web.AppLayer;


namespace USDA.ARS.GRIN.Web.DataLayer
{
    public class Document: AppEntityBase
    {
        public int CropGermplasmCommitteeID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryTitle { get; set; }
        public int DocumentYear { get; set; }
        public string URL { get; set; }
    }
}
