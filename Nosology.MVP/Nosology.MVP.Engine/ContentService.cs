using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escyug.Nosology.MVP.Engine
{
    public sealed class ContentService
    {
        private const string ERROR_MESSAGE = "SERVER ERROR";

        private string _rootPath;

        public ContentService()
        {
            _rootPath = AppDomain.CurrentDomain.BaseDirectory;
            //@"C:\Users\Администратор\Documents\GitHub\nosology\Nosology.MVP\Nosology.MVP.UI.WebApp";
        }

        public string LoadMainContent()
        {
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
