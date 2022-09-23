using System;
using System.Collections.Generic;
using System.Reflection;
using System.Data;
using USDA.ARS.GRIN.Common.DataLayer;
using USDA.ARS.GRIN.Web.AppLayer;
using USDA.ARS.GRIN.Web.DataLayer;

namespace USDA.ARS.GRIN.Web.DataLayer
{
    public class PVPApplicationManager : AppDataManagerBase, IManager<PVPApplication, PVPApplicationSearch>
    {
        public void BuildInsertUpdateParameters()
        {
            throw new NotImplementedException();
        }

        public int Delete(PVPApplication entity)
        {
            throw new NotImplementedException();
        }

        public PVPApplication Get(int entityId)
        {
            throw new NotImplementedException();
        }

        public int Insert(PVPApplication entity)
        {
            throw new NotImplementedException();
        }

        public List<PVPApplication> Search(PVPApplicationSearch searchEntity)
        {
            string viewName = String.Empty;
            List<PVPApplication> results = new List<PVPApplication>();

            switch (searchEntity.TimeFrame)
            {
                case "EXP6":
                    viewName = "vw_GGTools_GRINGlobal_PVPApplicationCertificateExpiringIn6Months";
                    break;
                case "REXP":
                    viewName = "vw_GGTools_GRINGlobal_PVPApplicationCertificateRecentlyExpired";
                    break;
                case "RSUB":
                    viewName = "vw_GGTools_GRINGlobal_PVPApplicationRecentlySubmitted";
                    break;
            }

            SQL = " SELECT * FROM " + viewName;
            SQL += " WHERE  (@ApplicationNumber     IS NULL     OR ApplicationNumber    =       @ApplicationNumber)";
            SQL += " AND    (@Variety               IS NULL     OR Variety              LIKE    '%' + @Variety + '%')";
            SQL += " AND    (@Applicant             IS NULL     OR Applicant            LIKE    '%' + @Applicant + '%')";
            SQL += " ORDER BY StatusDate DESC";

            var parameters = new List<IDbDataParameter> {
                CreateParameter("ApplicationNumber", searchEntity.ID > 0 ? (object)searchEntity.ApplicationNumber : DBNull.Value, true),
                CreateParameter("Variety", (object)searchEntity.Variety ?? DBNull.Value, true),
                CreateParameter("Applicant", (object)searchEntity.Applicant ?? DBNull.Value, true),
            };

            results = GetRecords<PVPApplication>(SQL, parameters.ToArray());
            RowsAffected = results.Count;
            return results;
        }

        public int Update(PVPApplication entity)
        {
            throw new NotImplementedException();
        }
    }
}
