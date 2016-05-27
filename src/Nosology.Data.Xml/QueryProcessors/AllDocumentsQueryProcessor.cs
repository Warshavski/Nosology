using System.Collections.Generic;

using Escyug.Nosology.Data.Entities;
using Escyug.Nosology.Data.QueryProcessors;

using Escyug.Nosology.Data.Xml.SerializbleEntities;

namespace Escyug.Nosology.Data.Xml.QueryProcessors
{
    public sealed class AllDocumentsQueryProcessor : IAllDocumentsQueryProcessor
    {
        private const string FILE_NAME = "documents.xml";

        private readonly string _rootFolderPath;

        public AllDocumentsQueryProcessor(string rootFolderPath)
        {
            _rootFolderPath = rootFolderPath;
        }

        public IEnumerable<Document> GetDocuments()
        {
            var documentsNodes = EntityDeSerializer
                .GetDeSerializedEntity<DocumentNodesCollection>(_rootFolderPath, FILE_NAME);

            if (documentsNodes != null)
            {
                var documentsList = new List<Document>();
                foreach (var documentNode in documentsNodes.DocumentsNodes)
                {
                    documentsList.Add(NodeToDocument(documentNode));
                }

                return documentsList;
            }
            else
            {
                return null;
            }
        }

        private Document NodeToDocument(DocumentNode documentNode)
        {
            var document = new Document();
            document.Id = documentNode.Id;
            document.Description = documentNode.Description;
            document.Link = documentNode.Link;
            document.Title = documentNode.Title;
            document.Type = documentNode.Type;

            return document;
        }
    }
}
