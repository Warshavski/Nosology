using System.Collections.Generic;

using Escyug.Nosology.Data.QueryProcessors;

namespace Escyug.Nosology.Models.Repositories
{
    public sealed class DocumentsRepository : IDocumentsRepository
    {
        private readonly IDocumentQueryProcessor _documentsQueryProcessor;

        public DocumentsRepository(IDocumentQueryProcessor documentsQueryProcessor)
        {
            _documentsQueryProcessor = documentsQueryProcessor;
        }

        public IEnumerable<Document> SelectDocuments(DocumentsTypes docType)
        {
            var documentsDataList = _documentsQueryProcessor.SelectDocuments(docType);

            var documentsList = new List<Models.Document>();

            foreach (var documentData in documentsDataList)
                documentsList.Add(ModelBinder.CreateDocumentModel(documentData));

            return documentsList;
        }
    }
}
