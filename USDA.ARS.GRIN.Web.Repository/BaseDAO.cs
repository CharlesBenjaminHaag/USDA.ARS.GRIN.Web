using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace USDA.ARS.GRIN.Web.Repository
{
    public class BaseDAO
    {
        public SqlConnection GetConnection(string connectionName)
        {
            string cnstr = ConfigurationManager.ConnectionStrings["DataManager"].ConnectionString;
            if (String.IsNullOrEmpty(cnstr))
            {
                throw new Exception("Connection string has not been configured.");
            }

            SqlConnection cn = new SqlConnection(cnstr);
            if (cn == null)
            {
                throw new Exception("Unable to initialize database connection");
            }

            cn.Open();
            return cn;
        }

        #region Utilities

        public string UnBool(bool boolValue)
        {
            if (boolValue)
                return "Y";
            else
                return "N";
        }

        public int ConvertBool(bool boolValue)
        {
            if (boolValue)
                return 1;
            else
                return 0;
        }

        protected int GetInt(string intValue)
        {
            int convertedInt = 0;

            if (Int32.TryParse(intValue, out convertedInt))
            {
                return convertedInt;
            }
            else
            {
                return -9;
            }
        }

        protected DateTime GetDate(string dateTime)
        {
            DateTime convertedDateTime;

            if (DateTime.TryParse(dateTime, out convertedDateTime))
            {
                return convertedDateTime;
            }
            else
                return DateTime.MinValue;
        }

        public bool ParseBool(string boolValue)
        {

            bool boolResult = false;

            if ((boolValue.ToUpper() == "Y") || (boolValue == "1") || (boolValue.ToUpper() == "TRUE"))
            {
                boolResult = true;
            }
            return boolResult;
        }

        public DateTime ParseDate(string dateTime)
        {
            DateTime dateTimeResult;

            if (String.IsNullOrEmpty(dateTime))
            {
                return DateTime.MinValue;
            }
            else
            {
                if (DateTime.TryParse(dateTime, out dateTimeResult))
                {
                    return dateTimeResult;
                }
                else
                {
                    return DateTime.MinValue;
                }
            }
        }

        #endregion Utilities
    }
}
