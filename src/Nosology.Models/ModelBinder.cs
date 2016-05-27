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

        public static Models.Document CreateDocumentModel(Data.Entities.Document documentEntity)
        {
            var documentId = documentEntity.Id;
            var documentTitle = documentEntity.Title;
            var documentDescription = documentEntity.Description;
            var documentLink = documentEntity.Link;
            var documentType = documentEntity.Type;

            return new Document(documentId, documentTitle,
                documentDescription, documentType, documentLink);
        }

        public static Models.File CreateFileModel(Data.Entities.File fileEntity)
        {
            var fileId = fileEntity.Id;
            var fileTitle = fileEntity.Title;
            var fileLink = fileEntity.Link;
            var fileType = fileEntity.Type;

            return new File(fileId, fileTitle, fileType, fileLink);
        }
    }
}
