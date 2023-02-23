using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Net;
using System.IO;
using System.Data;
using ExcelDataReader;
using System.Collections.ObjectModel;
using USDA.ARS.GRIN.Web.DataLayer;

namespace USDA.ARS.GRIN.Web.ViewModelLayer
{
    public class PVPApplicationViewModel: PVPApplicationViewModelBase
    {
        public void GetTotals()
        {
            using (PVPApplicationManager mgr = new PVPApplicationManager())
            {
                DataCollectionTotals = new Collection<CodeValue>(mgr.GetTotals());
                RowsAffected = mgr.RowsAffected;
            }
        }
        
        public void Search()
        {
            using (PVPApplicationManager mgr = new PVPApplicationManager())
            {
                try
                {
                    DataCollection = new Collection<PVPApplication>(mgr.Search(SearchEntity));
                    RowsAffected = mgr.RowsAffected;

                    if (RowsAffected == 1)
                    {
                        Entity = DataCollection[0];
                    }
                }
                catch (Exception ex)
                {
                    PublishException(ex);
                    throw ex;
                }
            }
        }

        public void Import()
        {
            WebClient client = new WebClient();
            client.DownloadFile("https://www.ams.usda.gov/sites/default/files/media/PVPOApplicationStatus.xlsx", "c:\\_DOWNLOADS\\PVPOApplicationStatus.xlsx");

            using (var stream = File.Open("c:\\_DOWNLOADS\\PVPOApplicationStatus.xlsx", FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });
                    DataTable dt = result.Tables[0];
                    foreach (DataRow row in dt.Rows)
                    {
                        //PVPApplication pVPApplication = new PVPApplication();
                        //pVPApplication.ApplicationNumber = Convert.ToInt32(row[0].ToString());
                        //pVPApplication.CultivarName = row[1].ToString();
                        //pVPApplication.ExperimentalName = row[2].ToString();
                        //pVPApplication.ScientificName = row[3].ToString();
                        //pVPApplication.CommonName = row[4].ToString();
                        //pVPApplication.ApplicantName = row[5].ToString();
                        //pVPApplication.ApplicationDate = DateTime.Parse(row[6].ToString());
                        //pVPApplication.IsCertifiedSeed = row[7].ToString() == "Yes" ? true : false;
                        //pVPApplication.ApplicationStatus = row[8].ToString();
                        //pVPApplication.ApplicationStatusDate = DateTime.Parse(row[9].ToString());

                        string DEBUG = row[10].ToString();
                        DateTime DEBUG_DATE = DateTime.MinValue;
                        //if (DateTime.TryParse(DEBUG, out DEBUG_DATE))
                        //{
                        //    pVPApplication.CertificateIssuedDate = DateTime.Parse(row[10].ToString());
                        //}


                        //pVPApplication.YearsProtected = Int32.Parse(row[11].ToString());


                        //_repository.Import(pVPApplication);
                    }
                }
            }
        }
    }
}
