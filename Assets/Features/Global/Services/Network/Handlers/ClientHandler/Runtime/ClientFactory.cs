using System;
using Global.Network.Connection.Configuration;
using Global.Network.Handlers.SceneCollectors.Runtime;
using Global.Network.Objects.EntityListeners.Runtime;
using Ragon.Client;
using Ragon.Client.Unity;
using UnityEngine.Assertions;

namespace Global.Network.Handlers.ClientHandler.Runtime
{
    public class ClientFactory : IClientFactory
    {
        public ClientFactory(
            ISceneCollectorBridge sceneCollectorBridge,
            IEntityListener entityListener,
            IRagonConnectionOptions options)
        {
            _sceneCollectorBridge = sceneCollectorBridge;
            _entityListener = entityListener;
            _options = options;
        }

        private readonly ISceneCollectorBridge _sceneCollectorBridge;
        private readonly IEntityListener _entityListener;
        private readonly IRagonConnectionOptions _options;

        public RagonClient Create()
        {
            Assert.IsNotNull(_sceneCollectorBridge);

            var connection = GetConnection(_options.Type);
            var client = new RagonClient(connection, _options.Rate);
            client.Configure(_entityListener);
            client.Configure(_sceneCollectorBridge);
            return client;
        }

        private INetworkConnection GetConnection(RagonConnectionType connectionType)
        {
            return connectionType switch
            {
                RagonConnectionType.None => new RagonWebSocketConnection(),
                RagonConnectionType.UDP => new RagonENetConnection(),
                RagonConnectionType.WebSocket => new RagonWebSocketConnection(),
                _ => throw new ArgumentOutOfRangeException(nameof(connectionType), connectionType, null)
            };
        }
    }
}