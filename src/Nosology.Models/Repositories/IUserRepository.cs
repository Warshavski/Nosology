using System.Threading.Tasks;

using Microsoft.AspNet.Identity;


namespace Escyug.Nosology.Models.Repositories
{
    public interface IUserRepository : IUserStore<User>
    {
        Task<User> FindByCredentialsAsync(string login, string password);   
    }
}
