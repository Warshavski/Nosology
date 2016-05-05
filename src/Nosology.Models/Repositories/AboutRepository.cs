using System;
using System.IO;
using System.Text;

namespace Escyug.Nosology.Models.Repositories
{
    public class AboutRepository : IAboutRepository
    {
        private const string ERROR_MESSAGE = "SERVER ERROR";

        private readonly string _rootPath;

        // create constructor with root directory path
        public AboutRepository()
        {
            _rootPath = AppDomain.CurrentDomain.BaseDirectory;
        }

        public string SelectAboutInfo()
        {
            /* 
           * TODO :
           *  1. move this shit to DAL or(and) to model
           *  2. implement async version
           */
            string path = string.Format("{0}\\{1}", _rootPath, "App_Data\\main.txt");

            StringBuilder content = new StringBuilder();

            StreamReader reader = null;
            try
            {
                using (reader = new StreamReader(path, Encoding.GetEncoding(1251)))
                {
                    while (!reader.EndOfStream)
                        content.Append(reader.ReadToEnd());
                }
            }
            catch (IOException)
            {
                content.Append(ERROR_MESSAGE);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            return content.ToString();
        }
    }
}
