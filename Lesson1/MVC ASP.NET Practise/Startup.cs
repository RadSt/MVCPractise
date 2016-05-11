using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_ASP.NET_Practise.Startup))]
namespace MVC_ASP.NET_Practise
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
