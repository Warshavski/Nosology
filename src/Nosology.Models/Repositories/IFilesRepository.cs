using System.Collections.Generic;

namespace Escyug.Nosology.Models.Repositories
{
    public interface IFilesRepository
    {
        /// <summary>
        /// Selects all files from the storage.
        /// </summary>
        /// <returns>Enumerable collection of the files(domain model)</returns>
        IEnumerable<File> GetFiles();
    }
}
