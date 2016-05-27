using System.Collections.Generic;

using Escyug.Nosology.Data.Exceptions;
using Escyug.Nosology.Data.QueryProcessors;


namespace Escyug.Nosology.Models.Repositories
{
    public sealed class FilesRepository : IFilesRepository
    {
        private readonly IAllFilesQueryProcessor _allFilesQueryProcessor;

        public FilesRepository(IAllFilesQueryProcessor allFilesQueryProcessor)
        {
            _allFilesQueryProcessor = allFilesQueryProcessor;
        }

        public IEnumerable<File> GetFiles()
        {
            var filesEntities = _allFilesQueryProcessor.GetFiles();

            if (filesEntities != null)
            {
                var filesList = new List<File>();
                foreach (var entity in filesEntities)
                    filesList.Add(ModelBinder.CreateFileModel(entity));

                return filesList;
            }
            else
            {
                throw new RootObjectNotFoundException("Files not found.");
            }
        }
    }
}
