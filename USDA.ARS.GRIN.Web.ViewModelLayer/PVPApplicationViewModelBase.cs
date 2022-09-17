using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Collections.ObjectModel;
using USDA.ARS.GRIN.Web.AppLayer;
using USDA.ARS.GRIN.Web.DataLayer;

namespace USDA.ARS.GRIN.Web.ViewModelLayer
{
    public class PVPApplicationViewModelBase: AppViewModelBase
    {
        private PVPApplication _Entity = new PVPApplication();
        private PVPApplicationSearch _SearchEntity = new PVPApplicationSearch();
        private Collection<PVPApplication> _DataCollection = new Collection<PVPApplication>();

        public PVPApplication Entity
        {
            get { return _Entity; }
            set { _Entity = value; }
        }

        public PVPApplicationSearch SearchEntity
        {
            get { return _SearchEntity; }
            set { _SearchEntity = value; }
        }

        public Collection<PVPApplication> DataCollection
        {
            get { return _DataCollection; }
            set { _DataCollection = value; }
        }
    }
}
