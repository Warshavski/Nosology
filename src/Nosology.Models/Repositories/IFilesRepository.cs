using System.Collections.Generic;

namespace Escyug.Nosology.Models.Repositories
{
    public interface IFilesRepository
    {
        IEnumerable<File> GetFiles();
    }
}
