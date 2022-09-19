using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDA.ARS.GRIN.Web.DataLayer
{
    public class SysUserSearch
    {
        public int ID { get; set; }
        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string IsEnabled { get; set; }
        public int CooperatorID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string Organization { get; set; }
        public string Address { get; set; }
        public string IsCurrentAddress { get; set; }
        public string SiteShortName { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}
