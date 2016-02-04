using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Escyug.Nosology.MVP.DataAccessLayer.Xml
{
    public sealed class UserService
    {
        private string _path;

        public UserService()
        {
            _path = @"C:\test\users.xml";
        }

        /*
         *  <id>1</id>
            <name>User name #1</name>
            <folder>4e66dba9-abb1-4740-9187-254afa0c012e</folder>
            <login>login1</login>
            <pwd>123</pwd>
         */
        public DataTable GetUserData(string login)
        {
            DataTable userData = null;

            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                
                userData = new DataTable();
                using (XmlReader reader = XmlReader.Create(_path, settings))
                {
                    userData.ReadXmlSchema(reader);
                    //Keep reading until there are no more "XmlUser" elements
                    while (reader.ReadToFollowing("XmlUser"))
                    {
                        //Extract the value of the "login" attribute
                        string value = reader.GetAttribute(0);
                        if (value.Equals(login, StringComparison.OrdinalIgnoreCase))
                        {
                            string pwd = reader.GetAttribute("pwd");
                            string folder = reader.GetAttribute("folder");
                            string name = reader.GetAttribute("name");
                            int id = int.Parse(reader.GetAttribute("id"));

                            userData.LoadDataRow(new object[] { id, name, folder, value, pwd }, true);
                        }
                    }
                }
            }
            catch (XmlException)
            {
                if (userData != null)
                    userData = null;
            }

            return userData;
        }
    }
}
