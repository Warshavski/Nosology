using System;
using System.Configuration;

using Microsoft.AspNet.Identity;

using log4net;
using log4net.Config;

using Ninject;
using Ninject.Web.Common;

using Escyug.Nosology.Common.Logging;

using Escyug.Nosology.Data.QueryProcessors;
using Escyug.Nosology.Data.Sql.QueryProcessors;
using Escyug.Nosology.Data.Xml.QueryProcessors;

using Escyug.Nosology.Models;
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

            container.Bind<IUserByCredentialsQueryProcessor>()
                .To<UserByCredentialsQueryProcessor>()
                .InRequestScope()
                .WithConstructorArgument("connectionString", GetConnectionString("local"));
            container.Bind<IAllDocumentsQueryProcessor>()
                .To<AllDocumentsQueryProcessor>()
                .WithConstructorArgument("rootFolderPath", GetRootFolderPath());
            container.Bind<IAllFilesQueryProcessor>()
                .To<AllFilesQueryProcessor>()
                .WithConstructorArgument("rootFolderPath", GetRootFolderPath());

            container.Bind<IUserRepository>()
                .To<UserIdentityRepository>()
                .InRequestScope();
            container.Bind<IMainTextBlockRepository>()
                .To<MainTextBlockRepository>()
                .InRequestScope()
                .WithConstructorArgument("rootPath", GetRootFolderPath());
            container.Bind<IDocumentsRepository>()
                .To<DocumentsRepository>()
                .InRequestScope();
            container.Bind<IFilesRepository>()
                .To<FilesRepository>()
                .InRequestScope();

            container.Bind<UserManager<User>>()
                .To<UserManagerService>()
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

        private string GetRootFolderPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
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