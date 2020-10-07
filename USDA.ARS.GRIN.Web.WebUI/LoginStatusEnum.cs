using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace USDA.ARS.GRIN.Web.WebUI.Controllers
{
    public enum LoginStatusEnum
    {
        SUCCESS = 1,
        USER_NOT_FOUND = 2,
        PASSWORD_INVALID = 3,
        PASSWORD_EXPIRED = 4,
        ERROR = 9
    }
}