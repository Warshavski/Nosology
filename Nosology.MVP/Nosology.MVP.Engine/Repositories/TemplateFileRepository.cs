using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escyug.Nosology.MVP.DataAccessLayer.Xml;
using System.Data;

namespace Escyug.Nosology.MVP.Engine.Repositories
{
    internal sealed class TemplateFileRepository
    {
        public TemplateFileRepository()
        {

        }

        public List<TemplateFile> SelectDocuments()
        {
            List<TemplateFile> documentsList = null;
            DataTable filesData = null;
            
            try
            {
                var fileService = new TemplateFileService();
                filesData = fileService.GetDocumentsData();

                if (filesData != null && filesData.Rows.Count != 0)
                {
                    documentsList = new List<TemplateFile>();

                    foreach (DataRow row in filesData.Rows)
                        documentsList.Add(new TemplateFile());
                }

            }
            catch (NullReferenceException)
            {
                throw;
            }
            finally
            {
                if (filesData != null)
                    filesData.Dispose();
            }
            
            return documentsList;
        }


        // #TEST (rewrite method)
        public List<TemplateFile> SelectFiles()
        {
            List<TemplateFile> documentsList = null;
            DataTable filesData = null;

            try
            {
                var fileService = new TemplateFileService();
                filesData = fileService.GetDocumentsData();

                if (filesData != null && filesData.Rows.Count != 0)
                {
                    documentsList = new List<TemplateFile>();

                    foreach (DataRow row in filesData.Rows)
                        documentsList.Add(new TemplateFile());
                }

            }
            catch (NullReferenceException)
            {
                throw;
            }
            finally
            {
                if (filesData != null)
                    filesData.Dispose();
            }

            return documentsList;
        }
    }
}
