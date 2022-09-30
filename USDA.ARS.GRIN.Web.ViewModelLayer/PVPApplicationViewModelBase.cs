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
    public class PVPApplicationViewModelBase : AppViewModelBase
    {
        private PVPApplication _Entity = new PVPApplication();
        private PVPApplicationSearch _SearchEntity = new PVPApplicationSearch();
        private Collection<PVPApplication> _DataCollection = new Collection<PVPApplication>();
        private Collection<CodeValue> _DataCollectionTotals = new Collection<CodeValue>();

        public PVPApplicationViewModelBase()
        {
            
        }

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
        public Collection<CodeValue> DataCollectionTotals
        {
            get { return _DataCollectionTotals; }
            set { _DataCollectionTotals = value; }
        }
        public SelectList StatusDateRanges 
        {
            get
            {
                List<CodeValue> codeValues = new List<CodeValue>();
                codeValues.Add(new CodeValue { Value = "10Y", CodeTitle = "The last 10 years" });
                codeValues.Add(new CodeValue { Value = "05Y", CodeTitle = "The last 5 years" });
                codeValues.Add(new CodeValue { Value = "01Y", CodeTitle = "This Year" });
                return new SelectList(codeValues.OrderBy(x=>x.Value), "Value", "CodeTitle");
            }
        }

        public SelectList CertificateStatuses
        {
            get
            {
                List<CodeValue> codeValues = new List<CodeValue>();

                using (PVPApplicationManager mgr = new PVPApplicationManager())
                {
                    codeValues = mgr.GetCodeValues("PVP_APPLICATION_STATUS");
                }
                return new SelectList(codeValues, "Title", "Title");
            }
        }
    }
}
