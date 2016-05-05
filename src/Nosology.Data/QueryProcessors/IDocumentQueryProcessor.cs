using System.Collections.Generic;

namespace Escyug.Nosology.Data.QueryProcessors
{
    public interface IDocumentQueryProcessor
    {
        IEnumerable<Data.Entities.Document> SelectDocuments(DocumentsTypes docType);
    }
}
