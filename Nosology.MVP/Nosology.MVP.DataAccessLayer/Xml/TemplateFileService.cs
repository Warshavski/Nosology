using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Xml;

namespace Escyug.Nosology.MVP.DataAccessLayer.Xml
{
    /** TODO :
     *    1. Exception handling
     */

    public sealed class TemplateFileService
    {
        private string _rootPath;

        public TemplateFileService()
        {
            // should be in config file
            _rootPath = AppDomain.CurrentDomain.BaseDirectory;
            //@"C:\test"; 
            //@"C:\Users\Администратор\Documents\GitHub\nosology\Nosology.MVP\Nosology.MVP.UI.WebApp";
            
        }

        
        // create path to .xml file
        private string CreateFilePath(string folderName, string fileName)
        {
            var xmlFilePath = new StringBuilder();
            xmlFilePath.AppendFormat("{0}\\App_Data\\{1}\\{2}", _rootPath, folderName, fileName);

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


        /** XML NODE EXAMPLE
         * 
         *  <title>1</id>
         *  <link>User name #1</name>
         *  <description>4e66dba9-abb1-4740-9187-254afa0c012e</folder>
         *  <fileType>login1</login>
         */

        public DataSet GetDocumentsData()
        {
            string directoryName = "docs";//"App_Data";
            string fileName = "documents.xml";

            string filePath = CreateFilePath(directoryName, fileName);

            return LoadXmlToDataSet(filePath);
        }

        public DataSet GetFilesData()
        {
            string directoryName = "files";
            string fileName = "files.xml";

            string filePath = CreateFilePath(directoryName, fileName);

            return LoadXmlToDataSet(filePath);
        }

    }
}
