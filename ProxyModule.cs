using Emmit;
using Microsoft.AspNet.SignalR;
using Nancy;
using Nancy.ModelBinding;

namespace EmmitProxyServer
{
    public class ProxyModule:NancyModule
    {
        public ProxyModule()
        {
            Post["/", true] = async (context, cancel) =>
                {
                    var model = this.Bind<ProxyModel>();
                    IEmitterFactory factory = new EmitterFactory();
                    IProxyEmitter emitter = factory.Create((ctx) => new ProxyEmitter(ctx));
                    emitter.OnSendData(model.Data);

                    return Response.AsJson(true);
                };

            Post["/dynamic", true] = async (context, cancel) =>
                {
                    var model = this.Bind<DynamicProxyModel>();
                    IEmitterFactory factory = new EmitterFactory();
                    IProxyEmitter emitter = factory.Create((ctx) => new ProxyEmitter(ctx));
                    emitter.OnSendData(model.Method,model.Data);
                    

                    return Response.AsJson(true);
                };

            Get["/", true] = async (context, cancel) =>
                {
                    return Response.AsJson(true);
                };

        }
    }
}