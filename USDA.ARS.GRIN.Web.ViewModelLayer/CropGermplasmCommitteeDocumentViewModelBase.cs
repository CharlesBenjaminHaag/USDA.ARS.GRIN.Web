using System;
using System.Web;
using System.Web.Mvc;
using System.Collections.ObjectModel;
using USDA.ARS.GRIN.Web.AppLayer;
using USDA.ARS.GRIN.Web.DataLayer;

namespace USDA.ARS.GRIN.Web.ViewModelLayer
{
    public class CropGermplasmCommitteeDocumentViewModelBase : AuthenticatedViewModelBase
    {
        private CropGermplasmCommitteeDocument _Entity = new CropGermplasmCommitteeDocument();
        private CropGermplasmCommitteeDocumentSearch _SearchEntity = new CropGermplasmCommitteeDocumentSearch();
        private Collection<CropGermplasmCommitteeDocument> _DataCollection = new Collection<CropGermplasmCommitteeDocument>();
        public CropGermplasmCommitteeDocumentViewModelBase()
        {
            using (CropGermplasmCommitteeDocumentManager mgr = new CropGermplasmCommitteeDocumentManager())
            {
                CategoryCodes = new SelectList(mgr.GetCodeValues("CGC_DOCUMENT_CATEGORY"), "Value", "Title");
                CropGermplasmCommittees = new SelectList(mgr.GetCropGermplasmCommittees(),"ID","Name");
            }
        }

        public CropGermplasmCommitteeDocument Entity
        {
            get { return _Entity; }
            set { _Entity = value; }
        }
      
        public CropGermplasmCommitteeDocumentSearch SearchEntity
        {
            get { return _SearchEntity; }
            set { _SearchEntity = value; }
        }

        public Collection<CropGermplasmCommitteeDocument> DataCollection
        {
            get { return _DataCollection; }
            set { _DataCollection = value; }
        }

        public SelectList CategoryCodes
        { get; set; }

        public SelectList CropGermplasmCommittees
        {
            get; set;
        }

        public string IsReadOnly
        {
            get
            {
                if ((AuthenticatedUser.IsInRole("GGTOOLS_COOPERATOR")) ||
                    (AuthenticatedUser.IsInRole("MANAGE_COOPERATOR")) ||
                    (AuthenticatedUser.IsInRole("GGTOOLS_ADMIN")) ||
                    (AuthenticatedUser.CooperatorID == Entity.ID)
                    )
                {
                    return "N";
                }
                else
                {
                    return "Y";
                }
            }
        }
    }
}
