using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SystemKnowledgeMVC.Startup))]
namespace SystemKnowledgeMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
