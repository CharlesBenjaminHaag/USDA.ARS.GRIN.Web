using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Collections.ObjectModel;
using USDA.ARS.GRIN.Web.DataLayer;
using USDA.ARS.GRIN.Web.AppLayer;

namespace USDA.ARS.GRIN.Web.ViewModelLayer
{
    public class SiteViewModelBase : AppViewModelBase 
    {
        private Site _Entity = new Site();
        private SiteSearch _SearchEntity = new SiteSearch();
        private Collection<Site> _DataCollection = new Collection<Site>();
        public Site Entity
        {
            get { return _Entity; }
            set { _Entity = value; }
        }

        public SiteSearch SearchEntity
        {
            get { return _SearchEntity; }
            set { _SearchEntity = value; }
        }

        public Collection<Site> DataCollection
        {
            get { return _DataCollection; }
            set { _DataCollection = value; }
        }
    }
}
