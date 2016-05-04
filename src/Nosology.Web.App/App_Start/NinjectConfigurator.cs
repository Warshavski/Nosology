using System.Configuration;

using log4net;
using log4net.Config;

using Ninject;
using Ninject.Web.Common;

using Escyug.Nosology.Common.Logging;

using Escyug.Nosology.Data.Processors;
using Escyug.Nosology.Data.Sql.Processors;

using Escyug.Nosology.Models.Services;
using Escyug.Nosology.Models.Repositories;

namespace Escyug.Nosology.Web.App
{
   /*
    * This is where we bind or relate interfaces 
    * to concrete implementations so that the
    * dependencies can be resolved at run time.
    * For example, if a class requires an IDateTime object, 
    * the bindings tell the container to provide a DateTimeAdapter object.
    */

    public sealed class NinjectConfigurator
    {
        public void Configure(IKernel container)
        {
            AddBindings(container);
        }

        private void AddBindings(IKernel container)
        {
            ConfigureLog4net(container);

            container.Bind<IUserProcessor>()
                .To<SqlUserProcessor>()
                .InRequestScope()
                .WithConstructorArgument("connectionString", GetConnectionString("local"));

            container.Bind<IUserRepository>()
                .To<UserRepository>()
                .InRequestScope();

            container.Bind<ILoginService>()
                .To<StupidLoginService>()
                .InRequestScope();
        }

        // get connection string from web.config
        private string GetConnectionString(string name)
        {
            // assume failure.
            string connectionString = null;

            // look for the name in the connectionStrings section.
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings[name];

            // if found, return the connection string.
            if (settings != null)
                connectionString = settings.ConnectionString;

            return connectionString;
        }

        // configurate log4net (logger framework)
        private void ConfigureLog4net(IKernel container)
        {
            XmlConfigurator.Configure();

            var logManager = new LogManagerAdapter();

            container.Bind<ILogManager>()
                .ToConstant(logManager);
        }
    }

}