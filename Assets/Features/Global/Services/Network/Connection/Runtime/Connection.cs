using System;
using Cysharp.Threading.Tasks;
using Global.Network.Connection.Logs;
using Global.Network.Handlers.ClientHandler.Runtime;
using Ragon.Client;
using Ragon.Protocol;
using Random = UnityEngine.Random;

namespace Global.Network.Connection.Runtime
{
    public class Connection : IConnection, IRagonConnectionListener
    {
        public Connection(
            IClientProvider clientProvider,
            ConnectionLogger logger,
            ConnectionConfig config)
        {
            _clientProvider = clientProvider;
            _logger = logger;
            _config = config;
        }
        
        private readonly IClientProvider _clientProvider;
        private readonly ConnectionLogger _logger;
        private readonly ConnectionConfig _config;

        public event Action Disconnected;
        
        public async UniTask<ConnectionResultType> Connect()
        {
            var attempt = new ConnectionAttempt(_clientProvider.Client, _config, _logger);

            var result = await attempt.Connect($"Doomer_{Random.Range(0,100)}");

            return result;
        }

        public void OnConnected(RagonClient client)
        {
        }

        public void OnDisconnected(RagonClient client, RagonDisconnect reason)
        {
            
        }

        public void OnDisconnected(RagonClient client)
        {
            Disconnected?.Invoke();
        }
    }
}