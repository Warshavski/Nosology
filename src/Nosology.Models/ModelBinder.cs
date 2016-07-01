namespace Escyug.Nosology.Models
{
    /// <summary>
    /// Binds data entities to the domain model.
    /// </summary>
    internal static class ModelBinder
    {
        /// <summary>
        /// Creates user domain model from user data entity.
        /// </summary>
        /// <param name="userEntitie">User data entity.</param>
        /// <returns>User domain model.</returns>
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

        /// <summary>
        /// Creates document domain model from document data entity.
        /// </summary>
        /// <param name="documentEntity">Document data entity.</param>
        /// <returns>Document domain model.</returns>
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

        /// <summary>
        /// Creates file domain model from file data entity.
        /// </summary>
        /// <param name="fileEntity">File data entity.</param>
        /// <returns>File domain model.</returns>
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
