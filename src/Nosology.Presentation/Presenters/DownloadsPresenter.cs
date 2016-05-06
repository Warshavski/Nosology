using System.Collections.Generic;

using Escyug.Nosology.Models.Repositories;
using Escyug.Nosology.ViewModels;

using Escyug.Nosology.Presentation.Common;
using Escyug.Nosology.Presentation.Views;

namespace Escyug.Nosology.Presentation.Presenters
{
    public sealed class DownloadsPresenter : IPresenter<IDownloadsView>
    {
        private IDownloadsView _view;
        private readonly IDocumentsRepository _documentsRepositrory;

        [Ninject.Inject]
        public DownloadsPresenter(IDocumentsRepository documentsRepository)
        {
            _documentsRepositrory = documentsRepository;
        }

        public DownloadsPresenter(IDocumentsRepository documentsRepository, IDownloadsView view)
            : this(documentsRepository)
        {
            InjectView(view); 
        }

        public void InjectView(IDownloadsView view)
        {
            _view = view;

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
