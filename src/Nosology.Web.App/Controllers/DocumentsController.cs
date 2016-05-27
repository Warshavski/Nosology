using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Escyug.Nosology.Data.Exceptions;

using Escyug.Nosology.Models;
using Escyug.Nosology.Models.Repositories;

using Escyug.Nosology.Web.App.ViewModels;
using System.IO;


namespace Escyug.Nosology.Web.App.Controllers
{
    [Authorize]
    public sealed class DocumentsController : Controller
    {
        private readonly IDocumentsRepository _documentsRepository;

        public DocumentsController(IDocumentsRepository documentsRepository)
        {
            _documentsRepository = documentsRepository;
        }

        // GET: Documents
        public ActionResult Index()
        {
            var user = Session["user"] as User;
            if (user != null)
            {
                ViewBag.Title = "Документы";

                var documents = _documentsRepository.GetDocuments();
                var documentsVM = new List<ViewModels.DocumentViewModel>();
                foreach (var document in documents)
                    documentsVM.Add(CreateViewModelDocument(document));

                if (Request.IsAjaxRequest())
                {
                    return PartialView("IndexPartial", documentsVM);
                }
                else
                {
                    return View(documentsVM);
                }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }

        [Authorize]
        public ActionResult OpenDocument(string documentLink)
        {
            try
            {
                string rootFolderPath = AppDomain.CurrentDomain.BaseDirectory;

                string path = Path.Combine(rootFolderPath + "\\App_Data\\docs", documentLink);

                return File(path, "application/pdf");
            }
            catch (FileNotFoundException)
            {
                return View("Error", new { Title = "File not found." });
            }
            
        }

        private ViewModels.DocumentViewModel CreateViewModelDocument(Models.Document document)
        {
            var documentViewModel = new ViewModels.DocumentViewModel();

            documentViewModel.Id = document.Id;
            documentViewModel.Title = document.Title;
            documentViewModel.Link = document.Link;
            documentViewModel.Description = document.Description;
            documentViewModel.IconStyle = IconsList.GetIconTypeName(document.Type);

            return documentViewModel;
        }  
    }
}