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

        public List<CodeValue> GetTotals()
        {
            List<CodeValue> codeValues = new List<CodeValue>();
            SQL = "SELECT * FROM vw_GGTools_GRINGlobal_PVPApplicationTotals";
            codeValues = GetRecords<CodeValue>(SQL, CommandType.Text);
            return codeValues;
        }

        public int Insert(PVPApplication entity)
        {
            throw new NotImplementedException();
        }

        public List<PVPApplication> Search(PVPApplicationSearch searchEntity)
        {
            List<PVPApplication> results = new List<PVPApplication>();

            SQL = " SELECT * FROM vw_GRINGlobal_Accession_IPR ";
            SQL += " WHERE  (@ApplicationNumber     IS NULL     OR ApplicationNumber    =       @ApplicationNumber)";
            SQL += " AND    (@CertificateStatus     IS NULL     OR CertificateStatus    =       @CertificateStatus)";
            SQL += " AND    (@VarietyName           IS NULL     OR VarietyName          LIKE    '%' + @VarietyName + '%')";
            SQL += " AND    (@CommonName            IS NULL     OR CommonName           LIKE    '%' + @CommonName + '%')";
            SQL += " AND    (@ScientificName        IS NULL     OR ScientificName       LIKE    '%' + @ScientificName + '%')";
            SQL += " AND    (@ExperimentalName      IS NULL     OR ExperimentalName     LIKE    '%' + @ExperimentalName + '%')";
            SQL += " AND    (@Applicant             IS NULL     OR Applicant            LIKE    '%' + @Applicant + '%')";

            switch (searchEntity.TimeFrame)
            {
                case "EXP6":
                    SQL += " AND CertificateStatus = 'Certificate Issued'";
                    SQL += " AND DATEDIFF(month, ExpirationDate, GETDATE()) BETWEEN 0 AND 6";
                    break;
                case "REXP":
                    SQL += " AND CertificateStatus = 'Certificate Expired'";
                    SQL += " AND DATEDIFF(month, ExpirationDate, GETDATE()) BETWEEN 0 AND 6";
                    break;
                case "RSUB":
                    SQL += " AND CertificateStatus = 'Application Pending'";
                    SQL += " AND DATEDIFF(month, StatusDate, GETDATE()) BETWEEN 0 AND 6";
                    break;
            }

            switch (searchEntity.StatusDateRange)
            {
                case "01Y":
                    SQL += " AND DATEDIFF(year, StatusDate, GETDATE()) BETWEEN 0 AND 1";
                    break;
                case "05Y":
                    SQL += " AND DATEDIFF(year, StatusDate, GETDATE()) BETWEEN 0 AND 5";
                    break;
                case "10Y":
                    SQL += " AND DATEDIFF(year, StatusDate, GETDATE()) BETWEEN 0 AND 10";
                    break;
            }

            SQL += " ORDER BY StatusDate DESC";

            var parameters = new List<IDbDataParameter> {
                CreateParameter("ApplicationNumber", searchEntity.ID > 0 ? (object)searchEntity.ApplicationNumber : DBNull.Value, true),
                CreateParameter("CertificateStatus", (object)searchEntity.CertificateStatus ?? DBNull.Value, true),
                CreateParameter("VarietyName", (object)searchEntity.Variety ?? DBNull.Value, true),
                CreateParameter("CommonName", (object)searchEntity.CommonName ?? DBNull.Value, true),
                CreateParameter("ScientificName", (object)searchEntity.ScientificName ?? DBNull.Value, true),
                CreateParameter("ExperimentalName", (object)searchEntity.ExperimentalName ?? DBNull.Value, true),
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
        public virtual List<CodeValue> GetCodeValues(string groupName)
        {
            SQL = "usp_GGTools_GRINGlobal_CodeValuesByGroup_Select";
            var parameters = new List<IDbDataParameter> {
                CreateParameter("group_name", (object)groupName, false)
            };
            List<CodeValue> codeValues = GetRecords<CodeValue>(SQL, CommandType.StoredProcedure, parameters.ToArray());
            return codeValues;
        }
    }
}
