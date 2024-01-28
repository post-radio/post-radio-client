using System.Collections.Generic;
using Common.Architecture.Scopes.Common.DefaultCallbacks;
using Common.Architecture.Scopes.Runtime.Services;
using GamePlay.Audio.Compose;
using GamePlay.Chat.Compose;
using GamePlay.Common.Paths;
using GamePlay.House.Bootstrap;
using GamePlay.ImageGallery.Compose;
using GamePlay.Level.Runtime;
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
        
        [FoldoutGroup("System")] [SerializeField]
        private DefaultCallbacksServiceFactory _defaultCallbacks;

        [FoldoutGroup("System")] [SerializeField]
        private LevelLoopFactory _levelLoop;

        [FoldoutGroup("System")] [SerializeField]
        private VfxPoolFactory _vfxPool;

        [FoldoutGroup("Level")] [SerializeField]
        private LevelCameraFactory _menuCamera;

        [FoldoutGroup("Level")] [SerializeField]
        private HouseServicesFactory _houseServices;

        [FoldoutGroup("Level")] [SerializeField]
        private BaseLevelSceneFactory _levelScene;

        [SerializeField] private AudioCompose _audio;
        [SerializeField] private PlayerServicesCompose _playerServices;
        [SerializeField] private LevelNetworkCompose _network;
        [SerializeField] private ChatCompose _chat;
        [SerializeField] private ImageGalleryFactory _imageGallery;

        [SerializeField] private LevelScope _scopePrefab;
        [SerializeField] private SceneData _servicesScene;

        public LifetimeScope ScopePrefab => _scopePrefab;
        public ISceneAsset ServicesScene => _servicesScene;

        public IReadOnlyList<IServiceFactory> Services => new IServiceFactory[]
        {
            _menuCamera,
            _levelLoop,
            _vfxPool,
            _levelScene,
            _ui,
            _houseServices,
            _imageGallery,
            _defaultCallbacks
        };

        public IReadOnlyList<IServicesCompose> Composes => new IServicesCompose[]
        {
            _network,
            _playerServices,
            _audio,
            _chat
        };
    }
}