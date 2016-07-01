
namespace Escyug.Nosology.Models
{
    public sealed class Document : File
    {
        public string Description { get; private set; }

        public Document(int documentId, string documentTitle,
            string documentDescription, string documentType, string documentLink)
            : base(documentId, documentTitle, documentType, documentLink)
        {
            Description = documentDescription;
        }
    }
}
