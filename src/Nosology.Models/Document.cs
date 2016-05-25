
namespace Escyug.Nosology.Models
{
    public sealed class Document
    {
        private int _documentId;
        public int Id { get { return _documentId; } }

        private string _documentTitle;
        public string Title { get { return _documentTitle; } }

        private string _documentDescripiton;
        public string Description { get { return _documentDescripiton; } }

        private string _documentType;
        public string Type { get { return _documentType; } }

        private string _documentLink;
        public string Link { get { return _documentLink; } }

        public Document(int documentId, string documentTitle,
            string documentDescription, string documentType, string documentLink)
        {
            _documentId = documentId;
            _documentTitle = documentTitle;
            _documentDescripiton = documentDescription;
            _documentType = documentType;
            _documentLink = documentLink;
        }
    }
}
