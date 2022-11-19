using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Configuration;
using USDA.ARS.GRIN.Web.DataLayer;
using USDA.ARS.GRIN.Web.ViewModelLayer;
using USDA.ARS.GRIN.Web.WebUI;
using NLog;

namespace USDA.ARS.GRIN.Web.UI.v2.Controllers
{
    [GrinGlobalAuthentication]
    public class AdminController : BaseController
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult _CropGermplasmCommitteeList()
        {
            return PartialView("~/Views/Admin/CropGermplasmCommittee/_List.cshtml");
        }

        public PartialViewResult _CropGermplasmCommitteeDocumentList()
        {
            CropGermplasmCommitteeDocumentViewModel viewModel = new CropGermplasmCommitteeDocumentViewModel();
            viewModel.Search();
            return PartialView("~/Views/Admin/CropGermplasmCommitteeDocument/_List.cshtml", viewModel);
        }
        public ActionResult CropGermplasmCommitteeDocumentAdd()
        {
            try
            {
                CropGermplasmCommitteeDocumentViewModel viewModel = new CropGermplasmCommitteeDocumentViewModel();
                viewModel.TableName = "crop_germplasm_committee_document";
                viewModel.PageTitle = String.Format("Add CGC Document");
                viewModel.AuthenticatedUserCooperatorID = AuthenticatedUser.CooperatorID;
                viewModel.AuthenticatedUser = AuthenticatedUser;
                return View("~/Views/Admin/CropGermplasmCommitteeDocument/Edit.cshtml", viewModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }
        }


        public ActionResult CropGermplasmCommitteeDocumentEdit(int entityId)
        {
            try
            {
                CropGermplasmCommitteeDocumentViewModel viewModel = new CropGermplasmCommitteeDocumentViewModel();
                viewModel.TableName = "crop_germplasm_committee_document";
                viewModel.PageTitle = String.Format("Edit CGC Document [{0}]", entityId);
                viewModel.AuthenticatedUserCooperatorID = AuthenticatedUser.CooperatorID;
                viewModel.AuthenticatedUser = AuthenticatedUser;
                viewModel.Get(entityId);
                return View("~/Views/Admin/CropGermplasmCommitteeDocument/Edit.cshtml", viewModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }
        }

        [HttpPost]
        public ActionResult CropGermplasmCommitteeDocumentEdit(CropGermplasmCommitteeDocumentViewModel viewModel)
        {
            string documentUploadPath = String.Empty;
            string documentUploadPathCommittee = String.Empty;
            string documentUploadPathCVS = String.Empty;
            string path = String.Empty;
            CropGermplasmCommitteeDocument document = new CropGermplasmCommitteeDocument();

            try
            {
                documentUploadPathCommittee = ConfigurationManager.AppSettings["DocumentUploadPathCommittee"];
                documentUploadPathCVS = ConfigurationManager.AppSettings["DocumentUploadPathCommitteeCVS"];
                document.ID = viewModel.Entity.ID;
                document.CropGermplasmCommitteeID = viewModel.Entity.CropGermplasmCommitteeID;
                document.Title = viewModel.Entity.Title;
                document.Year = viewModel.Entity.Year;
                document.CategoryCode = viewModel.Entity.CategoryCode;
                document.URL = viewModel.Entity.URL;

                if (viewModel.EventAction == "DELETE")
                {
                    viewModel.Delete();
                    return RedirectToAction("Index", "Admin");
                }
                else
                { 
                    if (viewModel.DocumentUpload != null && viewModel.DocumentUpload.ContentLength > 0)
                    {
                        if (document.CategoryCode == "CVS")
                        {
                            documentUploadPath = documentUploadPathCVS;
                        }
                        else
                        {
                            if (document.CategoryCode == "MIN")
                            {
                                documentUploadPath = documentUploadPathCommittee;
                            }
                        }

                        if (String.IsNullOrEmpty(documentUploadPath))
                        {
                            throw new Exception("Document upload path is null. Verify that all settings are correct in web.config.");
                        }

                        var documentPath = Path.Combine(Server.MapPath(documentUploadPath), viewModel.DocumentUpload.FileName);
                        var documentUrl = Path.Combine(documentUploadPath, viewModel.DocumentUpload.FileName);
                        viewModel.DocumentUpload.SaveAs(documentPath);

                        var urlBuilder =
                            new System.UriBuilder(Request.Url.AbsoluteUri)
                            {
                                Path = Url.Content(documentUrl),
                                Query = null,
                            };

                        Uri uri = urlBuilder.Uri;
                        document.URL = urlBuilder.ToString();
                    }

                    viewModel.Entity = document;

                    if (viewModel.Entity.ID == 0)
                    {
                        viewModel.Entity.CreatedByCooperatorID = AuthenticatedUser.CooperatorID;
                        viewModel.Insert();
                    }
                    else
                    {
                        viewModel.Entity.ModifiedByCooperatorID = AuthenticatedUser.CooperatorID;
                        viewModel.Update();
                    }
                    return RedirectToAction("CropGermplasmCommitteeDocumentEdit", "Admin", new { entityId = viewModel.Entity.ID });
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }
        }

        [HttpPost]
        public ActionResult CropGermplasmCommitteeDocumentDelete(CropGermplasmCommitteeDocumentViewModel viewModel)
        {
            const string DEBUG_URL = "https://www.ars-grin.gov/npgs";
     
            try
            {
                //var DEBUG = GetBaseUrl();
                //var path = Server.MapPath(viewModel.Entity.URL.Replace(DEBUG_URL, "~/"));

                //FileInfo file = new FileInfo(path);
                //if (!file.Exists)  
                //{
                //    throw new Exception("File " + path + " not found.");
                //}
                //file.Delete();
                viewModel.Delete();
                return RedirectToAction("Index", "Admin");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }
        }
    }
}