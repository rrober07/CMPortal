using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rma.CMPortal.WebUi.Startup))]
namespace Rma.CMPortal.WebUi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
