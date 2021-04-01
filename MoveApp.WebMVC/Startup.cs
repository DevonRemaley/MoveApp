using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoveApp.WebMVC.Startup))]
namespace MoveApp.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
