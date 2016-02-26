using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Escyug.Nosology.MVP.Engine
{
    public sealed class User
    {
        private string _name;
        public string Name
        {
            get { return _name; }
        }

        private string _level;
        public string Level
        {
            get { return _level; }
        }

        public User()
        {
            _name = string.Empty;
            _level = string.Empty;    
        }

        public User(string name, string level)
        {
            _name = name;
            _level = level;
        }

        public List<TemplateFile> LoadDucuments()
        {
            throw new NotImplementedException();
        }
    }
}
