using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web.Mvc;
using USDA.ARS.GRIN.Web.Models;
using USDA.ARS.GRIN.Web.Repository;

namespace USDA.ARS.GRIN.Web.WebUI.ViewModels.CGC
{
    public class DocumentEditViewModel 
    {
        private List<CropGermplasmCommittee> _committees = null;
        private GRINRepository _repository = new GRINRepository();
        public int ID { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public int CommitteeID { get; set; }
        public string CommitteeName { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase DocumentUpload { get; set; }

        public SelectList Committees
        {
            get
            {
                return new SelectList(_committees, "ID", "Name");
            }
        }

        public DocumentEditViewModel()
        {
            _committees = _repository.GetCropGermplasmCommitteeList();
        }
    }
}