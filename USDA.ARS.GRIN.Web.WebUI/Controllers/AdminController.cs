using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Authentication;
using System.Runtime.CompilerServices;
using NLog;
using USDA.ARS.GRIN.Web;
using USDA.ARS.GRIN.Web.Models;
using USDA.ARS.GRIN.Web.WebUI;
using USDA.ARS.GRIN.Web.WebUI.ViewModels;
using USDA.ARS.GRIN.Web.WebUI.ViewModels.CGC;
using USDA.ARS.GRIN.Web.WebUI.ViewModels.Admin;
using USDA.ARS.GRIN.Web.Repository;
using USDA.ARS.GRIN.Web.Service;

namespace USDA.ARS.GRIN.Web.WebUI.Controllers
{
    public class AdminController : BaseController 
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        Repository.CGCRepository _cgcRepository = new Repository.CGCRepository();
        SecurityService _securityService = new SecurityService();

        [GrinGlobalAuthentication]
        public ActionResult Index()
        {
            AdminViewModel viewModel = new AdminViewModel();

            try
            {
                viewModel.CGCDocuments = _cgcRepository.GetDocuments();
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                string errorText = "<label>Controller:</label>" + controllerName;
                errorText = errorText + "<br><label>Action:</label>" + actionName;
                errorText = errorText + "<br><label>Details:</label>" + ex.TargetSite + ex.Message;
                Session["ERROR_TEXT"] = errorText;
                return RedirectToAction("InternalServerError", "Error");
            }
            return View("~/Views/Admin/Index.cshtml", viewModel);
        }
        
