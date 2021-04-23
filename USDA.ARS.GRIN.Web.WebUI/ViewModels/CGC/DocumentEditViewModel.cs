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
        private List<CodeValueReferenceItem> _categories = null;

        private GRINRepository _repository = new GRINRepository();
        public string Action { get; set; }
        public int ID { get; set; }
        public string Title { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryTitle { get; set; }
        public int Year { get; set; }
        public string URL { get; set; }
        public int CommitteeID { get; set; }
        public string CommitteeName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [DataType(DataType.Upload)]
        public HttpPostedFileBase DocumentUpload { get; set; }

        public SelectList Committees
        {
            get
            {
                return new SelectList(_committees, "ID", "Name");
            }
        }
        public SelectList Categories
        {
            get
            {
                return new SelectList(_categories, "CodeValue", "Title");
            }
        }

        public IList<SelectListItem> GetYear()
        {
            const int numberOfYears = 21;
            //var startYear = DateTime.Now.Year;
            var startYear = 2009;
            var endYear = startYear + numberOfYears;

            var yearList = new List<SelectListItem>();
            for (var i = startYear; i < endYear; i++)
            {
                yearList.Add(new SelectListItem() { Value = i.ToString(), Text = i.ToString() });
            }
            return yearList;
        }

        public DocumentEditViewModel()
        {
            _categories = _repository.GetCropGermplasmCommitteeDocumentCategoryList();
            _committees = _repository.GetCropGermplasmCommitteeList();
        }
    }
}