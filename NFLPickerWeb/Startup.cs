using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NFLPickerWeb.Startup))]
namespace NFLPickerWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
