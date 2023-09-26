using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Runtime.Caching;
using System.Collections.ObjectModel;
using USDA.ARS.GRIN.Web.DataLayer;

namespace USDA.ARS.GRIN.Web.ViewModelLayer
{
    public class RhizobiumViewModel: RhizobiumViewModelBase
    {
        public void Search()
        {
            ObjectCache cache = MemoryCache.Default;
            List<RhizobiumDescriptor> rhizobiumDescriptors = new List<RhizobiumDescriptor>();

            try 
            {
                rhizobiumDescriptors = cache["DATA-LIST-RHIZOBIUM"] as List<RhizobiumDescriptor>;

                if (rhizobiumDescriptors == null)
                {
                    using (RhizobiumManager mgr = new RhizobiumManager())
                    {
                        rhizobiumDescriptors = mgr.Search(SearchEntity);
                        cache["DATA-LIST-RHIZOBIUM"] = rhizobiumDescriptors;
                        RowsAffected = mgr.RowsAffected;
                    }
                }
                DataCollection = new Collection<RhizobiumDescriptor>(rhizobiumDescriptors);
            }
            catch (Exception ex)
            {
                PublishException(ex);
                throw ex;
            }
        }
    }
}
