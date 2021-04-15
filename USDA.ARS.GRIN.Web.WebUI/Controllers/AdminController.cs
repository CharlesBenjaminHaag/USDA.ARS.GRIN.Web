using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Authentication;
using System.Runtime.CompilerServices;
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
                log.Error(ex.Message + ex.StackTrace);
                return View("~/Views/Shared/Error.cshtml");
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
                    viewModel.ID = document.ID;
                    viewModel.CategoryCode = document.Category;
                    viewModel.Title = document.Title;
                    viewModel.URL = document.URL;
                    viewModel.CommitteeID = document.Committee.ID;
                    viewModel.CommitteeName = document.Committee.Name;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message + ex.StackTrace);
                return View("~/Views/Shared/Error.cshtml");
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
                document.Title = viewModel.Title;
                document.URL = viewModel.URL;
                document.Category = viewModel.CategoryCode;
                document.Year = viewModel.Year;
                document.Committee.ID = viewModel.CommitteeID;
                
                if (viewModel.DocumentUpload != null && viewModel.DocumentUpload.ContentLength > 0)
                {
                    if (document.Category == "CVS")
                    {
                        uploadDir = uploadDir + "cvs";
                    }
                    else
                    {
                        if (document.Category == "MIN")
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
                log.Error(ex.Message + ex.StackTrace);
                return View("~/Views/Shared/Error.cshtml");
            }
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
                viewModel.CategoryCode = document.Category;
                viewModel.Year = document.Year;
                viewModel.CommitteeID = document.Committee.ID;
                viewModel.CommitteeName = document.Committee.Name;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message + ex.StackTrace);
                return View("~/Views/Shared/Error.cshtml");
            }
            return View("~/Views/Admin/CGC/View.cshtml", viewModel);
        }
    }
}