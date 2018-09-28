using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ComputosPJ.Startup))]
namespace ComputosPJ
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
