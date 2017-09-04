using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebMvc5.Startup))]
namespace WebMvc5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
