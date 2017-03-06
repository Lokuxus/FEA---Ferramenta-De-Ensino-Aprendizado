using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FEA.Startup))]
namespace FEA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
