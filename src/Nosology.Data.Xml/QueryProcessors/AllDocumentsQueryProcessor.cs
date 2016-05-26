using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

using Escyug.Nosology.Data.Entities;
using Escyug.Nosology.Data.QueryProcessors;
using System;

namespace Escyug.Nosology.Data.Xml.QueryProcessors
{
    public sealed class AllDocumentsQueryProcessor : IAllDocumentsQueryProcessor
    {
        [Serializable()]
        public sealed class DocumentNode
        {
            [System.Xml.Serialization.XmlElement("Id")]
            public int Id { get; set; }

            [System.Xml.Serialization.XmlElement("Title")]
            public string Title { get; set; }

            [System.Xml.Serialization.XmlElement("Description")]
            public string Description { get; set; }

            [System.Xml.Serialization.XmlElement("Link")]
            public string Link { get; set; }

            [System.Xml.Serialization.XmlElement("Type")]
            public string Type { get; set; }
        }

        [Serializable()]
        [System.Xml.Serialization.XmlRoot("DocumentCollection")]
        public sealed class DocumentNodeCollection
        {
            [XmlArray("Documents")]
            [XmlArrayItem("Document", typeof(DocumentNode))]
            public DocumentNode[] DocumentsNodes { get; set; }
        }

        private readonly string _rootFolderPath;

        public AllDocumentsQueryProcessor(string rootFolderPath)
        {
            _rootFolderPath = rootFolderPath;
        }

        public IEnumerable<Document> GetDocuments()
        {
            try
            {
                DocumentNodeCollection documentsNodes = null;
                string path = CreatePath(_rootFolderPath);

                XmlSerializer serializer = new XmlSerializer(typeof(DocumentNodeCollection));

                using (var reader = new StreamReader(path))
                {
                    documentsNodes = (DocumentNodeCollection)serializer.Deserialize(reader);
                }

                var documentsList = new List<Document>();
                foreach (var documentNode in documentsNodes.DocumentsNodes)
                {
                    documentsList.Add(NodeToDocument(documentNode));
                }

                return documentsList;
            }
            catch (XmlException)
            {
                return null;
            }           
        }

        private string CreatePath(string rootFolderPath)
        {
            return string.Format("{0}\\App_Data\\{1}", rootFolderPath, "documents.xml");
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
