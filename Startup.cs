using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sim_Card.Startup))]
namespace Sim_Card
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
