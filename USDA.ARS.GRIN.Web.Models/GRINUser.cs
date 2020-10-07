using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDA.ARS.GRIN.Web.Models
{
    public class GRINUser 
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CooperatorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
        public string Email { get; set; }
        public string PrimaryPhone { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationAbbreviation { get; set; }
        public string JobTitle { get; set; }
        public Site Site { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Group> Groups { get; set; }
        public List<Application> Applications { get; set; }

        public GRINUser()
        {
            Site = new Site();
            Addresses = new List<Address>();
            Groups = new List<Group>();
            Applications = new List<Application>();
        }
    }
}
