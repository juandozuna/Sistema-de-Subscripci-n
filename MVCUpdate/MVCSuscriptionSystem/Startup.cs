using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCSuscriptionSystem.Startup))]
namespace MVCSuscriptionSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
