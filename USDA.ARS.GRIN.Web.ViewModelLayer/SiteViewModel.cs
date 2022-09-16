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
    public class SiteViewModel:SiteViewModelBase
    {
        public Site Get(int entityId)
        {
            using (SiteManager mgr = new SiteManager())
            {
                try
                {
                    Entity = mgr.Get(entityId);
                    RowsAffected = mgr.RowsAffected;
                    return Entity;
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
