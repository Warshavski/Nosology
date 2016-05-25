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
    public class DocumentsController : Controller
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
            var documents = _documentsRepository.GetDocuments();
            var documentsVM = new List<ViewModels.Document>();
            foreach (var document in documents)
            {
                var documentVM = new Document();
                documentVM.Id = document.Id;
                documentVM.Title = document.Title;
                documentVM.Link = document.Link;
                documentVM.Description = document.Description;
                documentVM.IconStyle = _documentsIcons[document.Type];

                documentsVM.Add(documentVM);
            }

            return View(documentsVM);
        }
    }
}