using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Escyug.Nosology.Data.Xml
{
    internal sealed class EntityDeSerializer
    {
        /// <summary>
        /// Deserialize data entity.
        /// </summary>
        /// <typeparam name="TEntity">Data type of the data entity.</typeparam>
        /// <param name="rootFolderPath">Application root folder.</param>
        /// <param name="fileName">Xml file name that contains data entities.</param>
        /// <returns>Data entity instance.</returns>
        public static TEntity GetDeSerializedEntity<TEntity>(string rootFolderPath, string fileName)
            where TEntity : class
        {
            try
            {
                var entity = default(TEntity);
                string path = CreatePath(rootFolderPath, fileName);

                XmlSerializer serializer = new XmlSerializer(typeof(TEntity));

                using (var reader = new StreamReader(path))
                {
                    entity = (TEntity)serializer.Deserialize(reader);
                }

                return entity;
            }
            catch (XmlException)
            {
                return default(TEntity);
            }           
        }

        /// <summary>
        /// Creates path to the xml data storage folder.
        /// </summary>
        /// <param name="rootFolderPath">Application root folder.</param>
        /// <param name="fileName">Name of the *.xml file.</param>
        /// <returns>Path to the xml file storage.</returns>
        private static string CreatePath(string rootFolderPath, string fileName)
        {
            return string.Format("{0}\\App_Data\\{1}", rootFolderPath, fileName);
        }
    }
}
