using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eClock.Web.Startup))]
namespace eClock.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
