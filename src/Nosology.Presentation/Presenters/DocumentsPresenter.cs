using System.Collections.Generic;

using Escyug.Nosology.Models.Repositories;
using Escyug.Nosology.Presentation.Views;
using Escyug.Nosology.ViewModels;

namespace Escyug.Nosology.Presentation.Presenters
{
    public sealed class DocumentsPresenter
    {
        private readonly IDocumentsView _view;
        private readonly IDocumentsRepository _documentRepository;

        public DocumentsPresenter(IDocumentsView view, IDocumentsRepository documentRepository)
        {
            _view = view;
            _documentRepository = documentRepository;

            _view.PageLoad += () => OnPageLoad();
        }

        private void OnPageLoad()
        {
            var templateFilesList = new List<TemplateFile>();

            var documentsList = _documentRepository.SelectDocuments(DocumentsTypes.orders);
            foreach (var document in documentsList)
                templateFilesList.Add(new TemplateFile());

            _view.FilesList = templateFilesList;
        }
    }
}
