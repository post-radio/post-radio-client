using Common.Architecture.ScopeLoaders.Runtime.Services;
using GamePlay.Network.Common.Paths;
using GamePlay.Network.Messaging.REST.Runtime;
using GamePlay.Network.Objects.Destroyer.Runtime;
using GamePlay.Network.Objects.Factories.Registry;
using GamePlay.Network.Objects.Factories.Runtime;
using GamePlay.Network.Room.Entities.Factory;
using GamePlay.Network.Room.EventLoops.Runtime;
using GamePlay.Network.Room.SceneCollectors.Runtime;
using GamePlay.Network.Room.Starter.Runtime;
using GamePlay.Player.Services.Lists.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace GamePlay.Network.Compose
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "LevelNetworkCompose", menuName = GamePlayNetworkAssetsPaths.Root + "Compose")]
    public class LevelNetworkCompose : ScriptableObject
    {
        [SerializeField] private RoomStarterBaseFactory _roomStarter;
        [SerializeField] private NetworkEntityDestroyerFactory _entityDestroyer;
        [SerializeField] private NetworkFactoriesRegistryFactory _factoriesRegistry;
        [SerializeField] private SceneEntityFactoryServiceFactory _sceneEntityFactory;
        [SerializeField] private NetworkSceneCollectorFactory _sceneCollector;
        [SerializeField] private DynamicEntityFactoryServiceFactory _dynamicEntityFactory;
        [FormerlySerializedAs("_playersRegistry")] [SerializeField] private PlayersListFactory _playersList;
        [SerializeField] private NetworkEventsLoopFactory _eventsLoop;
        [SerializeField] private MessengerFactory _messenger;
        
        public IServiceFactory[] Services => new IServiceFactory[]
        {
            _roomStarter,
            _entityDestroyer,
            _factoriesRegistry,
            _sceneEntityFactory,
            _sceneCollector,
            _dynamicEntityFactory,
            _playersList,
            _eventsLoop,
            _messenger
        };
    }
}