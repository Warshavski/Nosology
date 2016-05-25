using System.Threading.Tasks;

using Escyug.Nosology.Models;

namespace Escyug.Nosology.Models.Services
{
    public interface ILoginService
    {
        Task<User> LoginAsync(string login, string password);
    }
}
