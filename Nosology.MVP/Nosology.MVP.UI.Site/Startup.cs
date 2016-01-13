using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Escyug.Nosology.MVP.UI.Site.Startup))]
namespace Escyug.Nosology.MVP.UI.Site
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
