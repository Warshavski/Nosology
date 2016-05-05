
namespace Escyug.Nosology.Models
{
    public sealed class Document
    {
        private string _documentTitle;
        public string Title
        {
            get { return _documentTitle; }
        }

        private string _documentDescription;
        public string Description
        {
            get { return _documentDescription; }
        }

        private string _documentLink; // download path 
        public string Link
        {
            get { return _documentLink; }
        }

        public Document(string documentTitle, string documentDescription, string documentLink)
        {
            _documentTitle = documentTitle;
            _documentDescription = documentDescription;
            _documentLink = documentLink;
        }
    }
}
