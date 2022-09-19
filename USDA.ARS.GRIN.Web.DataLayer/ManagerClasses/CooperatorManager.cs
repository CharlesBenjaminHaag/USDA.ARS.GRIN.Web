using System;
using System.Collections.Generic;
using System.Reflection;
using System.Data;
using System.Linq;
using System.Configuration;
using USDA.ARS.GRIN.Common.DataLayer;
using USDA.ARS.GRIN.Web.AppLayer;
using USDA.ARS.GRIN.Web.DataLayer;

namespace USDA.ARS.GRIN.Web.DataLayer
{
    public class CooperatorManager : AppDataManagerBase, IManager<Cooperator, CooperatorSearch>
    {
        public void BuildInsertUpdateParameters()
        {
            throw new NotImplementedException();
        }

        public int Delete(Cooperator entity)
        {
            throw new NotImplementedException();
        }

        public Cooperator Get(int entityId)
        {
            List<Cooperator> cooperators = new List<Cooperator>();
            Cooperator cooperator = new Cooperator();

            CooperatorSearch cooperatorSearch = new CooperatorSearch();
            cooperatorSearch.ID = entityId;
            cooperators = Search(cooperatorSearch);
            if (cooperators.Count == 1)
            {
                cooperator = cooperators[0];
            }
            return cooperator;
        }

        public List<Cooperator> GetApplicationCooperators()
        {
            //string appCode = ConfigurationManager.AppSettings["AppCode"];
            string appCode = "";

            List<Cooperator> applicationCooperators = new List<Cooperator>();
            SQL = "usp_GGTools_GRINGlobal_SysUsersByGroup_Select";

            var parameters = new List<IDbDataParameter> {
                CreateParameter("group_name", (object)appCode, false)
            };

            applicationCooperators = GetRecords<Cooperator>(SQL, CommandType.StoredProcedure, parameters.ToArray());
            return applicationCooperators;
        }

        //public List<ReportItem> GetRecordsOwned(int cooperatorId)
        //{
        //    List<ReportItem> reportItems = new List<ReportItem>();
        //    SQL = "usp_GGTools_GRINGlobal_RecordsOwnedByCooperator_Select";

        //    var parameters = new List<IDbDataParameter> {
        //        CreateParameter("cooperator_id", (object)cooperatorId, false)
        //    };

        //    reportItems = GetRecords<ReportItem>(SQL, CommandType.StoredProcedure, parameters.ToArray());

        //    double totalOwned = reportItems.Sum(x => x.ItemCount);

        //    return reportItems;
        //}

        public int Insert(Cooperator entity)
        {
            Reset(CommandType.StoredProcedure);
            Validate<Cooperator>(entity);
            SQL = "usp_GGTools_GRINGLobal_Cooperator_Insert";

            BuildInsertUpdateParameters(entity);

            AddParameter("@out_error_number", -1, true, System.Data.DbType.Int32, System.Data.ParameterDirection.Output);
            AddParameter("@out_cooperator_id", -1, true, System.Data.DbType.Int32, System.Data.ParameterDirection.Output);
            RowsAffected = ExecuteNonQuery();

            entity.ID = GetParameterValue<int>("@out_cooperator_id", -1);
            var errorNumber = GetParameterValue<int>("@out_error_number", -1);

            if (errorNumber > 0)
                throw new Exception(errorNumber.ToString());

            return entity.ID;
        }

