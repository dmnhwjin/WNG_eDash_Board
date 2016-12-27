using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WNG_eDash_Board.Startup))]
namespace WNG_eDash_Board
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
