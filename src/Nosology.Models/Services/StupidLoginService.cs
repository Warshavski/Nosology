using System;

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

        public bool Login(User user)
        {
            throw new NotImplementedException();
        }

        public User Login(string login, string password)
        {
            if (login.Length <= LOGIN_SIZE_THRESHOLD && password.Length <= PWD_SIZE_THRESHOLD)
            {
                var user = _userRepository.SelectUser(login, password);

                if (user.ExpiredDate < DateTime.Today)
                    throw new ArgumentException(); // Account date expired error

                return user;
            }

            return null;
        }
    }
}
