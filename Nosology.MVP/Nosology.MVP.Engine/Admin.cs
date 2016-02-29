using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Escyug.Nosology.MVP.Engine
{
    public sealed class Admin : User
    {
        public Admin(string name)
            : base(name, "admin")
        {

        }

        public List<TemplateFile> LoadFiles()
        {
            throw new NotImplementedException();
        }

        public List<User> LoadUsers()
        {
            throw new NotImplementedException();
        }

        public void AddUser(User usr)
        {
            throw new NotImplementedException();
        }

        public void AddFile(TemplateFile file)
        {
            throw new NotImplementedException();
        }
    }
}
