using System.Threading.Tasks;

namespace Escyug.Nosology.Models.Repositories
{
    public interface IMainTextBlockRepository
    {
        Task<string> GetAboutInfoAsync();
    }
}
