using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escyug.Nosology.MVP.Engine;

namespace Escyug.Nosology.MVP.UI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StupidLogger logger = new StupidLogger();
            User user = logger.Logon("дзкк", "дзкк");

            if(user != null)
                Console.WriteLine("Name : {0}\tLevel : {1}", user.Name, user.Level);
            else
                Console.WriteLine("Can't find user");
        }
    }
}
