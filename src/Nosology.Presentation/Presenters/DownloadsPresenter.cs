using System.Collections.Generic;

using Escyug.Nosology.Models.Services;
using Escyug.Nosology.Presentation.Views;
using Escyug.Nosology.ViewModels;

namespace Escyug.Nosology.Presentation.Presenters
{
    public sealed class DownloadsPresenter
    {
        private readonly IDownloadsView _view;
        private readonly IDocumentsService _documentsService;

        public DownloadsPresenter(IDownloadsView view, IDocumentsService documentsService)
        {
            _view = view;
            _documentsService = documentsService;

            _view.PageLoad += () => OnPageLoad();
        }

        private void OnPageLoad()
        {
            var templateFilesList = new List<TemplateFile>();

            var documentsList = _documentsService.GetDocuments(DocumentsTypes.orders);
            foreach (var document in documentsList)
                templateFilesList.Add(new TemplateFile());

            _view.DocumentsList = templateFilesList;
        }

    }
}
