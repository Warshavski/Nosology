
namespace Escyug.Nosology.ViewModels
{
    public sealed class TemplateFile
    {
        private int _fileId;
        public int Id { get { return _fileId; } }

        private string _fileTitle;
        public string Title 
        { 
            get { return _fileTitle; } 
        }

        private string _fileLink;
        public string Link 
        { 
            get { return _fileLink; } 
        }

        private string _fileDescription;
        public string Description 
        { 
            get { return _fileDescription; } 
        }

        private string _fileIcon;
        public string Icon 
        { 
            get { return _fileIcon; } 
        }

        public TemplateFile()
        {
            _fileId = -1;
            _fileTitle = "TEMPLATE_TITLE";
            _fileDescription = "TEMPLATE_TITLE";
            _fileLink = "TEMPLATE_TITLE";
            _fileIcon = "fa fa-file";
        }

        public TemplateFile(int fileId, string fileTitle, string fileLink, 
            string fileDescription, string fileIcon)
        {
            _fileId = fileId;
            _fileTitle = fileTitle;
            _fileLink = fileLink;
            _fileDescription = fileDescription;
            _fileIcon = fileIcon;
        }
    }
}
