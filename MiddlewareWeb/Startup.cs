using Microsoft.Owin;
using MiddlewareWeb;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace MiddlewareWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
