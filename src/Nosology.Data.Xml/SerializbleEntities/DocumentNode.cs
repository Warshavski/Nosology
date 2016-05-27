using System;

namespace Escyug.Nosology.Data.Xml.SerializbleEntities
{
    [Serializable()]
    public class DocumentNode : FileNode
    {
        [System.Xml.Serialization.XmlElement("Description")]
        public string Description { get; set; }
    }
}