        public List<Cooperator> Search(CooperatorSearch searchEntity)
        {
            List<Cooperator> results = new List<Cooperator>();

            SQL = " SELECT * FROM vw_GGTools_GRINGlobal_Cooperators";
            SQL += " WHERE (@ID                     IS NULL     OR ID                       =       @ID)";
            SQL += " AND (@FirstName                IS NULL     OR FirstName                LIKE    '%' + @FirstName + '%')";
            SQL += " AND (@LastName                 IS NULL     OR LastName                 LIKE    '%' + @LastName + '%')";
            SQL += " AND (@EmailAddress             IS NULL     OR EmailAddress             LIKE    '%' + @EmailAddress + '%')";
            SQL += " AND (@StatusCode               IS NULL     OR StatusCode               =       @StatusCode)";
            SQL += " AND (@SiteID                   IS NULL     OR SiteID                   =       @SiteID)";
            SQL += " AND (@SysUserIsEnabled         IS NULL     OR SysUserIsEnabled         =       @SysUserIsEnabled)";

            //REFACTOR? If site ID is being used, restrict search to only records with user ID's -- matching criteria of web coop
            //report. Needed b/c view outer-joins coop and sys user tables.
            if (searchEntity.SiteID > 0)
            {
                SQL += " AND (SysUserID IS NOT NULL) ";
            }

            switch (searchEntity.CreatedTimeFrame)
            {
                case "TDY":
                    SQL += " AND (CONVERT(date, CooperatorCreatedDate) = CONVERT(date, GETDATE()))";
                    break;
                case "3DY":
                    SQL += " AND CooperatorCreatedDate >= DATEADD(day,-3, GETDATE())";
                    break;
                case "7DY":
                    SQL += " AND CooperatorCreatedDate >= DATEADD(day,-7, GETDATE())";
                    break;
                case "30D":
                    SQL += " AND CooperatorCreatedDate >= DATEADD(day,-30, GETDATE())";
                    break;
                case "60D":
                    SQL += " AND CooperatorCreatedDate >= DATEADD(day,-60, GETDATE())";
                    break;
            }

            switch (searchEntity.ModifiedTimeFrame)
            {
                case "TDY":
                    SQL += " AND (CONVERT(date, CooperatorModifiedDate) = CONVERT(date, GETDATE()))";
                    break;
                case "3DY":
                    SQL += " AND CooperatorModifiedDate >= DATEADD(day,-3, GETDATE())";
                    break;
                case "7DY":
                    SQL += " AND CooperatorModifiedDate >= DATEADD(day,-7, GETDATE())";
                    break;
                case "30D":
                    SQL += " AND CooperatorModifiedDate >= DATEADD(day,-30, GETDATE())";
                    break;
                case "60D":
                    SQL += " AND CooperatorModifiedDate >= DATEADD(day,-60, GETDATE())";
                    break;
            }
            SQL += " ORDER BY FullName";

            //if (!String.IsNullOrEmpty(searchEntity.StatusList))
            //{
            //    searchEntity.StatusList = String.Join(",", Array.ConvertAll(searchEntity.StatusList.Split(','), z => "'" + z + "'"));
            //    SQL += " AND StatusCode IN (" + searchEntity.StatusList + ")";
            //}

            var parameters = new List<IDbDataParameter> {
                CreateParameter("ID", searchEntity.ID > 0 ? (object)searchEntity.ID : DBNull.Value, true),
                CreateParameter("FirstName", (object)searchEntity.FirstName ?? DBNull.Value, true),
                CreateParameter("LastName", (object)searchEntity.LastName ?? DBNull.Value, true),
                CreateParameter("EmailAddress", (object)searchEntity.EmailAddress ?? DBNull.Value, true),
                CreateParameter("StatusCode", (object)searchEntity.StatusCode ?? DBNull.Value, true),
                CreateParameter("SiteID", searchEntity.SiteID > 0 ? (object)searchEntity.SiteID : DBNull.Value, true),
                CreateParameter("SysUserIsEnabled", (object)searchEntity.SysUserIsEnabled ?? DBNull.Value, true),
            };

            results = GetRecords<Cooperator>(SQL, parameters.ToArray());
            RowsAffected = results.Count;
            return results;
        }
        
        public List<Cooperator> SearchSiteCurators(int siteId)
        {
            SQL = "usp_GGTools_GRINGlobal_CooperatorsBySite_Select";
            List<Cooperator> cooperators = new List<Cooperator>();

            var parameters = new List<IDbDataParameter> {
                CreateParameter("site_id", (object)siteId, false)
            };

            cooperators = GetRecords<Cooperator>(SQL, CommandType.StoredProcedure, parameters.ToArray());
            return cooperators;
        }

        public int Update(Cooperator entity)
        {
            Reset(CommandType.StoredProcedure);
            Validate<Cooperator>(entity);
            SQL = "usp_GGTools_GRINGLobal_Cooperator_Update";

            BuildInsertUpdateParameters(entity);

            AddParameter("@out_error_number", -1, true, System.Data.DbType.Int32, System.Data.ParameterDirection.Output);
            RowsAffected = ExecuteNonQuery();

            var errorNumber = GetParameterValue<int>("@out_error_number", -1);

            if (errorNumber > 0)
                throw new Exception(errorNumber.ToString());

            return entity.ID;
        }

