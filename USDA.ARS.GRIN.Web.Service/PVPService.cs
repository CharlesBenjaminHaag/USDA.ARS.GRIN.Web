using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USDA.ARS.GRIN.Web.Models;
using USDA.ARS.GRIN.Web.Repository;

namespace USDA.ARS.GRIN.Web.Service
{
    public class PVPService
    {
        private PVPApplicationDAO _pVPApplicationDAO = new PVPApplicationDAO();

        public List<PVPApplication> List(string context)
        {
            return _pVPApplicationDAO.Find(context);
        }
    }
}
