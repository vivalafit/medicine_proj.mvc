using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(med_projec_roles_added.Startup))]
namespace med_projec_roles_added
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
