using System;
using System.Collections.Generic;
using Emmit;

namespace EmmitProxyServer
{
    public class ProxyEmitter:Emitter,IProxyEmitter
    {
        public ProxyEmitter():base((IEmitterContext) null)
        {
            
        }
        public ProxyEmitter(IEmitterContext emitterContext) : base(emitterContext)
        {
        }

        public ProxyEmitter(IEmitterContext emitterContext, EmitterModel model) : base(emitterContext, model)
        {
        }

        public ProxyEmitter(IDictionary<string, object> model) : base(model)
        {
        }

        public void OnSendData(object data)
        {
            EmitterContext.Clients.All.onReceiveData(data);
        }

        public void OnSendData(string methodName, object data)
        {
            Emit(methodName, data);
        }

        public override System.Threading.Tasks.Task OnConnected()
        {
            Console.WriteLine("Client connected:" + Context.ConnectionId);
            
            return base.OnConnected();
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            Console.WriteLine("Client disconnected:" + Context.ConnectionId);

            return base.OnDisconnected(stopCalled);
        }
    }
}