
namespace Escyug.Nosology.Models.Repositories
{
    public interface IUserRepository
    {
        Models.User SelectUser(string login, string password);
    }
}
