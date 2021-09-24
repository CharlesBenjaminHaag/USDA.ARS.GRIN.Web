using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using USDA.ARS.GRIN.Web.Models;

namespace USDA.ARS.GRIN.Web.Repository
{
    public class PVPRepository : BaseRepository
    {
        public List<ReferenceItem> GetApplicationStatusList()
        {
            List<ReferenceItem> referenceItemList = new List<ReferenceItem>();

            try
            {
                var results = _dataContext.usp_ARS_PVPApplicationStatuses_Select().Where(x => x.title.Contains("Application")).ToList();
                foreach (var result in results)
                {
                    referenceItemList.Add(new ReferenceItem { Context = "application-status", ID = result.id, Title = result.title.Replace("Application ", "") + " (" + result.count.ToString() + ")" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return referenceItemList;
        }

        public List<ReferenceItem> GetCertificateStatusList()
        {
            List<ReferenceItem> referenceItemList = new List<ReferenceItem>();

            try
            {
                var results = _dataContext.usp_ARS_PVPApplicationStatuses_Select().Where(x => x.title.Contains("Certificate")).ToList();
                foreach (var result in results)
                {
                    referenceItemList.Add(new ReferenceItem { Context = "application-status", ID = result.id, Title = result.title.Replace("Certificate ", "") + " (" + result.count.ToString() + ")" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return referenceItemList;
        }

        //public List<ReferenceItem> GetCommonNameList()
        //{
        //    List<ReferenceItem> referenceItemList = new List<ReferenceItem>();

        //    try
        //    {
        //        var results = this._dataContext.usp_PVPCommonNames_Select().ToList();
        //        if (results != null)
        //        {
        //            if (results.Count() > 0)
        //            {
        //                foreach (var result in results)
        //                {
        //                    referenceItemList.Add(new ReferenceItem { Context = "scientific-name", ID = result.id, Title = result.title + " (" + result.count.ToString() + ")"  });
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return referenceItemList;
        //}

        //public List<ReferenceItem> GetExpirationPeriodList() 
        //{
        //    List<ReferenceItem> referenceItemList = new List<ReferenceItem>();

        //    try
        //    {
        //        var results = this._dataContext.usp_PVPExpirationPeriods_Select().ToList();
        //        if (results != null)
        //        {
        //            if (results.Count() > 0)
        //            {
        //                foreach (var result in results)
        //                {
        //                    referenceItemList.Add(new ReferenceItem { Context = "expiration-period", ID = result.sort_order, Title = result.category + " (" + result.count.ToString() + ")" });
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return referenceItemList;
        //}

        public PVPApplication GetPVPApplication(int id)
        {
            PVPApplication pVPApplication = new PVPApplication();

            try
            {
                var result = _dataContext.usp_ARS_PVPApplications_Search("WHERE pa.pvp_application_number = " + id.ToString()).First();
                if (result != null)
                {
                    pVPApplication.ApplicationNumber = result.pvp_application_number.GetValueOrDefault();
                    pVPApplication.CultivarName = result.cultivar_name;
                    pVPApplication.ExperimentalName = result.experimental_name;
                    pVPApplication.ScientificName = result.scientific_name;
                    pVPApplication.CommonName = result.common_name;
                    pVPApplication.ApplicantName = result.applicant_name;
                    pVPApplication.ApplicationDate = result.application_date.GetValueOrDefault();
                    pVPApplication.IsCertifiedSeed = result.is_certified_seed.GetValueOrDefault();
                    pVPApplication.ApplicationStatus = result.application_status;
                    pVPApplication.ApplicationStatusDate = result.status_date.GetValueOrDefault();
                    pVPApplication.CertificateIssuedDate = result.certificate_issued_date.GetValueOrDefault();
                    pVPApplication.YearsProtected = result.years_protected.GetValueOrDefault();
                    if (result.expiration_date != null)
                    {
                        pVPApplication.ExpirationDate = result.expiration_date.GetValueOrDefault();
                    }
                    pVPApplication.AccessionID = result.accession_id.GetValueOrDefault();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return pVPApplication;
        }

        public List<PVPApplication> GetPVPApplications(string context)
        {
            List<PVPApplication> pVPApplications = new List<PVPApplication>();
          
            try
            {
                switch (context)
                {
                    case "expiring":
                        var resultsExpiringApplications = _dataContext.usp_ARS_PVPExpiring6Months_Select().ToList();
                        foreach (var result in resultsExpiringApplications)
                        {
                            PVPApplication pVPApplication = new PVPApplication();
                            pVPApplication.ApplicationNumber = result.pvp_application_number;
                            pVPApplication.CultivarName = result.cultivar_name;
                            pVPApplication.ExperimentalName = result.experimental_name;
                            pVPApplication.ScientificName = result.scientific_name;
                            pVPApplication.CommonName = result.common_name;
                            pVPApplication.ApplicantName = result.applicant_name;
                            pVPApplication.ApplicationDate = result.application_date.GetValueOrDefault();
                            pVPApplication.IsCertifiedSeed = result.is_certified_seed.GetValueOrDefault();
                            pVPApplication.ApplicationStatus = result.application_status;
                            pVPApplication.CertificateIssuedDate = result.certificate_issued_date.GetValueOrDefault();
                            pVPApplication.YearsProtected = result.years_protected.GetValueOrDefault();
                            if (result.expiration_date != null)
                            {
                                pVPApplication.ExpirationDate = DateTime.Parse(result.expiration_date);
                            }
                            pVPApplication.AccessionID = result.accession_id.GetValueOrDefault();
                            pVPApplications.Add(pVPApplication);
                        }
                        break;
                    case "recent":
                        var resultsRecentApplications = _dataContext.usp_ARS_PVPRecentApplications_Select().ToList();
                        foreach (var result in resultsRecentApplications)
                        {
                            PVPApplication pVPApplication = new PVPApplication();
                            pVPApplication.ApplicationNumber = result.pvp_application_number;
                            pVPApplication.CultivarName = result.cultivar_name;
                            pVPApplication.ExperimentalName = result.experimental_name;
                            pVPApplication.ScientificName = result.scientific_name;
                            pVPApplication.CommonName = result.common_name;
                            pVPApplication.ApplicantName = result.applicant_name;
                            pVPApplication.ApplicationDate = result.application_date.GetValueOrDefault();
                            pVPApplication.IsCertifiedSeed = result.is_certified_seed.GetValueOrDefault();
                            pVPApplication.ApplicationStatus = result.application_status;
                            pVPApplication.CertificateIssuedDate = result.certificate_issued_date.GetValueOrDefault();
                            pVPApplication.YearsProtected = result.years_protected.GetValueOrDefault();
                            if (result.expiration_date != null)
                            {
                                pVPApplication.ExpirationDate = DateTime.Parse(result.expiration_date);
                            }
                            pVPApplication.AccessionID = result.accession_id.GetValueOrDefault();
                            pVPApplications.Add(pVPApplication);
                        }
                        break;
                    case "recently-expired":
                        var resultsRecentlyExpiredApplications = _dataContext.usp_ARS_PVPRecentlyExpired_Select().ToList();
                        foreach (var result in resultsRecentlyExpiredApplications)
                        {
                            PVPApplication pVPApplication = new PVPApplication();
                            pVPApplication.ApplicationNumber = result.pvp_application_number;
                            pVPApplication.CultivarName = result.cultivar_name;
                            pVPApplication.ExperimentalName = result.experimental_name;
                            pVPApplication.ScientificName = result.scientific_name;
                            pVPApplication.CommonName = result.common_name;
                            pVPApplication.ApplicantName = result.applicant_name;
                            pVPApplication.ApplicationDate = result.application_date.GetValueOrDefault();
                            pVPApplication.IsCertifiedSeed = result.is_certified_seed.GetValueOrDefault();
                            pVPApplication.ApplicationStatus = result.application_status;
                            pVPApplication.CertificateIssuedDate = result.certificate_issued_date.GetValueOrDefault();
                            pVPApplication.YearsProtected = result.years_protected.GetValueOrDefault();
                            if (result.expiration_date != null)
                            {
                                pVPApplication.ExpirationDate = DateTime.Parse(result.expiration_date);
                            }
                            pVPApplication.AccessionID = result.accession_id.GetValueOrDefault();
                            pVPApplications.Add(pVPApplication);
                        }
                        break;
                    case "recently-available":
                        var resultsRecentlyAvailable = _dataContext.usp_ARS_PVPRecentlyAvailable_Select().ToList();
                        foreach (var result in resultsRecentlyAvailable)
                        {
                            PVPApplication pVPApplication = new PVPApplication();
                            pVPApplication.ApplicationNumber = result.pvp_application_number;
                            pVPApplication.CultivarName = result.cultivar_name;
                            pVPApplication.ExperimentalName = result.experimental_name;
                            pVPApplication.ScientificName = result.scientific_name;
                            pVPApplication.CommonName = result.common_name;
                            pVPApplication.ApplicantName = result.applicant_name;
                            pVPApplication.ApplicationDate = result.application_date.GetValueOrDefault();
                            pVPApplication.IsCertifiedSeed = result.is_certified_seed.GetValueOrDefault();
                            pVPApplication.ApplicationStatus = result.application_status;
                            pVPApplication.ApplicationStatusDate = result.status_date.GetValueOrDefault();
                            pVPApplication.CertificateIssuedDate = result.certificate_issued_date.GetValueOrDefault();
                            pVPApplication.YearsProtected = result.years_protected.GetValueOrDefault();
                            if (result.expiration_date != null)
                            {
                                pVPApplication.ExpirationDate = DateTime.Parse(result.expiration_date);
                            }
                            pVPApplication.AccessionID = result.accession_id.GetValueOrDefault();
                            pVPApplications.Add(pVPApplication);
                        }
                        break;
                }

                    //switch (context)
                    //{
                    //    case "scientific-name":
                    //        var resultsByScientificName = _dataContext.usp_PVPApplicationsByCommonName_Select(referenceItemId).ToList();
                    //        if (resultsByScientificName != null)
                    //        {
                    //            if (resultsByScientificName.Count() > 0)
                    //            {
                    //                foreach (var result in resultsByScientificName)
                    //                {
                    //                    PVPApplication pVPApplication = new PVPApplication();
                    //                    pVPApplication.ApplicationNumber = result.pvp_application_number;
                    //                    pVPApplication.CultivarName = result.cultivar_name;
                    //                    pVPApplication.ExperimentalName = result.experimental_name;
                    //                    pVPApplication.ScientificName = result.scientific_name;
                    //                    pVPApplication.CommonName = result.common_name;
                    //                    pVPApplication.ApplicantName = result.applicant_name;
                    //                    pVPApplication.ApplicationDate = result.application_date.GetValueOrDefault();
                    //                    pVPApplication.IsCertifiedSeed = result.is_certified_seed.GetValueOrDefault();
                    //                    pVPApplication.ApplicationStatus = result.application_status;
                    //                    pVPApplication.CertificateIssuedDate = result.certificate_issued_date.GetValueOrDefault();
                    //                    pVPApplication.YearsProtected = result.years_protected.GetValueOrDefault();
                    //                    if (result.expiration_date != null)
                    //                    {
                    //                        pVPApplication.ExpirationDate = DateTime.Parse(result.expiration_date);
                    //                    }
                    //                    pVPApplication.AccessionID = result.accession_id.GetValueOrDefault();
                    //                    pVPApplications.Add(pVPApplication);
                    //                }
                    //            }
                    //        }

                    //        break;
                    //    case "application-status":
                    //        var resultsByApplicationStatus = _dataContext.usp_PVPApplicationsByApplicationStatus_Select(referenceItemId).ToList();
                    //        if (resultsByApplicationStatus != null)
                    //        {
                    //            if (resultsByApplicationStatus.Count() > 0)
                    //            {
                    //                foreach (var result in resultsByApplicationStatus)
                    //                {
                    //                    PVPApplication pVPApplication = new PVPApplication();
                    //                    pVPApplication.ApplicationNumber = result.pvp_application_number;
                    //                    pVPApplication.CultivarName = result.cultivar_name;
                    //                    pVPApplication.ExperimentalName = result.experimental_name;
                    //                    pVPApplication.ScientificName = result.scientific_name;
                    //                    pVPApplication.CommonName = result.common_name;
                    //                    pVPApplication.ApplicantName = result.applicant_name;
                    //                    pVPApplication.ApplicationDate = result.application_date.GetValueOrDefault();
                    //                    pVPApplication.IsCertifiedSeed = result.is_certified_seed.GetValueOrDefault();
                    //                    pVPApplication.ApplicationStatus = result.application_status;
                    //                    pVPApplication.CertificateIssuedDate = result.certificate_issued_date.GetValueOrDefault();
                    //                    pVPApplication.YearsProtected = result.years_protected.GetValueOrDefault();
                    //                    if (result.expiration_date != null)
                    //                    {
                    //                        pVPApplication.ExpirationDate = DateTime.Parse(result.expiration_date);
                    //                    }
                    //                    pVPApplication.AccessionID = result.accession_id.GetValueOrDefault();
                    //                    pVPApplications.Add(pVPApplication);
                    //                }
                    //            }
                    //        }

                    //        break;
                    //    case "expiration-period":
                    //        var resultsByExpiration = _dataContext.usp_PVPApplicationsByExpiration_Select(referenceItemId).ToList();
                    //        if (resultsByExpiration != null)
                    //        {
                    //            if (resultsByExpiration.Count() > 0)
                    //            {
                    //                foreach (var result in resultsByExpiration)
                    //                {
                    //                    PVPApplication pVPApplication = new PVPApplication();
                    //                    pVPApplication.ApplicationNumber = result.pvp_application_number;
                    //                    pVPApplication.CultivarName = result.cultivar_name;
                    //                    pVPApplication.ExperimentalName = result.experimental_name;
                    //                    pVPApplication.ScientificName = result.scientific_name;
                    //                    pVPApplication.CommonName = result.common_name;
                    //                    pVPApplication.ApplicantName = result.applicant_name;
                    //                    pVPApplication.ApplicationDate = result.application_date.GetValueOrDefault();
                    //                    pVPApplication.IsCertifiedSeed = result.is_certified_seed.GetValueOrDefault();
                    //                    pVPApplication.ApplicationStatus = result.application_status;
                    //                    pVPApplication.CertificateIssuedDate = result.certificate_issued_date.GetValueOrDefault();
                    //                    pVPApplication.YearsProtected = result.years_protected.GetValueOrDefault();
                    //                    if (result.expiration_date != null)
                    //                    {
                    //                        pVPApplication.ExpirationDate = DateTime.Parse(result.expiration_date);
                    //                    }
                    //                    pVPApplication.AccessionID = result.accession_id.GetValueOrDefault();
                    //                    pVPApplications.Add(pVPApplication);
                    //                }
                    //            }
                    //        }

                    //        break;
                    //}
                }
            catch (Exception e)
            {
                throw e;
            }
            return pVPApplications;
        }
        public List<PVPApplication> Search(Search search)
        {
            const string WHERE_CLAUSE_BASE = "WHERE ";
            StringBuilder sbSqlWhereClause = new StringBuilder();
            StringBuilder sbSqlWhereClauseAppStatuses = new StringBuilder();
            StringBuilder sbSqlWhereClauseCertStatuses = new StringBuilder();
            List<PVPApplication> pVPCertificateRecords = new List<PVPApplication>();

            try
            {
                if (search.SearchCriteria.Where(x => x.FieldName == "pvp_application_number").Count() > 0)
                {
                    sbSqlWhereClause.Append("pvp_application_number = ");
                    sbSqlWhereClause.Append(search.SearchCriteria.Where(x => x.FieldName == "pvp_application_number").First().FieldValue);
                }
                else
                {
                    // TODO: Iterate through search criteria; construct WHERE clause. Default is AND; app statuses and cert statuses, respectively, use OR.
                    foreach (var result in search.SearchCriteria)
                    {
                        if (sbSqlWhereClause.Length > 0)
                        {
                            sbSqlWhereClause.Append(" AND ");
                        }
                       
                        sbSqlWhereClause.Append(result.FieldName);
                        sbSqlWhereClause.Append(" LIKE ");
                        sbSqlWhereClause.Append("'%");
                        sbSqlWhereClause.Append(result.FieldValue);
                        sbSqlWhereClause.Append("%'");
                    }

                    //if (search.ApplicationStatuses != null)
                    //{
                    //    if (search.ApplicationStatuses.Length > 0)
                    //    {
                    //        sbSqlWhereClauseAppStatuses.Append(" AND ");
                    //        sbSqlWhereClauseAppStatuses.Append("(");
                    //        foreach (string status in search.ApplicationStatuses)
                    //        {
                    //            sbSqlWhereClauseAppStatuses.Append(" OR ");
                    //        }
                    //        sbSqlWhereClause.Append(")");
                    //        sbSqlWhereClause.Append(sbSqlWhereClauseAppStatuses);
                    //    }
                    //}

                    //// TODO: CERT STATUSES
                    //if (search.CertificateStatuses.Length > 0)
                    //{
                    //    foreach (string status in search.CertificateStatuses)
                    //    {

                    //    }
                    //}


                }
                sbSqlWhereClause.Insert(0, WHERE_CLAUSE_BASE);
                var results = _dataContext.usp_ARS_PVPApplications_Search(sbSqlWhereClause.ToString()).ToList();

                if (results != null)
                {
                    foreach (var result in results)
                    {
                        PVPApplication pVPCertificateRecord = new PVPApplication();
                        pVPCertificateRecord.ApplicationNumber = result.pvp_application_number.GetValueOrDefault();
                        pVPCertificateRecord.CommonName = result.common_name;
                        pVPCertificateRecord.CultivarName = result.cultivar_name;
                        pVPCertificateRecord.ScientificName = result.scientific_name;
                        pVPCertificateRecord.ApplicantName = result.applicant_name;
                        pVPCertificateRecord.ApplicationStatus = result.application_status;
                        pVPCertificateRecords.Add(pVPCertificateRecord);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return pVPCertificateRecords;
        }
        public int Import(PVPApplication pVPApplication)
        {
            String commandText = "usp_InsertPVPApplication";
            int returnValue = 0;

            try
            {
                using (SqlConnection cn = GetConnection("DataManager"))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = commandText;
                    cmd.Parameters.AddWithValue("@application_number", pVPApplication.ApplicationNumber);
                    cmd.Parameters.AddWithValue("@variety_name", pVPApplication.CultivarName); 
                    cmd.Parameters.AddWithValue("@experimental_name", pVPApplication.ExperimentalName);
                    cmd.Parameters.AddWithValue("@scientific_name", pVPApplication.ScientificName);
                    cmd.Parameters.AddWithValue("@common_name", pVPApplication.CommonName);
                    cmd.Parameters.AddWithValue("@applicant_name", pVPApplication.ApplicantName);
                    cmd.Parameters.AddWithValue("@application_date", pVPApplication.ApplicationDate);
                    cmd.Parameters.AddWithValue("@certified_seed", pVPApplication.IsCertifiedSeed);
                    cmd.Parameters.AddWithValue("@certificate_status", pVPApplication.ApplicationStatus);
                    cmd.Parameters.AddWithValue("@status_date", pVPApplication.ApplicationStatusDate);
                    cmd.Parameters.AddWithValue("@issued_date", pVPApplication.CertificateIssuedDate);
                    cmd.Parameters.AddWithValue("@years_protected ", pVPApplication.YearsProtected);
                    cmd.Parameters.AddWithValue("@created_by", 174697);
                    returnValue = cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return returnValue;
        }
    }
}
