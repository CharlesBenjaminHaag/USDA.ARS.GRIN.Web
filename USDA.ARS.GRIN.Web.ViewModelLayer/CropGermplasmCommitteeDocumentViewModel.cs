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
            using (CropGermplasmCommitteeDocumentManager mgr = new CropGermplasmCommitteeDocumentManager())
            {
                try
                {
                    // TODO delete file if desired
                    RowsAffected = mgr.Delete(Entity);
                }
                catch (Exception ex)
                {
                    PublishException(ex);
                    throw ex;
                }
            }
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
            using (CropGermplasmCommitteeDocumentManager mgr = new CropGermplasmCommitteeDocumentManager())
            {
                try
                {
                    RowsAffected = mgr.Insert(Entity);
                }
                catch (Exception ex)
                {
                    PublishException(ex);
                    throw ex;
                }
                return RowsAffected;
            }
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

        public override bool Validate()
        {
            bool validated = true;

            if (Entity.CropGermplasmCommitteeID == 0)
            {
                ValidationMessages.Add(new Common.Library.ValidationMessage { Message = "Please select a committee." });
            }

            if (String.IsNullOrEmpty(Entity.Title))
            {
                ValidationMessages.Add(new Common.Library.ValidationMessage { Message = "Please specify the document title." });
            }

            if (ValidationMessages.Count > 0)
            {
                validated = false;
            }
            return validated;
        }
    }
}
