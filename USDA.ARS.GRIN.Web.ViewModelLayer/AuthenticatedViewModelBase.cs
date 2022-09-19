using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using USDA.ARS.GRIN.Common.Library.Email;
using USDA.ARS.GRIN.Common.Library.Exceptions;
using USDA.ARS.GRIN.Common.Library.Security;
using USDA.ARS.GRIN.Web.DataLayer;
using USDA.ARS.GRIN.Web.AppLayer;

namespace USDA.ARS.GRIN.Web.ViewModelLayer
{
    public class AuthenticatedViewModelBase : AppViewModelBase
    {
        public SysUser AuthenticatedUser { get; set; }
       
    }
}
