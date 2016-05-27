
namespace Escyug.Nosology.Models
{
    public class File
    {
        private int _fileId;
        public int Id { get { return _fileId; } }

        private string _fileTitle;
        public string Title { get { return _fileTitle; } }

        private string _fileType;
        public string Type { get { return _fileType; } }

        private string _fileLink;
        public string Link { get { return _fileLink; } }

        public File(int fileId, string fileTitle,
            string fileType, string fileLink)
        {
            _fileId = fileId;
            _fileTitle = fileTitle;
            _fileType = fileType;
            _fileLink = fileLink;
        }
    }
}
