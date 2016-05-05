using System.Collections.Generic;

using Escyug.Nosology.Models.Repositories;

namespace Escyug.Nosology.Models.Services
{
    public sealed class SimpleDocumentsService : IDocumentsService
    {
        private readonly IDocumentsRepository _documentsRepositorty;

        public SimpleDocumentsService(IDocumentsRepository documentRepository)
        {
            _documentsRepositorty = documentRepository;
        }

        public IEnumerable<Document> GetDocuments(DocumentsTypes docType)
        {
            return _documentsRepositorty.SelectDocuments(docType);
        }
    }
}
