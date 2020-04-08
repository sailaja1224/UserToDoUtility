using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ToDoUtility.Startup))]
namespace ToDoUtility
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
