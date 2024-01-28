using System.Collections.Generic;
using Common.Architecture.Scopes.Runtime.Services;
using GamePlay.Network.Common.Paths;
using GamePlay.Network.Messaging.Events.Runtime;
using GamePlay.Network.Messaging.REST.Runtime;
using GamePlay.Network.Objects.Destroyer.Runtime;
using GamePlay.Network.Objects.Factories.Registry;
using GamePlay.Network.Objects.Factories.Runtime;
using GamePlay.Network.Room.Entities.Factory;
using GamePlay.Network.Room.EventLoops.Runtime;
using GamePlay.Network.Room.Lifecycle.Runtime;
using GamePlay.Network.Room.SceneCollectors.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Network.Compose
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "LevelNetworkCompose", menuName = GamePlayNetworkAssetsPaths.Root + "Compose")]
    public class LevelNetworkCompose : ScriptableObject, IServicesCompose
    {
        [SerializeField] private RoomStarterBaseFactory _roomStarter;
        [SerializeField] private NetworkEntityDestroyerFactory _entityDestroyer;
        [SerializeField] private NetworkFactoriesRegistryFactory _factoriesRegistry;
        [SerializeField] private SceneEntityFactoryServiceFactory _sceneEntityFactory;
        [SerializeField] private NetworkSceneCollectorFactory _sceneCollector;
        [SerializeField] private DynamicEntityFactoryServiceFactory _dynamicEntityFactory;
        [SerializeField] private NetworkEventsLoopFactory _eventsLoop;
        [SerializeField] private MessengerFactory _messenger;
        [SerializeField] private NetworkEventsFactory _events;
        
        public IReadOnlyList<IServiceFactory> Factories => new IServiceFactory[]
        {
            _roomStarter,
            _entityDestroyer,
            _factoriesRegistry,
            _sceneEntityFactory,
            _sceneCollector,
            _dynamicEntityFactory,
            _eventsLoop,
            _messenger,
            _events
        };
    }
}