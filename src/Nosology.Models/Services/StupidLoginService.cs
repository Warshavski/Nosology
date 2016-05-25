using System;
using System.Threading.Tasks;

using Escyug.Nosology.Models.Repositories;

namespace Escyug.Nosology.Models.Services
{
    public sealed class StupidLoginService : ILoginService
    {
        private const int LOGIN_SIZE_THRESHOLD = 20;
        private const int PWD_SIZE_THRESHOLD = 5;

        private readonly IUserRepository _userRepository;

        public StupidLoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> LoginAsync(string mcod, string password)
        {
            if (mcod.Length <= LOGIN_SIZE_THRESHOLD && password.Length <= PWD_SIZE_THRESHOLD)
            {
                var user = await _userRepository.SelectUserAsync(mcod, password);

                if (user.ExpiredDate < DateTime.Today)
                    throw new ArgumentException("Date expired"); // Account date expired error

                return user;
            }

            return null;
        }
    }
}
