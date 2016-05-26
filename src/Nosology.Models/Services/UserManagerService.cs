using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;

using Escyug.Nosology.Models.Repositories;

namespace Escyug.Nosology.Models.Services
{
    public class UserManagerService : UserManager<User>
    {
        private const int LOGIN_SIZE_THRESHOLD = 20;
        private const int PWD_SIZE_THRESHOLD = 5;

        private readonly IUserRepository _userRepository;

        public UserManagerService(IUserRepository userRepository)
            : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public override async Task<User> FindAsync(string userName, string password)
        {
            if (userName.Length <= LOGIN_SIZE_THRESHOLD && password.Length <= PWD_SIZE_THRESHOLD)
            {
                var user = await _userRepository.FindByCredentialsAsync(userName, password);

                if (user.ExpiredDate < DateTime.Today)
                    throw new ArgumentException(); // Account date expired error

                return user;
            }

            return null;
        }
    }
}
