using Common.Architecture.ScopeLoaders.Runtime.Services;
using GamePlay.Network.Common;
using GamePlay.Network.Objects.Destroyer.Runtime;
using GamePlay.Network.Objects.Factories.Registry;
using GamePlay.Network.Objects.Factories.Runtime;
using GamePlay.Network.Players.Registry.Runtime;
using GamePlay.Network.Room.Entities.Factory;
using GamePlay.Network.Room.SceneCollectors.Runtime;
using GamePlay.Network.Room.Starter.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Network.Compose
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "LevelNetworkCompose", menuName = GamePlayNetworkAssetsPaths.Root + "Compose")]
    public class LevelNetworkCompose : ScriptableObject
    {
        [FoldoutGroup("Network")] [SerializeField]
        private RoomStarterBaseFactory _roomStarter;
        [FoldoutGroup("Network")] [SerializeField]
        private NetworkEntityDestroyerFactory _entityDestroyer;
        [FoldoutGroup("Network")] [SerializeField]
        private NetworkFactoriesRegistryFactory _factoriesRegistry;
        [FoldoutGroup("Network")] [SerializeField]
        private SceneEntityFactoryServiceFactory _sceneEntityFactory;
        [FoldoutGroup("Network")] [SerializeField]
        private NetworkSceneCollectorFactory _sceneCollector;
        [FoldoutGroup("Network")] [SerializeField]
        private DynamicEntityFactoryServiceFactory _dynamicEntityFactory;
        [FoldoutGroup("Network")] [SerializeField]
        private PlayersRegistryFactory _playersRegistry;

        public IServiceFactory[] Services => new IServiceFactory[]
        {
            _roomStarter,
            _entityDestroyer,
            _factoriesRegistry,
            _sceneEntityFactory,
            _sceneCollector,
            _dynamicEntityFactory,
            _playersRegistry
        };
    }
}