using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SpaceAdventure.WebMC.Startup))]
namespace SpaceAdventure.WebMC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
