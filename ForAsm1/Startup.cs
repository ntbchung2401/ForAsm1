using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ForAsm1.Startup))]
namespace ForAsm1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
