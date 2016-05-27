using System.Collections.Generic;

using Escyug.Nosology.Data.Exceptions;
using Escyug.Nosology.Data.QueryProcessors;

namespace Escyug.Nosology.Models.Repositories
{
    public class DocumentsRepository : IDocumentsRepository
    {
        private readonly IAllDocumentsQueryProcessor _queryProcessor;

        public DocumentsRepository(IAllDocumentsQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        public IEnumerable<Document> GetDocuments()
        {
            var documentsEntities = _queryProcessor.GetDocuments();

            if (documentsEntities != null)
            {
                var documentsList = new List<Document>();
                foreach (var entity in documentsEntities)
                    documentsList.Add(ModelBinder.CreateDocumentModel(entity));

                return documentsList;
            }
            else
            {
                throw new RootObjectNotFoundException("Documents not found");
            }   
        }
    }
}
