using System.Collections.Generic;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Global.Network.Common;
using Global.Network.Connection.Runtime;
using Global.Network.EventsRegistries.Runtime;
using Global.Network.Handlers.ClientHandler.Runtime;
using Global.Network.Handlers.SceneCollectors.Runtime;
using Global.Network.Objects.EntityListeners.Runtime;
using Global.Network.Session.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Network.Compose
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "GlobalNetworkCompose", menuName = GlobalNetworkAssetsPaths.Root + "Compose")]
    public class GlobalNetworkCompose : ScriptableObject
    {
        [SerializeField] private ConnectionFactory _connection;
        [SerializeField] private ClientHandlerFactory _client;
        [SerializeField] private SceneCollectorBridgeFactory _sceneCollector;
        [SerializeField] private NetworkEntityListenerFactory _entityListener;
        [SerializeField] private SessionFlowFactory _sessionFlow;
        [SerializeField] private EventsRegistryFactory _eventsRegistry;

        public IReadOnlyList<IServiceFactory> Services => new IServiceFactory[]
        {
            _connection,
            _client,
            _sceneCollector,
            _entityListener,
            _sessionFlow,
            _eventsRegistry
        };
    }
}