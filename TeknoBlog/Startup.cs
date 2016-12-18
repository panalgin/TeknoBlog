using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeknoBlog.Startup))]
namespace TeknoBlog
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
