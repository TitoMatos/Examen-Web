using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Club_de_Socios.Startup))]
namespace Club_de_Socios
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