        public int Transfer(int sourceCooperatorID, int targetCooperatorId, string tableName)
        {
            Reset(CommandType.StoredProcedure);
            SQL = "usp_GGTools_GRINGlobal_CooperatorRecordOwnershipByTable_Update";

            AddParameter("sys_table_name", tableName, true);
            AddParameter("target_cooperator_id", targetCooperatorId, true);
            AddParameter("source_cooperator_id", sourceCooperatorID, true);

            RowsAffected = ExecuteNonQuery();

            //var errorNumber = GetParameterValue<int>("@out_error_number", -1);

            //if (errorNumber > 0)
            //    throw new Exception(errorNumber.ToString());

            return RowsAffected;
        }

        //public List<CodeValue> GetTimeFrameOptions()
        //{
        //    List<CodeValue> timeFrameOptions = new List<CodeValue>();
        //    timeFrameOptions.Add(new CodeValue { Value = "TDY", Title = "Today" });
        //    timeFrameOptions.Add(new CodeValue { Value = "3DY", Title = "Within the last 3 days" });
        //    timeFrameOptions.Add(new CodeValue { Value = "7DY", Title = "Within the last 7 days" });
        //    timeFrameOptions.Add(new CodeValue { Value = "30D", Title = "Within the last 30 days" });
        //    timeFrameOptions.Add(new CodeValue { Value = "60D", Title = "Within the last 60 days" });
        //    return timeFrameOptions;
        //}

        public List<SysGroup> GetGroups(int entityId)
        {
            List<SysGroup> groups = new List<SysGroup>();
            SQL = "SELECT * FROM vw_GGTools_GRINGlobal_SysGroupUserMaps " +
                " WHERE SysUserID = @SysUserID";
            var parameters = new List<IDbDataParameter> {
                CreateParameter("SysUserID", entityId, true),
            };
            groups = GetRecords<SysGroup>(SQL, parameters.ToArray());
            return groups;
        }

