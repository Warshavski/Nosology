using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcNosology.UI.Startup))]
namespace MvcNosology.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
