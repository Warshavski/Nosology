[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Escyug.Nosology.Web.App.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Escyug.Nosology.Web.App.NinjectWebCommon), "Stop")]

namespace Escyug.Nosology.Web.App
{
    using System;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    using Escyug.Nosology.Web.Common;

    /*
    * Make sure a DI container is created during 
    * application start-up and remains in memory
    * until the application shuts down. (You can think 
    * of the container as the object that contains the dependencies.)
    */

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// register dependency resolver with Web API configuratio. In doing so, 
        /// we have directed the framework to hit our configured Ninject 
        /// container instance to resolve any dependencies that are needed.
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            
            IKernel container = null;
            bootstrapper.Initialize(() =>
            {
                container = CreateKernel();
                return container;
            });

            var resolver = new NinjectDependencyResolver(container);
            DependencyResolver.SetResolver(resolver);

            /* for Web API
             * GlobalConfiguration.Configuration.DependencyResolver = resolver;
             */
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// configure the container bindings using the NinjectConfigurator class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            var configurator = new NinjectConfigurator();
            configurator.Configure(kernel);
        }        
    }
}

/*
 * It's important to note that the registration of our dependency resolver with MVC APP
 * and configuration of container bindings by the NinjectConfigurator.Configure method
 * are both called (the former directly, the letter indirectly) from the Start method, 
 * which is called during application start-up. In this way, all of this setup is completed
 * before the application accepts and processes anu HTTP requests, and thus before any of the
 * controllers - which rely on dependencies being injected into them - are ever created.
 */