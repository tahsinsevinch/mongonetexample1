using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MongoEx.Startup))]
namespace MongoEx
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // ConfigureAuth(app);
        }
    }
}
