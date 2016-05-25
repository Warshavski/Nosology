using System.Collections.Generic;

namespace Escyug.Nosology.Models.Repositories
{
    public interface IDocumentsRepository
    {
        IEnumerable<Document> GetDocuments();
    }
}
