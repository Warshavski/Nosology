using Escyug.Nosology.Data.QueryProcessors;

namespace Escyug.Nosology.Models.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly IUserQueryProcessor _userProcessor;

        public UserRepository(IUserQueryProcessor userProcessor)
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
