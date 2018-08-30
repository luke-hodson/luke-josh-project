using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(luke_josh_project.Startup))]
namespace luke_josh_project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
