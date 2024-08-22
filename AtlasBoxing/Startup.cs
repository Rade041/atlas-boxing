using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AtlasBoxing.Startup))]
namespace AtlasBoxing
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
