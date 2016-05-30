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
        private readonly IFilesRepository _filesRepository;

        [Ninject.Inject]
        public DownloadsPresenter(IFilesRepository filesRepository)
        {
            _filesRepository = filesRepository;
        }

        public DownloadsPresenter(IFilesRepository filesRepository, IDownloadsView view)
            : this(filesRepository)
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
            var files = _filesRepository.GetFiles();
            var filesVM = new List<FileViewModel>();
            foreach (var file in files)
                filesVM.Add(CreateViewModelFile(file));

            _view.FilesList = filesVM;
        }

        /* Old version OnPageLoad()
        private void OnPageLoad()
        {
            var templateFilesList = new List<TemplateFile>();

            var documentsList = _documentsRepositrory.SelectDocuments(DocumentsTypes.files);
            var templateFileId = 0;
            foreach (var document in documentsList)
            {
                var templateFileTitle = document.Title;
                var templateFileLink = document.Link;
                var templateFileDescription = document.Description;
                var templateFileIcon = "insert_drive_file";

                templateFilesList.Add(
                    new TemplateFile(++templateFileId, templateFileTitle, 
                        templateFileLink, templateFileDescription, templateFileIcon));
            }
            
            _view.DocumentsList = templateFilesList;
        }
        */

        // repeatable method (see : Nosology.Web.App.Controllers DownloadsController.cs)
        private FileViewModel CreateViewModelFile(Models.File file)
        {
            var fileViewModel = new ViewModels.FileViewModel();

            fileViewModel.Id = file.Id;
            fileViewModel.Title = file.Title;
            fileViewModel.Link = file.Link;

            fileViewModel.IconStyle = IconsList.GetIconTypeName(file.Type);

            return fileViewModel;
        }  
    }
}
