[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Escyug.Nosology.Web.App.NinjectWeb), "Start")]

namespace Escyug.Nosology.Web.App
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web;

    public static class NinjectWeb 
    {
        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
        }
    }
}
