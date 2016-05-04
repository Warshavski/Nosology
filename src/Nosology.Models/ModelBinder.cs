namespace Escyug.Nosology.Models
{
    internal static class ModelBinder
    {
        public static Models.User CreateUserModel(Data.Entities.User userData)
        {
            var levels = new string[] 
            {
                "Администратор",
                "Орган управления здравоохранением субъекта Российской федерации",
                "Орган управления здравоохранением муниципального образования субъекта Российской федерации",
                "Лечебно-профилактическое учреждение",
                "Аптечное учреждение"
            };

            var userName = userData.Name;
            var userLevel = levels[userData.Level];
            var userExpiredDate = userData.ExpiredDate;

            return new Models.User(userName, userLevel, userExpiredDate);
        }
    }
}
