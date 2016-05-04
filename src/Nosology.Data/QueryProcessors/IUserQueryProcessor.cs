namespace Escyug.Nosology.Data.QueryProcessors
{
    public interface IUserQueryProcessor
    {
        Data.Entities.User SelectUser(string login, string password);
    }
}
