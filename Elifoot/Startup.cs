using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Elifoot.Startup))]
namespace Elifoot
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
