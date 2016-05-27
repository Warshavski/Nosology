using System;
using System.Xml.Serialization;

namespace Escyug.Nosology.Data.Xml.SerializbleEntities
{
    [Serializable()]
    [System.Xml.Serialization.XmlRoot("DocumentCollection")]
    public class DocumentNodesCollection
    {
        [XmlArray("Documents")]
        [XmlArrayItem("Document", typeof(DocumentNode))]
        public DocumentNode[] DocumentsNodes { get; set; }
    }
}