        //public List<State> GetStates()
        //{
        //    List<State> states = new List<State>();
        //    SQL = "SELECT ID, StateName FROM vw_GGTools_GRINGlobal_States";
        //    states = GetRecords<State>(SQL);
        //    return states;
        //}
        //public List<CodeValue> GetOrganizations()
        //{
        //    List<CodeValue> states = new List<CodeValue>();
        //    SQL = "SELECT OrganizationAbbrev AS Value, Organization AS Title FROM vw_GGTools_GRINGlobal_Organizations";
        //    List<CodeValue> codeValues = GetRecords<CodeValue>(SQL);
        //    return codeValues;
        //}
        public List<Site> GetSites()
        {
            List<Site> sites = new List<Site>();
            SQL = "SELECT * FROM vw_GGTools_GRINGlobal_Sites ORDER BY AssembledName";
            sites = GetRecords<Site>(SQL);
            return sites;
        }
        public virtual List<CodeValue> GetCodeValues(string groupName)
        {
            SQL = "usp_GGTools_GRINGlobal_CodeValuesByGroup_Select";
            var parameters = new List<IDbDataParameter> {
                CreateParameter("group_name", (object)groupName, false)
            };
            List<CodeValue> codeValues = GetRecords<CodeValue>(SQL, CommandType.StoredProcedure, parameters.ToArray());
            return codeValues;
        }
        public void BuildInsertUpdateParameters(Cooperator entity)
        {
            if (entity.ID > 0)
            {
                AddParameter("cooperator_id", entity.ID == 0 ? DBNull.Value : (object)entity.ID, true);
            }
            AddParameter("site_id", entity.SiteID == 0 ? DBNull.Value : (object)entity.SiteID, true);
            AddParameter("last_name", String.IsNullOrEmpty(entity.LastName) ? DBNull.Value : (object)entity.LastName, true);
            AddParameter("title", String.IsNullOrEmpty(entity.Salutation) ? DBNull.Value : (object)entity.Salutation, true);
            AddParameter("first_name", String.IsNullOrEmpty(entity.FirstName) ? DBNull.Value : (object)entity.FirstName, true);
            AddParameter("job", String.IsNullOrEmpty(entity.JobTitle) ? DBNull.Value : (object)entity.JobTitle, true);
            AddParameter("organization", String.IsNullOrEmpty(entity.Organization) ? DBNull.Value : (object)entity.Organization, true);
            AddParameter("organization_abbrev", String.IsNullOrEmpty(entity.OrganizationAbbrev) ? DBNull.Value : (object)entity.OrganizationAbbrev, true);
            AddParameter("address_line1", String.IsNullOrEmpty(entity.AddressLine1) ? DBNull.Value : (object)entity.AddressLine1, true);
            AddParameter("address_line2", String.IsNullOrEmpty(entity.AddressLine2) ? DBNull.Value : (object)entity.AddressLine2, true);
            AddParameter("address_line3", String.IsNullOrEmpty(entity.AddressLine3) ? DBNull.Value : (object)entity.AddressLine3, true);
            AddParameter("city", String.IsNullOrEmpty(entity.City) ? DBNull.Value : (object)entity.City, true);
            AddParameter("postal_index", String.IsNullOrEmpty(entity.PostalIndex) ? DBNull.Value : (object)entity.PostalIndex, true);
            AddParameter("geography_id", entity.GeographyID == 0 ? DBNull.Value : (object)entity.GeographyID, true);
            AddParameter("secondary_organization", String.IsNullOrEmpty(entity.Organization) ? DBNull.Value : (object)entity.Organization, true);
            AddParameter("secondary_organization_abbrev", String.IsNullOrEmpty(entity.OrganizationAbbrev) ? DBNull.Value : (object)entity.OrganizationAbbrev, true);
            AddParameter("secondary_address_line1", String.IsNullOrEmpty(entity.SecondaryAddressLine1) ? DBNull.Value : (object)entity.SecondaryAddressLine1, true);
            AddParameter("secondary_address_line2", String.IsNullOrEmpty(entity.SecondaryAddressLine2) ? DBNull.Value : (object)entity.SecondaryAddressLine2, true);
            AddParameter("secondary_address_line3", String.IsNullOrEmpty(entity.SecondaryAddressLine3) ? DBNull.Value : (object)entity.SecondaryAddressLine3, true);
            AddParameter("secondary_city", String.IsNullOrEmpty(entity.SecondaryCity) ? DBNull.Value : (object)entity.SecondaryCity, true);
            AddParameter("secondary_postal_index", String.IsNullOrEmpty(entity.SecondaryPostalIndex) ? DBNull.Value : (object)entity.SecondaryPostalIndex, true);
            AddParameter("secondary_geography_id", entity.GeographyID == 0 ? DBNull.Value : (object)entity.GeographyID, true);
            AddParameter("primary_phone", String.IsNullOrEmpty(entity.PrimaryPhone) ? DBNull.Value : (object)entity.PrimaryPhone, true);
            AddParameter("secondary_phone", String.IsNullOrEmpty(entity.SecondaryPhone) ? DBNull.Value : (object)entity.SecondaryPhone, true);
            AddParameter("fax", String.IsNullOrEmpty(entity.Fax) ? DBNull.Value : (object)entity.Fax, true);
            AddParameter("email_address", String.IsNullOrEmpty(entity.EmailAddress) ? DBNull.Value : (object)entity.EmailAddress, true);
            AddParameter("secondary_email_address", String.IsNullOrEmpty(entity.SecondaryEmailAddress) ? DBNull.Value : (object)entity.SecondaryEmailAddress, true);
            AddParameter("status_code", String.IsNullOrEmpty(entity.StatusCode) ? DBNull.Value : (object)entity.StatusCode, true);
            AddParameter("category_code", String.IsNullOrEmpty(entity.CategoryCode) ? DBNull.Value : (object)entity.CategoryCode, true);
            AddParameter("organization_region_code", String.IsNullOrEmpty(entity.OrganizationRegionCode) ? DBNull.Value : (object)entity.OrganizationRegionCode, true);
            AddParameter("discipline_code", String.IsNullOrEmpty(entity.DisciplineCode) ? DBNull.Value : (object)entity.DisciplineCode, true);
            AddParameter("note", String.IsNullOrEmpty(entity.Note) ? DBNull.Value : (object)entity.Note, true);

            if (entity.ID > 0)
            {
                AddParameter("modified_by", entity.ModifiedByCooperatorID == 0 ? DBNull.Value : (object)entity.ModifiedByCooperatorID, true);
            }
            else
            {
                AddParameter("created_by", entity.CreatedByCooperatorID == 0 ? DBNull.Value : (object)entity.CreatedByCooperatorID, true);
            }
        }
    }
}
