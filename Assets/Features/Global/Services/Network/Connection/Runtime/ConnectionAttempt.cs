using Cysharp.Threading.Tasks;
using Global.Network.Connection.Logs;
using Ragon.Client;
using Ragon.Protocol;

namespace Global.Network.Connection.Runtime
{
    public struct ConnectionAttempt : IRagonConnectionListener, IRagonFailedListener, IRagonAuthorizationListener
    {
        public ConnectionAttempt(RagonClient client, ConnectionConfig config, ConnectionLogger logger)
        {
            _client = client;
            _config = config;
            _logger = logger;

            _connectCompletion = new UniTaskCompletionSource<ConnectionResultType>();
            _authorizeCompletion = new UniTaskCompletionSource<ConnectionResultType>();
        }

        private readonly RagonClient _client;
        private readonly ConnectionConfig _config;
        private readonly ConnectionLogger _logger;
        
        private readonly UniTaskCompletionSource<ConnectionResultType> _connectCompletion;
        private readonly UniTaskCompletionSource<ConnectionResultType> _authorizeCompletion;

        public async UniTask<ConnectionResultType> Connect(string playerName)
        {
            _logger.OnConnectionAttempt(_config.Address, _config.Protocol, _config.Port);
            
            Listen();

            _client.Connect(_config.Address, _config.Port, _config.Protocol);

            var connectionResult = await _connectCompletion.Task;

            await UniTask.Yield();
            
            if (connectionResult == ConnectionResultType.Fail)
            {
                Unlisten();

                return ConnectionResultType.Fail;
            }

            _logger.OnConnectionSuccess();

            _client.Session.AuthorizeWithKey("defaultkey", playerName);

            _logger.OnAuthorizationAttempt(playerName);

            var authorizeResult = await _authorizeCompletion.Task;
            await UniTask.Yield();

            Unlisten();
            
            if (authorizeResult == ConnectionResultType.Fail)
                return ConnectionResultType.Fail;
            
            _logger.OnAuthorizationSuccess();
            
            return ConnectionResultType.Success;
        }

        public void OnConnected(RagonClient client)
        {
            _connectCompletion.TrySetResult(ConnectionResultType.Success);
        }

        public void OnDisconnected(RagonClient client, RagonDisconnect reason)
        {
            
        }

        public void OnDisconnected(RagonClient client)
        {
            _connectCompletion.TrySetResult(ConnectionResultType.Fail);
        }

        public void OnFailed(RagonClient client, string message)
        {
            _logger.OnConnectionFailed(message);

            _connectCompletion.TrySetResult(ConnectionResultType.Fail);
        }

        public void OnAuthorizationSuccess(RagonClient client, string playerId, string playerName)
        {
            _authorizeCompletion.TrySetResult(ConnectionResultType.Success);
        }

        public void OnAuthorizationFailed(RagonClient client, string message)
        {
            _logger.OnConnectionFailed(message);

            _authorizeCompletion.TrySetResult(ConnectionResultType.Fail);
        }

        private void Listen()
        {
            _client.AddListener((IRagonConnectionListener)this);
            _client.AddListener((IRagonFailedListener)this);
            _client.AddListener((IRagonAuthorizationListener)this);
        }

        private void Unlisten()
        {
            _client.RemoveListener((IRagonConnectionListener)this);
            _client.RemoveListener((IRagonFailedListener)this);
            _client.RemoveListener((IRagonAuthorizationListener)this);
        }
    }
}