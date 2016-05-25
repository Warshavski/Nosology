using System.Threading.Tasks;

using Escyug.Nosology.Data.Exceptions;
using Escyug.Nosology.Data.QueryProcessors;

namespace Escyug.Nosology.Models.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly IUserByCredentialsQueryProcessor _userProcessor;

        public UserRepository(IUserByCredentialsQueryProcessor userProcessor)
        {
            _userProcessor = userProcessor;
        }

        public async Task<User> SelectUserAsync(string login, string password)
        {
            var userData = await _userProcessor.GetUserAsync(login, password);

            if (userData != null)
            {
                return ModelBinder.CreateUserModel(userData);
            }
            else
            {
                throw new RootObjectNotFoundException("No such user");
            }
        }
    }
}
