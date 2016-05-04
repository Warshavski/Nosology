using System;
using System.Reflection;

using Ninject;

using Escyug.Nosology.Models.Services;

namespace Escyug.Nosology.Console.App
{
    internal sealed class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            var loginService = kernel.Get<ILoginService>();

            System.Console.Write("Input login : ");
            var login = System.Console.ReadLine();

            System.Console.Write("Input password : ");
            var password = System.Console.ReadLine();

            System.Console.WriteLine("---------------------------");

            try
            {
                var user = loginService.Login(login, password);

                System.Console.WriteLine(user.Name);
                System.Console.WriteLine(user.Level);
            }
            catch (NullReferenceException)
            {
                System.Console.WriteLine("Wow such error, so null exception");
            }
        }
    }
}
