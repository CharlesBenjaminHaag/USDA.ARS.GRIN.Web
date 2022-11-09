using System;
using System.Web;
using System.Web.Mvc;
using System.Collections.ObjectModel;
using USDA.ARS.GRIN.Web.AppLayer;
using USDA.ARS.GRIN.Web.DataLayer;

namespace USDA.ARS.GRIN.Web.ViewModelLayer
{
    public class CropGermplasmCommitteeViewModelBase : AppViewModelBase
    {
        private CropGermplasmCommittee _Entity = new CropGermplasmCommittee();
        private CropGermplasmCommitteeSearch _SearchEntity = new CropGermplasmCommitteeSearch();
        private Collection<CropGermplasmCommittee> _DataCollection = new Collection<CropGermplasmCommittee>();
        private Collection<CropGermplasmCommitteeDocument> _DataCollectionDocuments = new Collection<CropGermplasmCommitteeDocument>();
        public CropGermplasmCommittee Entity
        {
            get { return _Entity; }
            set { _Entity = value; }
        }

        public CropGermplasmCommitteeSearch SearchEntity
        {
            get { return _SearchEntity; }
            set { _SearchEntity = value; }
        }

        public Collection<CropGermplasmCommittee> DataCollection
        {
            get { return _DataCollection; }
            set { _DataCollection = value; }
        }
        public Collection<CropGermplasmCommitteeDocument> DataCollectionDocuments
        {
            get { return _DataCollectionDocuments; }
            set { _DataCollectionDocuments = value; }
        }
    }
}
