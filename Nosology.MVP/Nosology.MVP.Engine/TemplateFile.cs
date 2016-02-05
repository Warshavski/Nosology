using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escyug.Nosology.MVP.Engine.Repositories;

namespace Escyug.Nosology.MVP.Engine
{
    public enum FileType { defaultFile, txt, doc, exel, pdf, exe }

    public sealed class TemplateFile
    {
        private static int testID = 0;

        private int _id;
        public int Id { get { return _id; } }

        private string _title;
        public string Title { get { return _title; } }

        private string _link;
        public string Link { get { return _link; } }


        private string _description;
        public string Description { get { return _description; } }

        private FileType _fileType;
        public FileType FileType { get { return _fileType; } }

        public TemplateFile(int id, string title, string link, string description, FileType fileType)
        {
            _id = id;
            _title = title;
            _link = link;
            _description = description;
            _fileType = fileType;
        }

        public TemplateFile()
        {
            _id = ++testID;
            _title = "TITLE_TEMPLATE";
            _link = "LINK_TEMPLATE";
            _description = "DESCRIPTION_TEMPLATE";
            _fileType = FileType.defaultFile;
        }

        public static List<TemplateFile> LoadDocuments()
        {
            TemplateFileRepository fileRepo = new TemplateFileRepository();
            return fileRepo.SelectDocuments();
        }

        public static List<TemplateFile> LoadFiles()
        {
            TemplateFileRepository fileRepo = new TemplateFileRepository();
            return fileRepo.SelectFiles();
        }
    }
}
