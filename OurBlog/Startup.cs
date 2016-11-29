using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OurBlog.Startup))]
namespace OurBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
