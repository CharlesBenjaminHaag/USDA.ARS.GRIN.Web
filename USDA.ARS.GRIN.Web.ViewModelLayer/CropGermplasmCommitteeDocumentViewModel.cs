using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Mvc;
using System.IO;
using System.Web;
using USDA.ARS.GRIN.Common.Library.Email;
using USDA.ARS.GRIN.Web.DataLayer;

namespace USDA.ARS.GRIN.Web.ViewModelLayer
{
    public class CropGermplasmCommitteeDocumentViewModel : CropGermplasmCommitteeDocumentViewModelBase, IViewModel<CropGermplasmCommitteeDocument>
    {
        public HttpPostedFileBase DocumentUpload { get; set; }
        public void Delete()
        {
            throw new NotImplementedException();
        }

        public CropGermplasmCommitteeDocument Get(int entityId)
        {
            CropGermplasmCommitteeDocumentViewModel viewModel = new CropGermplasmCommitteeDocumentViewModel();

            try 
            {
                using (CropGermplasmCommitteeDocumentManager mgr = new CropGermplasmCommitteeDocumentManager())
                {
                    Entity = mgr.Get(entityId);
                }
            }
            catch (Exception ex)
            {
                PublishException(ex);
                throw ex;
            }
            return Entity;
        }

        public void HandleRequest()
        {
            throw new NotImplementedException();
        }

        public int Insert()
        {
            throw new NotImplementedException();
        }

        public void Search()
        {
            using (CropGermplasmCommitteeDocumentManager mgr = new CropGermplasmCommitteeDocumentManager())
            {
                try
                {
                    DataCollection = new Collection<CropGermplasmCommitteeDocument>(mgr.Search(SearchEntity));
                    RowsAffected = mgr.RowsAffected;

                    if (RowsAffected == 1)
                    {
                        Entity = DataCollection[0];
                    }
                }
                catch (Exception ex)
                {
                    PublishException(ex);
                    throw ex;
                }
            }
        }

        public int Update()
        {
            using (CropGermplasmCommitteeDocumentManager mgr = new CropGermplasmCommitteeDocumentManager())
            {
                try
                {
                    RowsAffected = mgr.Update(Entity);
                }
                catch (Exception ex)
                {
                    PublishException(ex);
                    throw ex;
                }
                return RowsAffected;
            }

        }
    }
}
