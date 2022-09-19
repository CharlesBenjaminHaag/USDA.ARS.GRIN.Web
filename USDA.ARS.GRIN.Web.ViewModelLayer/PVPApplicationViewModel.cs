using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Collections.ObjectModel;
using USDA.ARS.GRIN.Web.DataLayer;

namespace USDA.ARS.GRIN.Web.ViewModelLayer
{
    public class PVPApplicationViewModel: PVPApplicationViewModelBase
    {
        public void Search()
        {
            using (PVPApplicationManager mgr = new PVPApplicationManager())
            {
                try
                {
                    DataCollection = new Collection<PVPApplication>(mgr.Search(SearchEntity));
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
    }
}
