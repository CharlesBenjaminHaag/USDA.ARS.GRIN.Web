using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USDA.ARS.GRIN.Web.Models;

namespace USDA.ARS.GRIN.Web.WebUI.ViewModels
{
    public class AccountRequestViewModel 
    {
        private List<CodeValueReferenceItem> _requestTypes;
        private List<CodeValueReferenceItem> _environments;
        public string Status { get; set; }
        public string Environment { get; set; }
        public string RequestType { get; set; }
        [Required(ErrorMessage = "Please enter the email of the requestor.")]
        public string RequestorEmail { get; set; }
        [Required(ErrorMessage = "Please enter the full name of the requestor.")]
        public string RequestorName { get; set; }
        [Required(ErrorMessage = "Please enter the email of the account owner.")]
        public string AccountHolderEmail { get; set; }
        [Required(ErrorMessage = "Please enter the full name of the account owner.")]

        public string AccountHolderName { get; set; }
        public string Notes { get; set; }
        public bool CCRequestor { get; set; }

        public IEnumerable<SelectListItem> RequestTypes
        {
            get { return new SelectList(_requestTypes, "Title", "Description"); }
        } 

        public IEnumerable<SelectListItem> Environments 
        {
            get { return new SelectList(_environments, "Title", "Description"); }
        }
        
        public AccountRequestViewModel()
        {
            this._requestTypes = new List<CodeValueReferenceItem>();
            this._requestTypes.Add(new CodeValueReferenceItem { Title = "NEW", Description = "Create a new account" });
            this._requestTypes.Add(new CodeValueReferenceItem { Title = "DEL", Description = "Remove an existing account" });

            this._environments = new List<CodeValueReferenceItem>();
            this._environments.Add(new CodeValueReferenceItem { Title = "Production", Description = "Production" });
            this._environments.Add(new CodeValueReferenceItem { Title = "Training", Description = "Training" });
            this._environments.Add(new CodeValueReferenceItem { Title = "Development", Description = "Development" });
        }

    }
}