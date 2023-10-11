using Ragon.Client;

namespace Global.Network.Handlers.ClientHandler.Runtime
{
    public interface IClientFactory
    {
        RagonClient Create();
    }
}