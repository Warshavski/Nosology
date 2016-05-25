using System.Threading.Tasks;

using Escyug.Nosology.Data.Entities;

namespace Escyug.Nosology.Data.QueryProcessors
{
    public interface IUserByCredentialsQueryProcessor
    {
        Task<User> GetUserAsync(string login, string password);
    }
}
