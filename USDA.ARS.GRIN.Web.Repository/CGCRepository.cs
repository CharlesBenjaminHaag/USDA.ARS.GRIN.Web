﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USDA.ARS.GRIN.Web.Models;

namespace USDA.ARS.GRIN.Web.Repository
{
    public class CGCRepository : BaseRepository
    {
        public List<CropGermplasmCommittee> List()
        {
            CropGermplasmCommittee cropGermplasmCommittee = new CropGermplasmCommittee();
            List<CropGermplasmCommittee> cropGermplasmCommitteeList = new List<CropGermplasmCommittee>();
            var results = _dataContext.usp_ARS_CropGermplasmCommittees_Select();
            if (results != null)
            {
                foreach (var result in results)
                {
                    cropGermplasmCommittee = new CropGermplasmCommittee();
                    cropGermplasmCommittee.ID = result.crop_germplasm_committee_id;
                    cropGermplasmCommittee.Name = result.crop_germplasm_committee_name;
                    cropGermplasmCommittee.RosterURL = result.roster_url;
                    cropGermplasmCommittee.Documents = GetDocuments(cropGermplasmCommittee.ID);
                    cropGermplasmCommittee.CropDescriptors = GetCropDescriptors(cropGermplasmCommittee.ID);
                    cropGermplasmCommitteeList.Add(cropGermplasmCommittee);
                }
            }
            return cropGermplasmCommitteeList;
        }

        public CropGermplasmCommittee Detail(int id)
        {
            CropGermplasmCommittee cropGermplasmCommittee = new CropGermplasmCommittee();

            try
            {
                var result = _dataContext.usp_ARS_CropGermplasmCommittee_Select(id).FirstOrDefault();
                if (result != null)
                {
                    cropGermplasmCommittee = new CropGermplasmCommittee();
                    cropGermplasmCommittee.ID = result.crop_germplasm_committee_id;
                    cropGermplasmCommittee.Name = result.crop_germplasm_committee_name;
                    cropGermplasmCommittee.RosterURL = result.roster_url;
                    cropGermplasmCommittee.Documents = GetDocuments(cropGermplasmCommittee.ID);
                    cropGermplasmCommittee.CropDescriptors = GetCropDescriptors(cropGermplasmCommittee.ID);
                }
            }
            catch (Exception ex)
            {
            }
            return cropGermplasmCommittee;
        }

        public CropGermplasmCommitteeDocument GetDocument(int id)
        {
            CropGermplasmCommitteeDocument cropGermplasmCommitteeDocument = null;

            try
            {
                var result = _dataContext.usp_ARS_CropGermplasmCommitteeDocument_Select(id).FirstOrDefault();
                if (result != null)
                {
                    cropGermplasmCommitteeDocument = new CropGermplasmCommitteeDocument { ID = result.crop_germplasm_committee_document_id, Title = result.title, Category = result.category_code, URL = result.url };
                    cropGermplasmCommitteeDocument.Committee.ID = result.crop_germplasm_committee_id.GetValueOrDefault();
                    cropGermplasmCommitteeDocument.Committee.Name = result.crop_germplasm_committee_name;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return cropGermplasmCommitteeDocument;
        }

        public List<CropGermplasmCommitteeDocument> GetDocuments()
        {
            CropGermplasmCommitteeDocument document = null;
            List<CropGermplasmCommitteeDocument> documents = new List<CropGermplasmCommitteeDocument>();
            var results = _dataContext.usp_ARS_CropGermplasmCommitteeDocuments_SelectAll();
            foreach (var result in results)
            {
                document = new CropGermplasmCommitteeDocument();
                document.ID = result.crop_germplasm_committee_document_id;
                document.Title = result.title;
                document.URL = result.url;
                document.CreatedDate = result.created_date.GetValueOrDefault();
                document.Committee.Name = result.crop_germplasm_committee_name;documents.Add(document);
            }
            return documents;
        }

        public List<CropGermplasmCommitteeDocument> GetDocuments(int cropGermplasmCommitteeId)
        {
            List<CropGermplasmCommitteeDocument> cropGermplasmCommitteeDocuments = new List<CropGermplasmCommitteeDocument>();
            CropGermplasmCommitteeDocument document = null;
            
            var results = _dataContext.usp_ARS_CropGermplasmCommitteeDocuments_Select(cropGermplasmCommitteeId);
            foreach (var result in results)
            {
                document = new CropGermplasmCommitteeDocument();
                document.ID = result.crop_germplasm_committee_document_id;
                document.Title = result.title;
                document.URL = result.url;
                cropGermplasmCommitteeDocuments.Add(document);
            }

            return cropGermplasmCommitteeDocuments;
        }

        public ResultContainer InsertDocument(CropGermplasmCommitteeDocument document)
        {
            int? errorNumber = 0;
            int? id = 0;

            ResultContainer resultContainer = new ResultContainer();

            try
            {
                _dataContext.usp_ARS_CropGermplasmCommitteeDocument_Insert(ref errorNumber, ref id, document.Committee.ID, document.Title, document.Year, document.Category, document.URL);
                resultContainer.EntityID = id.GetValueOrDefault();
                resultContainer.ResultCode = errorNumber.GetValueOrDefault().ToString();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return resultContainer;
        }

        public ResultContainer UpdateDocument(CropGermplasmCommitteeDocument document)
        {
            int? errorNumber = 0;
            ResultContainer resultContainer = new ResultContainer();

            try
            {
                _dataContext.usp_ARS_CropGermplasmCommitteeDocument_Update(ref errorNumber, document.ID, document.Committee.ID, document.Title, document.Year, document.Category, document.URL);
                resultContainer.EntityID = document.ID;
                resultContainer.ResultCode = errorNumber.GetValueOrDefault().ToString();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return resultContainer;
        }

        public List<CropGermplasmCommitteeCropDescriptor> GetCropDescriptors(int cropGermplasmCommitteeId)
        {
            List<CropGermplasmCommitteeCropDescriptor> cropGermplasmCommitteeCropDescriptors = new List<CropGermplasmCommitteeCropDescriptor>();
            var results = _dataContext.usp_ARS_CropGermplasmCommitteeCropDescriptors_Select(cropGermplasmCommitteeId);
            foreach (var result in results)
            {
               cropGermplasmCommitteeCropDescriptors.Add(new CropGermplasmCommitteeCropDescriptor { ID = result.crop_germplasm_committee_id, CropID = result.crop_id, CropName = result.name } );
            }

            return cropGermplasmCommitteeCropDescriptors;
        }

    }
}
