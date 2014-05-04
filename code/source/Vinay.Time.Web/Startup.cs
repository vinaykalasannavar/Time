using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vinay.Time.Web.Startup))]
namespace Vinay.Time.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
