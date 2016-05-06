using System.Collections.Generic;

using Escyug.Nosology.ViewModels;
using Escyug.Nosology.Models.Repositories;

using Escyug.Nosology.Presentation.Common;
using Escyug.Nosology.Presentation.Views;

namespace Escyug.Nosology.Presentation.Presenters
{
    public sealed class DocumentsPresenter : IPresenter<IDocumentsView>
    {
        private IDocumentsView _view;
        private readonly IDocumentsRepository _documentRepository;

        [Ninject.Inject]
        public DocumentsPresenter(IDocumentsRepository documentRepository)
        {
            _documentRepository = documentRepository;   
        }

        public DocumentsPresenter(IDocumentsRepository documentRepository, IDocumentsView view)
            : this (documentRepository)
        {
            InjectView(view);
        }

        public void InjectView(IDocumentsView view)
        {
            _view = view;

            _view.PageLoad += () => OnPageLoad();
        }

        private void OnPageLoad()
        {
            var templateFilesList = new List<TemplateFile>();

            var documentsList = _documentRepository.SelectDocuments(DocumentsTypes.orders);
            var templateFileId = 0;
            foreach (var document in documentsList)
            {
                var templateFileTitle = document.Title;
                var templateFileLink = document.Link;
                var templateFileDescription = document.Description;
                var templateFileIcon = "file-pdf-o";

                templateFilesList.Add(
                    new TemplateFile(++templateFileId, templateFileTitle,
                        templateFileLink, templateFileDescription, templateFileIcon));
            }
            
            _view.FilesList = templateFilesList;
        }
   
    }
}
