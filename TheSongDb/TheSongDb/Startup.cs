using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheSongDb.Startup))]
namespace TheSongDb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
