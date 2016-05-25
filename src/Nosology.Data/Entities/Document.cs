using System;

namespace Escyug.Nosology.Data.Entities
{
    public sealed class Document
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public string Description { get; set; }

        public string Link { get; set; }

        public string Type { get; set; }
    }
}
