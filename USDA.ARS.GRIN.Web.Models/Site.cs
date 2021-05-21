using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDA.ARS.GRIN.Web.Models
{
    public class Site
    {
        public int ID { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public Address Address { get; set;}
        public string PrimaryPhone { get; set; }
        public string SecondaryPhone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public Site()
        {
            Address = new Address();
        }
    }
}
