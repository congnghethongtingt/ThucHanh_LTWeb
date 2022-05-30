using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab3_WebsiteBigSchool.Startup))]
namespace Lab3_WebsiteBigSchool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
