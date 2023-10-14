using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Global.System.Updaters.Runtime.Abstract;
using Ragon.Client;

namespace Global.Network.Handlers.ClientHandler.Runtime
{
    public class ClientHandler : IClientProvider, IUpdatable, IScopeAwakeListener, IScopeDisableListener
    {
        public ClientHandler(IClientFactory factory, IUpdater updater)
        {
            _updater = updater;
            _client = factory.Create();
        }

        private readonly RagonClient _client;
        private readonly IUpdater _updater;

        public RagonClient Client => _client;

        public void OnAwake()
        {
            _updater.Add(this);
        }

        public void OnUpdate(float delta)
        {
            _client.Update(delta);
        }

        public void OnDisabled()
        {
            _client.Dispose();
        }
    }
}