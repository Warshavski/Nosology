using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Escyug.Nosology.Data.Xml
{
    internal sealed class EntityDeSerializer
    {
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

        private static string CreatePath(string rootFolderPath, string fileName)
        {
            return string.Format("{0}\\App_Data\\{1}", rootFolderPath, fileName);
        }
    }
}
