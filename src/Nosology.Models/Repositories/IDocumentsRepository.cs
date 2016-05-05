using System.Collections.Generic;

namespace Escyug.Nosology.Models.Repositories
{
    public interface IDocumentsRepository
    {
        IEnumerable<Models.Document> SelectDocuments(DocumentsTypes docType);
    }
}
