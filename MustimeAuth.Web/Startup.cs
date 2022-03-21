using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MustimeAuth.Web.Startup))]
namespace MustimeAuth.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
      //hello
            ConfigureAuth(app);
        }
    }
}
