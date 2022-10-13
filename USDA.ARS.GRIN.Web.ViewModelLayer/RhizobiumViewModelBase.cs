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
    public class RhizobiumViewModelBase : AppViewModelBase
    {
        private RhizobiumDescriptor _Entity = new RhizobiumDescriptor();
        private RhizobiumDescriptorSearch _SearchEntity = new RhizobiumDescriptorSearch();
        private Collection<RhizobiumDescriptor> _DataCollection = new Collection<RhizobiumDescriptor>();
        public RhizobiumDescriptor Entity
        {
            get { return _Entity; }
            set { _Entity = value; }
        }

        public RhizobiumDescriptorSearch SearchEntity
        {
            get { return _SearchEntity; }
            set { _SearchEntity = value; }
        }

        public Collection<RhizobiumDescriptor> DataCollection
        {
            get { return _DataCollection; }
            set { _DataCollection = value; }
        }
    }
}
