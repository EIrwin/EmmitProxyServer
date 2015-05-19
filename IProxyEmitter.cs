namespace EmmitProxyServer
{
    public interface IProxyEmitter
    {
        void OnSendData(object data);
        void OnSendData(string methodName, object data);
    }
}