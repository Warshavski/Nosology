using System.Collections.Generic;

using Escyug.Nosology.Data.Entities;

namespace Escyug.Nosology.Data.QueryProcessors
{
    public interface IAllDocumentsQueryProcessor
    {
        /// <summary>
        /// Selects all documents data entities from data storage.
        /// </summary>
        /// <returns>Enumerable collection of documents data entities.</returns>
        IEnumerable<Document> GetDocuments();
    }
}
