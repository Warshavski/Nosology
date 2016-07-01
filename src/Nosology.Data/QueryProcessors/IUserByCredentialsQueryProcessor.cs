using System.Threading.Tasks;

using Escyug.Nosology.Data.Entities;

namespace Escyug.Nosology.Data.QueryProcessors
{
    public interface IUserByCredentialsQueryProcessor
    {
        /// <summary>
        /// Selects user data entity by login and password from data storage.
        /// </summary>
        /// <param name="login">User login</param>
        /// <param name="password">User password</param>
        /// <returns>User data entity.</returns>
        Task<User> FindByCredentialsAsync(string login, string password);
    }
}
