
namespace Escyug.Nosology.Models
{
    public class File
    {
        public int Id { get; private set; }

        public string Title { get; private set; }

        public string Type { get; private set; }

        public string Link { get; private set; }

        public File(int fileId, string fileTitle,
            string fileType, string fileLink)
        {
            Id = fileId;
            Title = fileTitle;
            Type = fileType;
            Link = fileLink;
        }
    }
}
