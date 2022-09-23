using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Text;
using USDA.ARS.GRIN.Web.DataLayer;

namespace USDA.ARS.GRIN.Web.WebUI
{
    public static class AppInfo
    {
        public static SysUser AuthenticatedUser
        {
            get
            {
                SysUser authenticatedUser = new SysUser();
                AuthenticatedUserSession authenticatedUserSession = System.Web.HttpContext.Current.Session["AUTHENTICATED_USER_SESSION"] as AuthenticatedUserSession;

                if (authenticatedUserSession != null)
                    authenticatedUser = authenticatedUserSession.User;

                return authenticatedUser;
            }
        }
        public static string GetPageTitle()
        {
            string pageTitle = System.Configuration.ConfigurationManager.AppSettings["AppTitle"];
            return pageTitle;
        }

        public static string GetVersion()
        {
            Version version = null;
            StringBuilder versionNumber = new StringBuilder();

            version = Assembly.GetExecutingAssembly().GetName().Version;
            versionNumber.Append(version.Major.ToString());
            versionNumber.Append(".");
            versionNumber.Append(version.Minor.ToString());
            versionNumber.Append(".");
            versionNumber.Append(version.Build.ToString());
            return versionNumber.ToString();
        }

        public static SysUser GetAuthenticatedUser()
        {
            SysUser authenticatedUser = new SysUser(); 
            AuthenticatedUserSession authenticatedUserSession = System.Web.HttpContext.Current.Session["AUTHENTICATED_USER_SESSION"] as AuthenticatedUserSession;
            
            if (authenticatedUserSession != null)
                authenticatedUser = authenticatedUserSession.User;
            
            return authenticatedUser;
        }
    }
}