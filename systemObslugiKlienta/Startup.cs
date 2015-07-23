using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(systemObslugiKlienta.Startup))]
namespace systemObslugiKlienta
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
