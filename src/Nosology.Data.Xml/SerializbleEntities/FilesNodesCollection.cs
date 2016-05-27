using System;
using System.Xml.Serialization;

namespace Escyug.Nosology.Data.Xml.SerializbleEntities
{
    [Serializable()]
    [System.Xml.Serialization.XmlRoot("FileCollection")]
    public class FilesNodesCollection
    {
        [XmlArray("Files")]
        [XmlArrayItem("File", typeof(FileNode))]
        public FileNode[] FilesNodes { get; set; }
    }
}
