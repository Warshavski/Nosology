using System.Collections.Generic;

namespace Escyug.Nosology.Models.Repositories
{
    public interface IDocumentsRepository
    {
        /// <summary>
        /// Selects all documents from the storage.
        /// </summary>
        /// <returns>Enumerable collection of the documents(domain model)</returns>
        IEnumerable<Document> GetDocuments();
    }
}
