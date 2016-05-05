
namespace Escyug.Nosology.Models
{
    internal sealed class ModelBinder
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

        public static Models.Document CreateDocumentModel(Data.Entities.Document documentData)
        {
            var documentTitle = documentData.Title;
            var documentDescription = documentData.Description;
            var documentLink = documentData.Link;

            return new Models.Document(documentTitle, documentDescription, documentLink);
        }
    }
}
