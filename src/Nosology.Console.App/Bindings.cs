using System;
using System.Configuration;
using System.Collections.Generic;

using Ninject;
using Ninject.Modules;

using Escyug.Nosology.Data.QueryProcessors;
using Escyug.Nosology.Data.Sql.QueryProcessors;

using Escyug.Nosology.Models.Services;
using Escyug.Nosology.Models.Repositories;


namespace Escyug.Nosology.Console.App
{
    public sealed class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserByCredentialsQueryProcessor>()
                .To<UserByCredentialsQueryProcessor>()
                .WithConstructorArgument("connectionString", GetConnectionString("test"));

            Bind<IUserRepository>()
                .To<UserRepository>();

            Bind<ILoginService>()
                .To<StupidLoginService>();
        }

        private string GetConnectionString(string name)
        {
            // Assume failure.
            string connectionString = null;

            // Look for the name in the connectionStrings section.
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings[name];

            // If found, return the connection string.
            if (settings != null)
                connectionString = settings.ConnectionString;

            return connectionString;
        }
    }
}
