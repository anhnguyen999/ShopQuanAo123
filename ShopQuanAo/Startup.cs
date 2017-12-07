using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShopQuanAo.Startup))]
namespace ShopQuanAo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
