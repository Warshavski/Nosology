using System.Collections.Generic;

using Escyug.Nosology.Models.Repositories;
using Escyug.Nosology.Presentation.Views;
using Escyug.Nosology.ViewModels;

namespace Escyug.Nosology.Presentation.Presenters
{
    public sealed class DownloadsPresenter
    {
        private readonly IDownloadsView _view;
        private readonly IDocumentsRepository _documentsRepositrory;

        public DownloadsPresenter(IDownloadsView view, IDocumentsRepository documentsRepository)
        {
            _view = view;
            _documentsRepositrory = documentsRepository;

            _view.PageLoad += () => OnPageLoad();
        }

        private void OnPageLoad()
        {
            var templateFilesList = new List<TemplateFile>();

            var documentsList = _documentsRepositrory.SelectDocuments(DocumentsTypes.orders);
            foreach (var document in documentsList)
                templateFilesList.Add(new TemplateFile());

            _view.DocumentsList = templateFilesList;
        }

    }
}
