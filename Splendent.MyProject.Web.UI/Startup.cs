using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Splendent.MyProject.Web.UI.Startup))]
namespace Splendent.MyProject.Web.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