        public ActionResult Login()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            return View("~/Views/Admin/Login.cshtml", loginViewModel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel)
        {
            GRINUser grinUser = null;
            ResultContainer resultContainer = new ResultContainer();

            try
            {
                resultContainer = _securityService.Login(viewModel.UserName, viewModel.Password, out grinUser);
                if (resultContainer.ResultCode == LoginResult.SUCCESS.ToString())
                {
                    log.Info("USER LOGGED IN: " + grinUser.UserName);
                    Session["AUTHENTICATED_USER"] = grinUser;
                }
                else
                {
                    throw new AuthenticationException(resultContainer.ResultCode);
                }
            }
            catch (AuthenticationException aex)
            {
                log.Error(aex.Message);
                viewModel.Status = resultContainer.ResultCode;
                viewModel.ErrorMessage = resultContainer.ResultDescription;
                return View("~/Views/Admin/Login.cshtml", viewModel);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message + ", " + ex.StackTrace);
                return RedirectToAction("Login", "Admin", new { loginStatus = LoginStatusEnum.ERROR });
            }
            return RedirectToAction("Index", "Admin", new { loginStatus = LoginResult.SUCCESS.ToString(), Area = "" });
        }

        public ActionResult CGCDocumentEdit(int id = 0)
        {
            DocumentEditViewModel viewModel = new DocumentEditViewModel();
            CropGermplasmCommitteeDocument document = null;

            try
            {
                if (id > 0)
                {
                    document = _cgcRepository.GetDocument(id);
                    viewModel.CommitteeID = document.Committee.ID;
                    viewModel.CommitteeName = document.Committee.Name;
                    viewModel.Title = document.Title;
                    viewModel.CategoryCode = document.CategoryCode;
                    viewModel.CategoryTitle = document.CategoryTitle;
                    viewModel.Year = document.DocumentYear;
                    viewModel.ID = document.ID;
                    viewModel.URL = document.URL;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                string errorText = "<label>Controller:</label>" + controllerName;
                errorText = errorText + "<br><label>Action:</label>" + actionName;
                errorText = errorText + "<br><label>Details:</label>" + ex.TargetSite + ex.Message;
                Session["ERROR_TEXT"] = errorText;
                return RedirectToAction("InternalServerError", "Error");
            }
            return View("~/Views/Admin/CGC/Edit.cshtml", viewModel);
        }
        [HttpPost]
        public ActionResult CGCDocumentEdit(DocumentEditViewModel viewModel)
        {
            string uploadDir = "~/documents/cgc/";
            string path = String.Empty;
            CropGermplasmCommitteeDocument document = new CropGermplasmCommitteeDocument();
            ResultContainer resultContainer = new ResultContainer();

            try
            {
                document.ID = viewModel.ID;
                document.Committee.ID = viewModel.CommitteeID;
                document.Title = viewModel.Title;
                document.DocumentYear = viewModel.Year;
                document.CategoryCode = viewModel.CategoryCode;
                document.URL = viewModel.URL;
                
                if (viewModel.DocumentUpload != null && viewModel.DocumentUpload.ContentLength > 0)
                {
                    if (document.CategoryTitle == "CVS")
                    {
                        uploadDir = uploadDir + "cvs";
                    }
                    else
                    {
                        if (document.CategoryTitle == "MIN")
                        {
                            uploadDir = uploadDir + "committee";
                        }
                    }

                    //NEEDED?
                    //path = Path.Combine(Server.MapPath(uploadDir), Path.GetFileName(viewModel.DocumentUpload.FileName));

                    var documentPath = Path.Combine(Server.MapPath(uploadDir), viewModel.DocumentUpload.FileName);
                    var documentUrl = Path.Combine(uploadDir, viewModel.DocumentUpload.FileName);
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

                if (viewModel.ID > 0)
                {
                    resultContainer = _cgcRepository.UpdateDocument(document);
                }
                else
                {
                    resultContainer = _cgcRepository.InsertDocument(document);
                }

                return RedirectToAction("CGCDocumentView", "Admin", new { id = resultContainer.EntityID });
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                string errorText = "<label>Controller:</label>" + controllerName;
                errorText = errorText + "<br><label>Action:</label>" + actionName;
                errorText = errorText + "<br><label>Details:</label>" + ex.TargetSite + ex.Message;
                Session["ERROR_TEXT"] = errorText;
                return RedirectToAction("InternalServerError", "Error");
            }
        }

        public ActionResult CGCDocumentDelete(int id)
        {
            CropGermplasmCommitteeDocument cropGermplasmCommitteeDocument = null;
            ResultContainer resultContainer = null;
            try
            {
                cropGermplasmCommitteeDocument = _cgcRepository.GetDocument(id);

                //Uri uri = new Uri(cropGermplasmCommitteeDocument.URL);
                //string filename = System.IO.Path.GetFileName(cropGermplasmCommitteeDocument.URL);

                //string rootPath = "~/documents/CGC";
                //string fullPath = System.IO.Path.Combine(Server.MapPath(rootPath), filename);

                //if (System.IO.File.Exists(uri.LocalPath))
                //{
                //    System.IO.File.Delete(uri.LocalPath);
                //}
                //else
                //{
                //    throw new IOException(String.Format("The file {0} does not exist and cannot be deleted.", filename));
                //}
                resultContainer = _cgcRepository.DeleteDocument(cropGermplasmCommitteeDocument);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                string errorText = "<label>Controller:</label>" + controllerName;
                errorText = errorText + "<br><label>Action:</label>" + actionName;
                errorText = errorText + "<br><label>Details:</label>" + ex.TargetSite + ex.Message;
                Session["ERROR_TEXT"] = errorText;
                return RedirectToAction("InternalServerError", "Error");
            }
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult CGCDocumentView(int id)
        {
            DocumentEditViewModel viewModel = new DocumentEditViewModel();
            CropGermplasmCommitteeDocument document = null;

            try
            {
                document = _cgcRepository.GetDocument(id);
                viewModel.ID = document.ID;
                viewModel.Title = document.Title;
                viewModel.URL = document.URL;
                viewModel.CategoryCode = document.CategoryCode;
                viewModel.CategoryTitle = document.CategoryTitle;
                viewModel.Year = document.DocumentYear;
                viewModel.CommitteeID = document.Committee.ID;
                viewModel.CommitteeName = document.Committee.Name;
                viewModel.CreatedDate = document.CreatedDate;
                viewModel.ModifiedDate = document.ModifiedDate;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                string errorText = "<label>Controller:</label>" + controllerName;
                errorText = errorText + "<br><label>Action:</label>" + actionName;
                errorText = errorText + "<br><label>Details:</label>" + ex.TargetSite + ex.Message;
                Session["ERROR_TEXT"] = errorText;
                return RedirectToAction("InternalServerError", "Error");
            }
            return View("~/Views/Admin/CGC/View.cshtml", viewModel);
        }
    }
}