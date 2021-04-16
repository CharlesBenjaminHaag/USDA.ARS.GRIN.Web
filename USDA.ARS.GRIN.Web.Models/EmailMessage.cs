using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDA.ARS.GRIN.Web.Models
{
    public class EmailMessage
    {
        public string RecipientAddress { get; set; }
        public string SenderAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtmlFormat { get; set; }
    }
}
