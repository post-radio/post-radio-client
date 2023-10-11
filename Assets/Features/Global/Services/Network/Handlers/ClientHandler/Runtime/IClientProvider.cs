using Ragon.Client;

namespace Global.Network.Handlers.ClientHandler.Runtime
{
    public interface IClientProvider
    {
        RagonClient Client { get; }
    }
}