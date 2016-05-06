using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml;

using Escyug.Nosology.Data.Entities;
using Escyug.Nosology.Data.QueryProcessors;

namespace Escyug.Nosology.Data.Xml.QueryProcessors
{
   /** TODO : 
    *   1. rework class
    * 
    */
   /** XML NODE EXAMPLE
    * 
    *  <title>1</id>
    *  <link>User name #1</name>
    *  <description>4e66dba9-abb1-4740-9187-254afa0c012e</folder>
    *  <fileType>login1</login>
    */
    public sealed class XmlDocumentsQueryProcessor : IDocumentQueryProcessor
    {
        private readonly string _rootPath;

        public XmlDocumentsQueryProcessor(string rootPath)
        {
            _rootPath = rootPath;
        }

        // create path to .xml file
        private string CreateFilePath(string fileName)
        {
            var xmlFilePath = new StringBuilder();
            xmlFilePath.AppendFormat("{0}\\App_Data\\{1}", _rootPath, fileName);

            return xmlFilePath.ToString();
        }

        // load data from .xml file to DataSet
        private DataSet LoadXmlToDataSet(string path)
        {
            DataSet data = null;

            try
            {
                var settings = new XmlReaderSettings();
                settings.IgnoreComments = true;
                settings.IgnoreWhitespace = true;

                data = new DataSet();
                using (var reader = XmlReader.Create(path, settings))
                    data.ReadXml(reader);
            }
            catch (XmlException)
            {
                if (data != null)
                    data.Dispose();
            }

            return data;
        }

        private IEnumerable<Document> Wat(DataSet watDataSet)
        {
            List<Document> documentsList = null;
            
            try
            {
                DataTable filesTable = watDataSet.Tables[0];

                if (watDataSet != null && filesTable.Rows.Count != 0)
                {
                    documentsList = new List<Document>();

                    foreach (DataRow row in filesTable.Rows)
                        documentsList.Add(
                            new Document(row[0].ToString(), row[2].ToString(), row[1].ToString()));
                }

            }
            catch (NullReferenceException)
            {
                throw;
            }
            catch (DataException)
            {
                throw;
            }

            return documentsList;
        }

        public IEnumerable<Document> SelectDocuments(DocumentsTypes docType)
        {
            var fileName = string.Empty;

            switch (docType)
            {
                case DocumentsTypes.files:
                    fileName = "files.xml";
                    break;
                case DocumentsTypes.orders :
                    fileName = "orders.xml";
                    break;
            }

            var path = CreateFilePath(fileName);

            var documentsData = LoadXmlToDataSet(path);
            var documentsList = Wat(documentsData);

            return documentsList;
        }
    }
}
