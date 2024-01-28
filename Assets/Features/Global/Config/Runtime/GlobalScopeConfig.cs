using System.Collections.Generic;
using Common.Architecture.Scopes.Common.DefaultCallbacks;
using Common.Architecture.Scopes.Common.DestroyHandler;
using Common.Architecture.Scopes.Runtime.Services;
using Global.Audio.Compose;
using Global.Backend.Runtime;
using Global.Cameras.Compose;
using Global.GameLoops.Runtime;
using Global.Inputs.Compose;
using Global.Network.Compose;
using Global.Publisher.Abstract.Bootstrap;
using Global.System.Compose;
using Global.UI.Compose;
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
        [SerializeField] private AudioCompose _audio;
        [SerializeField] private CameraCompose _camera;
        [SerializeField] private InputCompose _input;
        [SerializeField] private SystemCompose _system;
        [SerializeField] private GlobalNetworkCompose _network;
        [SerializeField] private GlobalUICompose _ui;
        [SerializeField] private GameLoopFactory _gameLoop;
        [SerializeField] private PublisherSdkFactory _publisherSdk;
        [SerializeField] private BackendFactory _backend;
        [SerializeField] private SettingsFactory _settings;
        [SerializeField] private DefaultCallbacksServiceFactory _defaultCallbacks;
        [SerializeField] private ScopeDestroyHandlerFactory _scopeDestroyHandler;
        [SerializeField] private GlobalScope _scope;
        [SerializeField] private SceneData _servicesScene;

        public LifetimeScope ScopePrefab => _scope;
        public ISceneAsset ServicesScene => _servicesScene;
        public IReadOnlyList<IServiceFactory> Services => GetFactories();

        public IReadOnlyList<IServicesCompose> Composes => new IServicesCompose[]
        {
            _camera,
            _audio,
            _network,
            _input,
            _system,
            _ui
        };

        private IServiceFactory[] GetFactories()
        {
            var services = new List<IServiceFactory>
            {
                _settings,
                _publisherSdk,
                _gameLoop,
                _backend,
                _defaultCallbacks,
                _scopeDestroyHandler
            };

            return services.ToArray();
        }
    }
}