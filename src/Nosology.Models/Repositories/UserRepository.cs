using Escyug.Nosology.Data.Processors;

namespace Escyug.Nosology.Models.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly IUserProcessor _userProcessor;

        public UserRepository(IUserProcessor userProcessor)
        {
            _userProcessor = userProcessor;
        }

        public User SelectUser(string login, string password)
        {
            var userData = _userProcessor.SelectUser(login, password);

            if (userData == null)
                return null;

            return ModelBinder.CreateUserModel(userData);
        }
    }
}
