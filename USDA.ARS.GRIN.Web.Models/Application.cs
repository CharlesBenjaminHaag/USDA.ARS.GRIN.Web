using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDA.ARS.GRIN.Web.DataLayer
{
    public class Application : BaseModel
    {
        public int ID { get; set; }
        public int GroupID { get; set; }
        public string ApplicationCode { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public string ColorCode { get; set; }
        public string ImageFileName { get; set; }
        public bool IsAuthorized { get; set; }
    }
}
