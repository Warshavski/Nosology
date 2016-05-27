using System.Threading.Tasks;

using Microsoft.AspNet.Identity;

using Escyug.Nosology.Data.Exceptions;
using Escyug.Nosology.Data.QueryProcessors;

namespace Escyug.Nosology.Models.Repositories
{
    public sealed class UserIdentityRepository : IUserRepository
    {
        private readonly IUserByCredentialsQueryProcessor _userByCredentialsProcessor;

        public UserIdentityRepository(IUserByCredentialsQueryProcessor userByCredentialsProcessor)
        {
            _userByCredentialsProcessor = userByCredentialsProcessor;
        }

        #region IUserByCredentialsQueryProcessor

        public async Task<User> FindByCredentialsAsync(string login, string password)
        {
            var userData = await _userByCredentialsProcessor.FindByCredentialsAsync(login, password);

            if (userData != null)
            {
                return ModelBinder.CreateUserModel(userData);
            }
            else
            {
                return null;
                //throw new RootObjectNotFoundException("No such user");
            }
        }

        #endregion

        #region IUserStore<TUser> members where TUser : IUser

        public Task CreateAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> FindByIdAsync(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> FindByNameAsync(string userName)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            
        }

        #endregion
    }
}
