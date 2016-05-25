namespace Escyug.Nosology.Models
{
    internal static class ModelBinder
    {
        public static Models.User CreateUserModel(Data.Entities.User userEntitie)
        {
            var levels = new string[] 
            {
                "Администратор",
                "Орган управления здравоохранением субъекта Российской федерации",
                "Орган управления здравоохранением муниципального образования субъекта Российской федерации",
                "Лечебно-профилактическое учреждение",
                "Аптечное учреждение"
            };

            var userName = userEntitie.Name;
            var userLevel = levels[userEntitie.Level];
            var userExpiredDate = userEntitie.ExpiredDate;

            return new Models.User(userName, userLevel, userExpiredDate);
        }

        public static Models.Document CreateDocumentModel(Data.Entities.Document documentEntitie)
        {
            var documentId = documentEntitie.Id;
            var documentTitle = documentEntitie.Title;
            var documentDescription = documentEntitie.Description;
            var documentLink = documentEntitie.Link;
            var documentType = documentEntitie.Type;

            return new Document(documentId, documentTitle,
                documentDescription, documentType, documentLink);
        }
    }
}
