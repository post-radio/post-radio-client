using System.Collections.Generic;
using Common.Architecture.EntityCreators.Factory;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Tools.UniversalAnimators.Updaters.Runtime;
using Global.Audio.Listener.Runtime;
using Global.Audio.Player.Runtime;
using Global.Backend.Runtime;
using Global.Cameras.CameraUtilities.Runtime;
using Global.Cameras.CurrentCameras.Runtime;
using Global.Cameras.GlobalCameras.Runtime;
using Global.GameLoops.Runtime;
using Global.Inputs.View.Runtime;
using Global.Localizations.Runtime;
using Global.Network.Compose;
using Global.Publisher.Abstract.Bootstrap;
using Global.System.ApplicationProxies.Runtime;
using Global.System.DestroyHandlers.Runtime;
using Global.System.LoadedHandler.Runtime;
using Global.System.MessageBrokers.Runtime;
using Global.System.Pauses.Runtime;
using Global.System.ResourcesCleaners.Runtime;
using Global.System.Updaters.Setup;
using Global.UI.EventSystems.Runtime;
using Global.UI.LoadingScreens.Runtime;
using Global.UI.Nova.Compose;
using Global.UI.Overlays.Runtime;
using Global.UI.UiStateMachines.Runtime;
using Internal.Services.Scenes.Data;
using Menu.Settings.Global;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer.Unity;

namespace Global.Config.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "GlobalConfig", menuName = "Global/Config")]
    public class GlobalScopeConfig : ScriptableObject, IScopeConfig
    {
        [FoldoutGroup("Audio")] [SerializeField] private SoundsPlayerFactory _soundsPlayer;
        [FoldoutGroup("Audio")] [SerializeField] private AudioListenerSwitcherFactory _audioSwitcher;
        [FoldoutGroup("Camera")] [SerializeField] private CameraUtilsFactory _cameraUtils;
        [FoldoutGroup("Camera")] [SerializeField] private CurrentCameraFactory _currentCamera;
        [FoldoutGroup("Camera")] [SerializeField] private GlobalCameraFactory _globalCamera;
        [FoldoutGroup("Input")] [SerializeField] private InputViewFactory _inputView;
        [FoldoutGroup("Publisher")] [SerializeField] private PublisherSdkFactory _publisherSdk;
        [FoldoutGroup("Scenes")] [SerializeField] private LoadedScenesHandlerFactory _loadedScenesHandler;
        [FoldoutGroup("System")] [SerializeField] private GameLoopFactory _gameLoop;
        [FoldoutGroup("System")] [SerializeField] private ApplicationProxyFactory _applicationProxy;
        [FoldoutGroup("System")] [SerializeField] private MessageBrokerFactory _messageBroker;
        [FoldoutGroup("System")] [SerializeField] private PauseFactory _pause;
        [FoldoutGroup("System")] [SerializeField] private ResourcesCleanerFactory _resourcesCleaner;
        [FoldoutGroup("System")] [SerializeField] private UpdaterFactory _updater;
        [FoldoutGroup("System")] [SerializeField] private AnimatorsUpdaterFactory _animatorsUpdater;
        [FoldoutGroup("System")] [SerializeField] private DestroyHandlerFactory _destroyHandler;
        [FoldoutGroup("System")] [SerializeField] private EntityCreatorServiceFactory _entityCreator;
        [FoldoutGroup("System")] [SerializeField] private BackendFactory _backend;
        
        [FoldoutGroup("UI")] [SerializeField] private LoadingScreenFactory _loadingScreen;
        [FoldoutGroup("UI")] [SerializeField] private LocalizationFactory _localization;
        [FoldoutGroup("UI")] [SerializeField] private GlobalOverlayFactory _globalOverlay;
        [FoldoutGroup("UI")] [SerializeField] private UiStateMachineFactory _uiStateMachine;
        [FoldoutGroup("UI")] [SerializeField] private EventSystemFactory _eventSystem;
        [FoldoutGroup("UI")] [SerializeField] private NovaCompose _nova;
        [FoldoutGroup("Menu")] [SerializeField] private SettingsFactory _settings;
        [SerializeField] private GlobalNetworkCompose _network;
        
        [SerializeField] private GlobalScope _scope;
        [SerializeField] private SceneData _servicesScene;
        
        public LifetimeScope ScopePrefab => _scope;
        public ISceneAsset ServicesScene => _servicesScene;
        public IReadOnlyList<IServiceFactory> Services => GetFactories();
        public IReadOnlyList<ICallbacksFactory> Callbacks => GetCallbacks();

        private IServiceFactory[] GetFactories()
        {
            var services = new List<IServiceFactory>
            {
                _applicationProxy,
                _cameraUtils,
                _currentCamera,
                _loadedScenesHandler,
                _globalCamera,
                _inputView,
                _resourcesCleaner,
                _updater,
                _animatorsUpdater,
                _messageBroker,
                _uiStateMachine,
                _eventSystem,
                _soundsPlayer,
                _audioSwitcher,
                _localization,
                _pause,
                _destroyHandler,
                _settings,
                _publisherSdk,
                _loadingScreen,
                _globalOverlay,
                _gameLoop,
                _entityCreator,
                _nova,
                _backend
            };

            services.AddRange(_network.Services);

            return services.ToArray();
        }

        private ICallbacksFactory[] GetCallbacks()
        {
            return new ICallbacksFactory[]
            {
                new DefaultCallbacksFactory()
            };
        }
    }
}