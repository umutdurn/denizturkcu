using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(denizturkcu.Startup))]
namespace denizturkcu
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
