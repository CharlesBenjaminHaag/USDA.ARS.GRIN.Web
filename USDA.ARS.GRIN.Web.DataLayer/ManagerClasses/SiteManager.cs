using System;
using System.Collections.Generic;
using System.Reflection;
using System.Data;
using System.Configuration;
using USDA.ARS.GRIN.Common.DataLayer;
using USDA.ARS.GRIN.Web.AppLayer;
using USDA.ARS.GRIN.Web.DataLayer;

namespace USDA.ARS.GRIN.Web.DataLayer
{
    public class SiteManager : AppDataManagerBase
    {
        public Site Get(int entityId)
        {
            SQL = "usp_GGTools_GRINGlobal_Site_Select";
            Site site = new Site();

            var parameters = new List<IDbDataParameter> {
                CreateParameter("site_id", (object)entityId, false)
            };
            site = GetRecord<Site>(SQL, CommandType.StoredProcedure, parameters.ToArray());
            //site.Crops = GetCrops(entityId);
            return site;
        }

        public List<CodeValue> GetCrops(int entityId)
        {
            SQL = "usp_GGTools_GRINGlobal_SiteCrops_Select";
            List<CodeValue> codeValues = new List<CodeValue>();

            var parameters = new List<IDbDataParameter> {
                CreateParameter("site_id", (object)entityId, false)
            };
            codeValues = GetRecords<CodeValue>(SQL, CommandType.StoredProcedure, parameters.ToArray());
            return codeValues;
        }

        public List<Site> Search(SiteSearch searchEntity)
        {
            List<Site> results = new List<Site>();

            SQL = " SELECT * FROM vw_GGTools_GRINGlobal_Sites";
            SQL += " WHERE (@ID                     IS NULL     OR ID                       =       @ID)";
            SQL += " AND (@ShortName                IS NULL     OR ShortName                LIKE    '%' + @ShortName + '%')";
            SQL += " AND (@LongName                 IS NULL     OR LongName                 LIKE    '%' + @LongName + '%')";
           
            var parameters = new List<IDbDataParameter> {
                CreateParameter("ID", searchEntity.ID > 0 ? (object)searchEntity.ID : DBNull.Value, true),
                CreateParameter("ShortName", (object)searchEntity.ShortName ?? DBNull.Value, true),
                CreateParameter("LongName", (object)searchEntity.LongName ?? DBNull.Value, true),
            };

            results = GetRecords<Site>(SQL, parameters.ToArray());
            RowsAffected = results.Count;
            return results;
        }

    }
}
