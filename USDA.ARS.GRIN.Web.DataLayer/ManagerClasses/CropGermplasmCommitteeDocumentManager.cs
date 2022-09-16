using System;
using System.Collections.Generic;
using System.Reflection;
using System.Data;
using USDA.ARS.GRIN.Common.DataLayer;
using USDA.ARS.GRIN.Web.AppLayer;
using USDA.ARS.GRIN.Web.DataLayer;

namespace USDA.ARS.GRIN.Web.DataLayer
{
    public class CropGermplasmCommitteeDocumentManager : AppDataManagerBase
    {
        public virtual int Insert(CropGermplasmCommitteeDocument entity)
        {
            Reset(CommandType.StoredProcedure);
            Validate<CropGermplasmCommitteeDocument>(entity);

            SQL = "usp_GGTools_GRINGlobal_CropGermplasmCommitteeDocument_Insert";

            BuildInsertUpdateParameters(entity);
            
            AddParameter("@out_error_number", -1, true, System.Data.DbType.Int32, System.Data.ParameterDirection.Output);
            AddParameter("@out_crop_germplasm_committee_document_id", -1, true, System.Data.DbType.Int32, System.Data.ParameterDirection.Output);
            
            RowsAffected = ExecuteNonQuery();

            entity.ID = GetParameterValue<int>("@out_crop_germplasm_committee_document_id", -1);
            int errorNumber = GetParameterValue<int>("@out_error_number", -1);
            
            return RowsAffected;
        }

        public virtual int Update(CropGermplasmCommitteeDocument entity)
        {
            Reset(CommandType.StoredProcedure);
            Validate<CropGermplasmCommitteeDocument>(entity);

            SQL = "usp_GGTools_GRINGlobal_CropGermplasmCommitteeDocument_Update";

            BuildInsertUpdateParameters(entity);
            
            AddParameter("@out_error_number", -1, true, System.Data.DbType.Int32, System.Data.ParameterDirection.Output);
     
            RowsAffected = ExecuteNonQuery();

            int errorNumber = GetParameterValue<int>("@out_error_number", -1);

            return RowsAffected;
        }

        public int Delete(CropGermplasmCommitteeDocument entity) 
        { 
            return 0; 
        }

        public CropGermplasmCommitteeDocument Get(int entityId)
        {
            SQL = "usp_GGTools_GRINGlobal_CropGermplasmCommitteeDocument_Select";
            CropGermplasmCommitteeDocument cropGermplasmCommitteeDocument = new CropGermplasmCommitteeDocument();

            var parameters = new List<IDbDataParameter> {
                CreateParameter("crop_germplasm_committee_document_id", (object)entityId, false)
            };

            cropGermplasmCommitteeDocument = GetRecord<CropGermplasmCommitteeDocument>(SQL, CommandType.StoredProcedure, parameters.ToArray());
            return cropGermplasmCommitteeDocument;
        }

        public List<CropGermplasmCommittee> GetCropGermplasmCommittees()
        {
            SQL = "SELECT * FROM vw_GGTools_GRINGlobal_CropGermplasmCommittee";
            List<CropGermplasmCommittee> cropGermplasmCommittees = GetRecords<CropGermplasmCommittee>(SQL);
            RowsAffected = cropGermplasmCommittees.Count;
            return cropGermplasmCommittees;
        }

        public virtual List<CropGermplasmCommitteeDocument> Search(CropGermplasmCommitteeDocumentSearch search)
        {
            // Create SQL to search for rows
            SQL = "SELECT * FROM vw_GGTools_GRINGlobal_CropGermplasmCommitteeDocument";
            SQL += " WHERE (@CreatedByCooperatorID  IS NULL OR CreatedByCooperatorID    =       @CreatedByCooperatorID) ";
            SQL += " AND   (@Title                  IS NULL OR Title                    LIKE    '%' + @Title + '%') ";
            SQL += " AND   (@CategoryCode           IS NULL OR CategoryCode             =       @CategoryCode) ";
            SQL += " AND   (@Year                   IS NULL OR DocumentYear             =       @Year) ";
            SQL += " AND   (@ID                     IS NULL OR ID                       =       @ID)";

            var parameters = new List<IDbDataParameter> {
                CreateParameter("CreatedByCooperatorID", search.CreatedByCooperatorID > 0 ? (object)search.CreatedByCooperatorID : DBNull.Value, true),
                CreateParameter("Title", (object)search.Title ?? DBNull.Value, true),
                CreateParameter("CategoryCode", (object)search.CategoryCode ?? DBNull.Value, true),
                CreateParameter("Year", search.Year > 0 ? (object)search.Year : DBNull.Value, true),
                CreateParameter("ID", search.ID > 0 ? (object)search.ID : DBNull.Value, true),
            };
            List<CropGermplasmCommitteeDocument> cropForCWRs = GetRecords<CropGermplasmCommitteeDocument>(SQL, parameters.ToArray());
            RowsAffected = cropForCWRs.Count;
            return cropForCWRs;
        }
        
        protected virtual void BuildInsertUpdateParameters(CropGermplasmCommitteeDocument entity)
        {
            if (entity.ID > 0)
            {
                AddParameter("@crop_germplasm_committee_document_id", entity.ID == 0 ? DBNull.Value : (object)entity.ID, true);
            }
            AddParameter("@crop_germplasm_committee_id", entity.CropGermplasmCommitteeID == 0 ? DBNull.Value : (object)entity.ID, true);
            AddParameter("@url", (object)entity.URL ?? DBNull.Value, true);
            AddParameter("@title", (object)entity.Title ?? DBNull.Value, true);
            AddParameter("@category_code", (object)entity.CategoryCode ?? DBNull.Value, true);
            AddParameter("@year", entity.Year == 0 ? DBNull.Value : (object)entity.ID, true);

            if (entity.ID > 0)
            {
                AddParameter("modified_by", entity.ModifiedByCooperatorID == 0 ? DBNull.Value : (object)entity.ModifiedByCooperatorID, true);
            }
            else
            {
                AddParameter("created_by", entity.CreatedByCooperatorID == 0 ? DBNull.Value : (object)entity.CreatedByCooperatorID, true);
            }
        }
    
        public void BuildInsertUpdateParameters()
        {
            throw new NotImplementedException();
        }
    }
}
