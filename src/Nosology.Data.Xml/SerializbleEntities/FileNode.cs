using System;

namespace Escyug.Nosology.Data.Xml.SerializbleEntities
{
    [Serializable()]
    public class FileNode
    {
        [System.Xml.Serialization.XmlElement("Id")]
        public int Id { get; set; }

        [System.Xml.Serialization.XmlElement("Title")]
        public string Title { get; set; }

        [System.Xml.Serialization.XmlElement("Link")]
        public string Link { get; set; }

        [System.Xml.Serialization.XmlElement("Type")]
        public string Type { get; set; }
    }
}
