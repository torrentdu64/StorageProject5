using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StorageProject5.Startup))]
namespace StorageProject5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
