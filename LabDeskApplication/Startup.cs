using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LabDeskApplication.Startup))]
namespace LabDeskApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
