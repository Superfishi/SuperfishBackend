using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SuperfishBackendService.Startup))]

namespace SuperfishBackendService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}