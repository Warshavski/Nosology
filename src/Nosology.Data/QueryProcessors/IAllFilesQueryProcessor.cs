using System.Collections.Generic;
using System.Threading.Tasks;

using Escyug.Nosology.Data.Entities;

namespace Escyug.Nosology.Data.QueryProcessors
{
    public interface IAllFilesQueryProcessor
    {
        /// <summary>
        /// Selects all files data entities from data storage.
        /// </summary>
        /// <returns>Enumerable collection of files data entities.</returns>
        IEnumerable<File> GetFiles();
    }
}
