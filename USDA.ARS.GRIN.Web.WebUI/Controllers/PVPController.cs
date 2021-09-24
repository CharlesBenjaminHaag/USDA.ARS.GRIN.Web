using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USDA.ARS.GRIN.Web.Models;
using USDA.ARS.GRIN.Web.WebUI.ViewModels;
using USDA.ARS.GRIN.Web.Repository;
using USDA.ARS.GRIN.Web.Service;

namespace USDA.ARS.GRIN.Web.WebUI.Controllers
{
    public class PVPController : BaseController
    {
        Repository.PVPRepository _repository = new PVPRepository();

        // GET: PVP
        public ActionResult Index(string viewBy = "")
        {
            PVPHomeViewModel viewModel = new PVPHomeViewModel();

            try
            {
                viewModel.RecentPVPApplications = _repository.GetPVPApplications("recent");
                viewModel.ExpiringPVPApplications = _repository.GetPVPApplications("expiring");
                viewModel.RecentlyExpiredPVPApplications = _repository.GetPVPApplications("recently-expired");
                viewModel.RecentlyAvailablePVPApplications = _repository.GetPVPApplications("recently-available");
                return View(viewModel);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message + ex.StackTrace);
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        public ActionResult Summary(int pvNumber)
        {
            PVPApplicationSummaryViewModel viewModel = new PVPApplicationSummaryViewModel();
            PVPApplication pVPApplication = null;

            try
            {
                pVPApplication = _repository.GetPVPApplication(pvNumber);
                viewModel.ApplicationNumber = pVPApplication.ApplicationNumber;
                viewModel.CultivarName = pVPApplication.CultivarName;
                viewModel.ExperimentalName = pVPApplication.ExperimentalName;
                viewModel.ScientificName = pVPApplication.ScientificName;
                viewModel.CommonName = pVPApplication.CommonName;
                viewModel.ApplicantName = pVPApplication.ApplicantName;
                viewModel.IsCertifiedSeed = pVPApplication.IsCertifiedSeed;
                viewModel.ApplicationStatus = pVPApplication.ApplicationStatus;
                viewModel.ApplicationStatusDate = pVPApplication.ApplicationStatusDate;
                viewModel.CertificateIssuedDate = pVPApplication.CertificateIssuedDate;
                viewModel.ExpirationDate = pVPApplication.ExpirationDate;
                viewModel.YearsProtected = pVPApplication.YearsProtected;
                viewModel.AccessionID = pVPApplication.AccessionID;
                if (viewModel.AccessionID > 0)
                {
                    // TO DO: NEED TO CUSTOMIZE URL
   //                 if ($STATUS eq 'Certificate Expired' || $STATUS eq 'Certificate Issued') 
   //{
   //                     if (length($pvnumber) < 9) {$pvnumber = "00$pvnumber"; }
   //                     print "<a href=\"https://apps.ams.usda.gov/CMS/AdobeImages/$pvnumber.pdf\">";
   //                     print " - View Certificate</a>";
   //                 }



                    viewModel.GRINGlobalAccessionURL = "<a href='" + String.Format("https://npgsweb.ars-grin.gov/gringlobal/accessiondetail.aspx?id={0}", viewModel.AccessionID) + "'>View Accession</a>";
                }
                else
                {
                    viewModel.GRINGlobalAccessionURL = "<strong>Not Currently Available in GRIN</strong>";
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message + ex.StackTrace);
                return View("~/Views/Shared/Error.cshtml");
            }
            return View("~/Views/PVP/Summary.cshtml", viewModel);
        }

        public ActionResult Detail(int referenceItemId, string displayFormat)
        {
            PVPDetailViewModel viewModel = new PVPDetailViewModel();

            try
            {

                viewModel.CropID = referenceItemId;
                viewModel.Applications = _repository.GetPVPApplications(displayFormat);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message + ex.StackTrace);
            }
            return PartialView("~/Views/PVP/Detail.cshtml", viewModel);
        }

