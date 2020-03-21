using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FlexGains.Startup))]
namespace FlexGains
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
