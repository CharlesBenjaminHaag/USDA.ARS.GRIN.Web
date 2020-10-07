using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using USDA.ARS.GRIN.Web.Models;

namespace USDA.ARS.GRIN.Web.Repository
{
    public abstract class BaseRepository
    {
        protected RepositoryDataContext _dataContext = null;

        public BaseRepository()
        {
            this._dataContext = new RepositoryDataContext(ConfigurationManager.ConnectionStrings["DataManager"].ToString());
        }

        public static SqlConnection GetConnection(string connectionName)
        {
            string cnstr = ConfigurationManager.ConnectionStrings["DataManager"].ConnectionString;
            SqlConnection cn = new SqlConnection(cnstr);
            cn.Open();
            return cn;
        }

    }
}
