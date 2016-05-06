﻿using System;
using System.Configuration;

using Ninject;
using Ninject.Web.Common;

using Escyug.Nosology.Data.QueryProcessors;
using Escyug.Nosology.Data.Sql.QueryProcessors;
using Escyug.Nosology.Data.Xml.QueryProcessors;

using Escyug.Nosology.Models.Services;
using Escyug.Nosology.Models.Repositories;

using Escyug.Nosology.Presentation.Common;
using Escyug.Nosology.Presentation.Presenters;
using Escyug.Nosology.Presentation.Views;

namespace Escyug.Nosology.Web.App
{
    public class NinjectConfigurator
    {

        public void Configure(IKernel container)
        {
            AddBindings(container);
        }

        private void AddBindings(IKernel container)
        {
            // bindings goes here
            container.Bind<IUserQueryProcessor>()
                .To<SqlUserQueryProcessor>()
                .InRequestScope()
                .WithConstructorArgument("connectionString", GetConnectionString("local"));
            container.Bind<IDocumentQueryProcessor>()
                .To<XmlDocumentsQueryProcessor>()
                .InRequestScope()
                .WithConstructorArgument("rootPath", GetRootDirectory());

            container.Bind<IUserRepository>()
                .To<UserRepository>()
                .InRequestScope();
            container.Bind<IDocumentsRepository>()
                .To<DocumentsRepository>()
                .InRequestScope();

            container.Bind<IAboutRepository>()
                .To<AboutRepository>()
                .InRequestScope();

            container.Bind<ILoginService>()
                .To<StupidLoginService>()
                .InRequestScope();
            container.Bind<IDocumentsService>()
                .To<SimpleDocumentsService>()
                .InRequestScope();

            container.Bind<IPresenter<ILoginView>>()
                .To<LoginPresenter>()
                .InRequestScope();
            container.Bind<IPresenter<IMainView>>()
                .To<MainPresenter>()
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

        // get root directory of application
        private string GetRootDirectory()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}