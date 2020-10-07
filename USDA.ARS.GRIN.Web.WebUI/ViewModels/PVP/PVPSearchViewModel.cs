using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using USDA.ARS.GRIN.Web.Models;

namespace USDA.ARS.GRIN.Web.WebUI.ViewModels
{
    public class PVPSearchViewModel : PVPBaseViewModel
    {
        private string _validationMessage;
        private IEnumerable<ReferenceItem> _applicationStatuses;
        private IEnumerable<ReferenceItem> _certificateStatuses;
        private Repository.PVPRepository _repository = new Repository.PVPRepository();

        public string ValidationMessage 
        {
            get
            {
                if (!String.IsNullOrEmpty(_validationMessage))
                {
                    return String.Format("<div id='validation-message', style='background-color:red; color: white; font-size:.8em; padding:7px; margin-bottom:5px;'>{0}</div>", this._validationMessage);
                }
                else
                {
                    return "";
                }
            }
            set
            {
                this._validationMessage = value;
            }
        }
        public int PVNumber { get; set; }
       
        public string CommonName { get; set; }

        public string Variety { get; set; }
        public string ApplicantName { get; set; }
      
        public List<PVPApplication> SearchResults;

        public List<ReferenceItem> ApplicationStatuses
        {
            set { _applicationStatuses = value; }
        }

        public string SelectedApplicationStatuses { get; set; }

        public string SelectedCertificateStatuses { get; set; }

        public PVPSearchViewModel()
        {
            this._applicationStatuses = _repository.GetApplicationStatusList();
            this._certificateStatuses = _repository.GetCertificateStatusList();
            this.SearchResults = new List<PVPApplication>();
        }

        public IEnumerable<SelectListItem> ApplicationStatusOptions
        {
            get { return new SelectList(_applicationStatuses, "ID", "Title"); }
        }

        public IEnumerable<SelectListItem> CertificateStatusOptions
        {
            get { return new SelectList(_certificateStatuses, "ID", "Title"); }
        }

        // TEMP (8/11/2020)
        public string SelectedSearchOptions { get; set; }
        public string SearchText { get; set; }
    }
}