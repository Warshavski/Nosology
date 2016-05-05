
namespace Escyug.Nosology.Models.Services
{
    public interface ILoginService
    {
        Models.User Login(string login, string password);
    }
}
