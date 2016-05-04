namespace Escyug.Nosology.Data.Processors
{
    public interface IUserProcessor
    {
        Data.Entities.User SelectUser(string login, string password);
    }
}
