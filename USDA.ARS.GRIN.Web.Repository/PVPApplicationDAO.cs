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
    public class PVPApplicationDAO : BaseDAO
    {
        public List<PVPApplication> Find(string context)
        {
            const string COMMAND_TEXT_EXPIRING = "usp_ARS_PVPExpiring6Months_Select";
            const string COMMAND_TEXT_RECENT = "usp_ARS_PVPRecentApplications_Select";
            const string COMMAND_TEXT_AVAILABLE = "usp_ARS_PVPRecentlyAvailable_Select";

            List<PVPApplication> pVPApplications = new List<PVPApplication>();

            try 
            {
                using (SqlConnection conn = GetConnection("DataManager"))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;

                        switch (context)
                        {
                            case "expired":
                                cmd.CommandText = COMMAND_TEXT_AVAILABLE;
                                break;
                            case "expiring":
                                cmd.CommandText = COMMAND_TEXT_EXPIRING;
                                break;
                            case "submitted":
                                cmd.CommandText = COMMAND_TEXT_RECENT;
                                break;
                        }

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PVPApplication pVPApplication = new PVPApplication();
                                pVPApplication.ApplicationNumber = GetInt(reader["pvp_application_number"].ToString());
                                pVPApplication.CultivarName = reader["cultivar_name"].ToString();
                                pVPApplication.ExperimentalName = reader["experimental_name"].ToString();
                                pVPApplication.ScientificName = reader["scientific_name"].ToString();
                                pVPApplication.CommonName = reader["common_name"].ToString();
                                pVPApplication.ApplicantName = reader["applicant_name"].ToString();
                                pVPApplication.ApplicationDate = GetDate(reader["application_date"].ToString());
                                pVPApplication.IsCertifiedSeed = ParseBool(reader["is_certified_seed"].ToString());
                                pVPApplication.ApplicationStatus = reader["application_status"].ToString();
                                pVPApplication.CertificateIssuedDate = GetDate(reader["certificate_issued_date"].ToString());
                                pVPApplication.YearsProtected = GetInt(reader["years_protected"].ToString());
                                pVPApplication.ExpirationDate = GetDate(reader["expiration_date"].ToString());
                                pVPApplication.AccessionID = GetInt(reader["accession_id"].ToString());
                                pVPApplications.Add(pVPApplication);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return pVPApplications;
        }
    }
}
