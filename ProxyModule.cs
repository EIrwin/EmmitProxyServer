using Emmit;
using Nancy;

namespace EmmitProxyServer
{
    public class ProxyModule:NancyModule
    {
        public ProxyModule()
        {
            Post["/", true] = async (context, cancel) =>
                {
                    IEmitterFactory factory = new EmitterFactory();
                    IProxyEmitter emitter = factory.Create((ctx) => new ProxyEmitter(ctx));
                    emitter.OnSendData(context.data);

                    return Response.AsJson(true);
                };

        }
    }
}