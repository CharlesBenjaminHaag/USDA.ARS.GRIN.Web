using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Mvc;
using System.IO;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

namespace USDA.ARS.GRIN.Web.WebUI.Controllers
{
    public class BaseController : Controller
    {
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public string GetSetting(string key)
        {
            string setting = String.Empty;
            setting = ConfigurationManager.AppSettings[key];
            return setting;
        }

        protected ActionResult RenderExcel(string dataSourceName)
        {
            var gv = new GridView();
            DataTable dtSource = new DataTable();

            if (Session[dataSourceName] != null)
            {
                var dataSource = Session[dataSourceName];
                gv.DataSource = dataSource;
            }


            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment; filename=RhizobiumDataset.xls");
            //Response.ContentType = "application/ms-excel";

            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=" + dataSourceName + "_" + DateTime.Now.ToUniversalTime().ToString() + ".xls");


            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return View("Index");
        }
    }
}