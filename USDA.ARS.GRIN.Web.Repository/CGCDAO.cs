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
    public class CGCDAO: BaseDAO
    {
        public List<CropGermplasmCommittee> FindAll()
        {
            List<CropGermplasmCommittee> cropGermplasmCommittees = new List<CropGermplasmCommittee>();
            
            try 
            {
                const string COMMAND_TEXT_NAME = "usp_ARSCropGermplasmCommittees_Select";

                
                    using (SqlConnection conn = GetConnection("DataManager"))
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = COMMAND_TEXT_NAME;
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            cropGermplasmCommittees.Add(new CropGermplasmCommittee { ID = GetInt(reader["crop_germplasm_committee_id"].ToString()), Name = reader[""].ToString() } );
                        }
                    }
               
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return cropGermplasmCommittees;
        }

    }
}
