using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Olympiad.Startup))]
namespace Olympiad
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
