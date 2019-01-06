using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BO_Voyage_UIL.Startup))]
namespace BO_Voyage_UIL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
