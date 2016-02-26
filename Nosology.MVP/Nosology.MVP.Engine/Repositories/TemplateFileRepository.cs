using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
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
            DataSet filesData = null;

            try
            {
                var fileService = new TemplateFileService();
                filesData = fileService.GetDocumentsData();

                DataTable filesTable = filesData.Tables[0];

                if (filesData != null && filesTable.Rows.Count != 0)
                {
                    documentsList = new List<TemplateFile>();

                    int id = 0;
                    foreach (DataRow row in filesTable.Rows)
                        documentsList.Add(
                            new TemplateFile(++id, row[0].ToString(), row[1].ToString(), row[2].ToString(), FileType.pdf));
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
            List<TemplateFile> filesList = null;
            DataSet filesData = null;

            try
            {
                var fileService = new TemplateFileService();
                filesData = fileService.GetFilesData();
                DataTable filesTable = filesData.Tables[0];

                if (filesData != null && filesTable.Rows.Count != 0)
                {
                    filesList = new List<TemplateFile>();

                    foreach (DataRow row in filesTable.Rows)
                        filesList.Add(
                            new TemplateFile(row[0].ToString(), row[1].ToString(), string.Empty, FileType.defaultFile));
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
            finally
            {
                if (filesData != null)
                    filesData.Dispose();
            }

            return filesList;
        }
    }
}
