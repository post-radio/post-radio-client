using System.Collections.Generic;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using GamePlay.Common.Paths;
using GamePlay.House.Bootstrap;
using GamePlay.Level.Scene.Runtime;
using GamePlay.Loop.Runtime;
using GamePlay.Network.Compose;
using GamePlay.Player.Services.Compose;
using GamePlay.Services.Common.Scope;
using GamePlay.Services.LevelCameras.Runtime;
using GamePlay.Services.VfxPools.Runtime;
using GamePlay.UI.Runtime;
using Internal.Services.Scenes.Data;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer.Unity;

namespace GamePlay.Config.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "Level", menuName = GamePlayAssetsPaths.Root + "Scene")]
    public class LevelScopeConfig : ScriptableObject, IScopeConfig
    {
        [FoldoutGroup("UI")] [SerializeField] private LevelUiFactory _ui;

        [FoldoutGroup("System")] [SerializeField] private LevelLoopFactory _levelLoop;
        [FoldoutGroup("System")] [SerializeField] private VfxPoolFactory _vfxPool;
        
        [FoldoutGroup("Level")] [SerializeField] private LevelCameraFactory _levelCamera;
        [FoldoutGroup("Level")] [SerializeField] private HouseServicesFactory _houseServices;
        [FoldoutGroup("Level")] [SerializeField] private BaseLevelSceneFactory _levelScene;
        
        [SerializeField] private PlayerServicesCompose _playerServices;
        
        [SerializeField] private LevelNetworkCompose _network;

        [SerializeField] private LevelScope _scopePrefab;
        [SerializeField] private SceneData _servicesScene;

        public LifetimeScope ScopePrefab => _scopePrefab;
        public ISceneAsset ServicesScene => _servicesScene;
        public IReadOnlyList<IServiceFactory> Services => GetFactories();
        public IReadOnlyList<ICallbacksFactory> Callbacks => GetCallbacks();

        protected IServiceFactory[] GetFactories()
        {
            var services = new List<IServiceFactory>()
            {
                _levelCamera,
                _levelLoop,
                _vfxPool,
                _levelScene,
                _ui,
                _houseServices
            };

            services.AddRange(_network.Services);
            services.AddRange(_playerServices.Services);

            return services.ToArray();
        }

        private ICallbacksFactory[] GetCallbacks()
        {
            return new[]
            {
                new DefaultCallbacksFactory()
            };
        }
    }
}