using System.Collections.Generic;

using Escyug.Nosology.Data.QueryProcessors;

using Escyug.Nosology.Data.Xml.SerializbleEntities;

namespace Escyug.Nosology.Data.Xml.QueryProcessors
{
    public sealed class AllFilesQueryProcessor : IAllFilesQueryProcessor
    {
        private const string FILE_NAME = "files.xml";

        private readonly string _rootFolderPath;

        public AllFilesQueryProcessor(string rootFolderPath)
        {
            _rootFolderPath = rootFolderPath;
        }

        public IEnumerable<Data.Entities.File> GetFiles()
        {
            var filesNodes = EntityDeSerializer
                .GetDeSerializedEntity<FilesNodesCollection>(_rootFolderPath, FILE_NAME);

            if (filesNodes != null)
            {
                var filesList = new List<Data.Entities.File>();
                foreach (var fileNode in filesNodes.FilesNodes)
                {
                    filesList.Add(NodeToFile(fileNode));
                }

                return filesList;
            }
            else
            {
                return null;
            }
        }

        private string CreatePath(string rootFolderPath)
        {
            return string.Format("{0}\\App_Data\\{1}", rootFolderPath, "documents.xml");
        }

        private Data.Entities.File NodeToFile(FileNode documentNode)
        {
            var document = new Data.Entities.File();
            document.Id = documentNode.Id;
            document.Link = documentNode.Link;
            document.Title = documentNode.Title;
            document.Type = documentNode.Type;

            return document;
        }
    }
}
