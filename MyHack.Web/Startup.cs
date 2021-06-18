using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyHack.Web.Startup))]
namespace MyHack.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
