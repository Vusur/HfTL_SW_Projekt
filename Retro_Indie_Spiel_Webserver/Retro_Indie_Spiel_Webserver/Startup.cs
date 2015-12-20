using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Retro_Indie_Spiel_Webserver.Startup))]
namespace Retro_Indie_Spiel_Webserver
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
