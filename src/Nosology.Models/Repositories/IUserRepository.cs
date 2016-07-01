using System.Threading.Tasks;

using Microsoft.AspNet.Identity;


namespace Escyug.Nosology.Models.Repositories
{
    public interface IUserRepository : IUserStore<User>
    {
        /// <summary>
        /// Search user by credential(login, and password).
        /// </summary>
        /// <param name="login">User login.</param>
        /// <param name="password">User password.</param>
        /// <returns>User domain model.</returns>
        Task<User> FindByCredentialsAsync(string login, string password);   
    }
}
