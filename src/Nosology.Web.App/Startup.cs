using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Escyug.Nosology.Web.App.Startup))]
namespace Escyug.Nosology.Web.App
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
