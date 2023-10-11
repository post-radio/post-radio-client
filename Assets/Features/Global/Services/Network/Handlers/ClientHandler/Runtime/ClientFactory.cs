using System;
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
            RagonConnectionType connectionType,
            int rate)
        {
            _sceneCollectorBridge = sceneCollectorBridge;
            _entityListener = entityListener;
            _connectionType = connectionType;
            _rate = rate;
        }
        
        private readonly ISceneCollectorBridge _sceneCollectorBridge;
        private readonly IEntityListener _entityListener;
        private readonly RagonConnectionType _connectionType;
        private readonly int _rate;
        
        public RagonClient Create()
        {
            var sceneCollector = (IRagonSceneCollector)_sceneCollectorBridge;
            
            Assert.IsNotNull(sceneCollector);

            var connection = GetConnection(_connectionType);
            var client = new RagonClient(connection, _rate);
            client.Configure(_entityListener);
            client.Configure(sceneCollector);
            return client;
        }

        private INetworkConnection GetConnection(RagonConnectionType connectionType)
        {
            return connectionType switch
            {
                RagonConnectionType.None => new RagonWebSocketConnection(),
                RagonConnectionType.UDP => new RagonWebSocketConnection(),
                RagonConnectionType.WebSocket => new RagonWebSocketConnection(),
                _ => throw new ArgumentOutOfRangeException(nameof(connectionType), connectionType, null)
            };
        }
    }
}