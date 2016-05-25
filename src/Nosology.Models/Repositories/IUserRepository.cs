using System.Threading.Tasks;

using Escyug.Nosology.Models;

namespace Escyug.Nosology.Models.Repositories
{
    public interface IUserRepository
    {
        Task<User> SelectUserAsync(string login, string password);
    }
}
