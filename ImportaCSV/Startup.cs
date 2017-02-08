using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ImportaCSV.Startup))]
namespace ImportaCSV
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
