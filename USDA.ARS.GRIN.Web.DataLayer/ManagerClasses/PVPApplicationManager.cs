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
            List<PVPApplication> results = new List<PVPApplication>();

            SQL = " SELECT TOP 100 * FROM vw_GGTools_GRINGlobal_PVPApplication";
            SQL += " WHERE  (@ApplicationNumber     IS NULL     OR ApplicationNumber    =       @ApplicationNumber)";
            SQL += " AND    (@Variety               IS NULL     OR Variety              LIKE    '%' + @Variety + '%')";
            SQL += " AND    (@Applicant             IS NULL     OR Applicant            LIKE    '%' + @Applicant + '%')";
            
            switch (searchEntity.TimeFrame)
            {
                case "7D":
                    SQL += " AND StatusDate >= DATEADD(day,-7, GETDATE())";
                    break;
                case "30D":
                    SQL += " AND StatusDate >= DATEADD(day,-30, GETDATE())";
                    break;
                case "6M":
                    SQL += " AND StatusDate >= DATEADD(month,-6, GETDATE())";
                    break;
                case "YR":
                    SQL += " AND StatusDate >= DATEADD(year,-1, GETDATE())";
                    break;
            }

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
