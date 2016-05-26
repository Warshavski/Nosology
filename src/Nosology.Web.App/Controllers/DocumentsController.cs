using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Escyug.Nosology.Data.Exceptions;
using Escyug.Nosology.Models.Repositories;
using Escyug.Nosology.Web.App.ViewModels;

namespace Escyug.Nosology.Web.App.Controllers
{
    public sealed class DocumentsController : Controller
    {
        private readonly IDocumentsRepository _documentsRepository;

        private readonly Dictionary<string, string> _documentsIcons;
        
        public DocumentsController(IDocumentsRepository documentsRepository)
        {
            _documentsRepository = documentsRepository;

            _documentsIcons = new Dictionary<string, string>()
            {
                {"pdf", "info_outline"}
            };
        }

        // GET: Documents
        public ActionResult Index()
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

        private ViewModels.DocumentViewModel CreateViewModelDocument(Models.Document document)
        {
            var documentViewModel = new ViewModels.DocumentViewModel();

            documentViewModel.Id = document.Id;
            documentViewModel.Title = document.Title;
            documentViewModel.Link = document.Link;
            documentViewModel.Description = document.Description;
            documentViewModel.IconStyle = _documentsIcons[document.Type];

            return documentViewModel;
        }  
    }
}