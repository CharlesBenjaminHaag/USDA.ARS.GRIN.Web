using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace USDA.ARS.GRIN.Web.WebUI.ViewModels.CGC
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Status { get; set; }
        public string ErrorMessage { get; set; }
    }
}