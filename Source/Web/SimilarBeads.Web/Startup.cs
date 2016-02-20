using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(SimilarBeads.Web.Startup))]

namespace SimilarBeads.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
