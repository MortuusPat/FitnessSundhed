using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FitnessSundhed.Startup))]
namespace FitnessSundhed
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