        //public ActionResult _DetailList(string viewBy)
        //{
        //    PVPDetailListViewModel viewModel = new PVPDetailListViewModel();

        //    try
        //    {
        //        switch (viewBy)
        //        {
        //            case "scientific-name":
        //                viewModel.ReferenceItems = _repository.GetCommonNameList();
        //                break;
        //            case "application-status":
        //                viewModel.ReferenceItems = _repository.GetApplicationStatusList();
        //                break;
        //            default:
        //                viewModel.ReferenceItems = _repository.GetExpirationPeriodList();
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex.Message + ex.StackTrace);
        //    }
        //    return PartialView("~/Views/PVP/_DetailList.cshtml", viewModel);
        //}

        public ActionResult Search(string searchField = "", string searchText = "")
        {
            PVPSearchViewModel viewModel = new PVPSearchViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Search(PVPSearchViewModel viewModel)
        {
            Search search = new Search();

            try
            {
                if ((viewModel.PVNumber == 0) &&
                    (String.IsNullOrEmpty(viewModel.Variety) &&
                    (String.IsNullOrEmpty(viewModel.CommonName) &&
                    (String.IsNullOrEmpty(viewModel.ApplicantName) &&
                    (String.IsNullOrEmpty(viewModel.SelectedApplicationStatuses) &&
                    (String.IsNullOrEmpty(viewModel.SelectedCertificateStatuses)))))))
                {
                    throw new IndexOutOfRangeException("Please enter at least one search criterion.");
                }

                if (viewModel.PVNumber > 0)
                {
                    search.SearchCriteria.Add(new SearchCriterion { FieldName = "pvp_application_number", ComparisonOperator = "=", FieldValue = viewModel.PVNumber.ToString() });
                }

                if (!String.IsNullOrEmpty(viewModel.Variety))
                {
                    search.SearchCriteria.Add(new SearchCriterion { FieldName = "cultivar_name", ComparisonOperator = "LIKE", FieldValue = viewModel.Variety });
                }

                if (!String.IsNullOrEmpty(viewModel.CommonName))
                {
                    search.SearchCriteria.Add(new SearchCriterion { FieldName = "pc.name", ComparisonOperator = "LIKE", FieldValue = viewModel.CommonName });
                }

                if (!String.IsNullOrEmpty(viewModel.ApplicantName))
                {
                    search.SearchCriteria.Add(new SearchCriterion { FieldName = "papp.name", ComparisonOperator = "LIKE", FieldValue = viewModel.ApplicantName });
                }

                if (!String.IsNullOrEmpty(viewModel.SelectedApplicationStatuses ))
                {
                    search.ApplicationStatuses = viewModel.SelectedApplicationStatuses.Split(',');
                    foreach (var value in search.ApplicationStatuses)
                        {
                        search.SearchCriteria.Add(new SearchCriterion { FieldName = "pas.pvp_application_status_id", ComparisonOperator = "LIKE", FieldValue = value });
                    }
                }

                if (!String.IsNullOrEmpty(viewModel.SelectedApplicationStatuses))
                {
                    search.CertificateStatuses = viewModel.SelectedCertificateStatuses.Split(',');
                    foreach (var value in search.CertificateStatuses)
                    {
                        search.SearchCriteria.Add(new SearchCriterion { FieldName = "pas.pvp_application_status_id", ComparisonOperator = "LIKE", FieldValue = value });
                    }
                }
                viewModel.SearchResults = _repository.Search(search);
                return View("~/Views/PVP/Search.cshtml", viewModel);
            }
            catch (IndexOutOfRangeException iex)
            {
                viewModel.ValidationMessage = iex.Message;
                return View("~/Views/PVP/Search.cshtml", viewModel);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message + ex.StackTrace);
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        public ActionResult _LeftNavPVP()
        {
            return PartialView();
        }

        public ActionResult Export()
        {
            return RenderExcel("PVPSearchResults");
        }
    }
}