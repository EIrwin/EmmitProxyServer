using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;

namespace EmmitProxyServer
{
    public class EmmitStartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR(string.Empty, new HubConfiguration()
                {
                    EnableJavaScriptProxies = true,

                });
        }
    }
}