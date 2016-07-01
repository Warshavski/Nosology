using System.Threading.Tasks;

namespace Escyug.Nosology.Models.Repositories
{
    public interface IMainTextBlockRepository
    {
        /// <summary>
        /// Loads main text block.
        /// </summary>
        /// <returns>Main text block(nosology description).</returns>
        Task<string> GetAboutInfoAsync();
    }
}
