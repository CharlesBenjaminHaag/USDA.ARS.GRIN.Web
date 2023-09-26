using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NLog;
using USDA.ARS.GRIN.Web.ViewModelLayer;

namespace USDA.ARS.GRIN.Web.UI.v2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            LoadCachedData();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            Log.Error(exception, exception.Message);
        }

        protected void LoadCachedData()
        {
            RhizobiumViewModel rhizobiumViewModel = new RhizobiumViewModel();
            rhizobiumViewModel.Search();
        }
    }
}
