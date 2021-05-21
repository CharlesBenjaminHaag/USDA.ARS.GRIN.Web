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
    public class SiteDAO: BaseDAO
    {
        public List<Site> FindAll()
        {
            const string COMMAND_TEXT_NAME = "usp_ARSSites_Select";
            List<Site> sites = new List<Site>();

            try
            {
                using (SqlConnection conn = GetConnection("DataManager"))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = COMMAND_TEXT_NAME;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Site site = new Site();
                        site.ID = GetInt(reader["crop_germplasm_committee_id"].ToString());
                        site.ShortName = reader["site_short_name"].ToString();
                        site.LongName = reader["site_long_name"].ToString();
                        site.Address.AddressLine1 = reader["address_line1"].ToString();
                        site.Address.AddressLine2 = reader["address_line2"].ToString();
                        site.Address.AddressLine3 = reader["address_line3"].ToString();
                        site.Address.City = reader["city"].ToString();
                        site.Address.State = reader["state"].ToString();
                        site.Address.ZIP = reader["postal_index"].ToString();
                        site.PrimaryPhone = reader["primary_phone"].ToString();
                        site.SecondaryPhone = reader["secondary_phone"].ToString();
                        site.Fax = reader["fax"].ToString();
                        site.Email = reader["email"].ToString();
                        sites.Add(site);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return sites;
        }
    }
}
