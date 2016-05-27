
namespace Escyug.Nosology.Models
{
    public sealed class Document : File
    {
        private string _documentDescripiton;
        public string Description { get { return _documentDescripiton; } }

        public Document(int documentId, string documentTitle,
            string documentDescription, string documentType, string documentLink)
            : base(documentId, documentTitle, documentType, documentLink)
        {
            _documentDescripiton = documentDescription;
        }
    }
}
