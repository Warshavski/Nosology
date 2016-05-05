using System.Collections.Generic;

namespace Escyug.Nosology.Models.Services
{
    public interface IDocumentsService
    {
        IEnumerable<Models.Document> GetDocuments(DocumentsTypes docType);
    }
}
