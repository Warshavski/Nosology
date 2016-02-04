using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Escyug.Nosology.MVP.DataAccessLayer.Xml
{
    public sealed class TemplateFileService
    {
        private string _path;

        public TemplateFileService()
        {
            _path = @"C:\Users\Администратор\Documents\GitHub\nosology\Nosology.MVP\Nosology.MVP.UI.WebApp\";
        }

        /** XML NODE EXAMPLE
         * 
         *  <title>1</id>
         *  <link>User name #1</name>
         *  <description>4e66dba9-abb1-4740-9187-254afa0c012e</folder>
         *  <fileType>login1</login>
         */

        public DataTable GetDocumentsData()
        {
            string directoryName = "App_Data";

            var xmlFilePath = new StringBuilder();
            xmlFilePath.AppendFormat("{0}\\{1}\\{2}", _path, directoryName, "documents.xml");

            DataTable documentsData = null;

            try
            {
                var settings = new XmlReaderSettings();

                documentsData = new DataTable();
                using (var reader = XmlReader.Create(xmlFilePath.ToString(), settings))
                {
                    documentsData.ReadXmlSchema(reader);
                    //Keep reading until there are no more "XmlUser" elements
                    while (reader.ReadToFollowing("XmlFile"))
                    {
                        string title        = reader.GetAttribute("title");
                        string link         = reader.GetAttribute("link");
                        string description  = reader.GetAttribute("description");
                        string fileType     = reader.GetAttribute("fileType");

                        documentsData.LoadDataRow(new object[] { title, link, description, fileType }, true);   
                    }
                }
            }
            catch (XmlException)
            {
                if (documentsData != null)
                    documentsData = null;
            }

            return documentsData;
        }

    }
}
