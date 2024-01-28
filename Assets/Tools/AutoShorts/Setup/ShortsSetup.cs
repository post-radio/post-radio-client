using System;
using System.Collections.Generic;
using Common.Architecture.Container.Abstract;
using Common.Architecture.Mocks.Runtime;
using Common.Architecture.Scopes.Common.DefaultCallbacks;
using Common.Architecture.Scopes.Factory;
using Common.Architecture.Scopes.Runtime.Callbacks;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Audio.Backend;
using Internal.Scope;
using Internal.Services.Scenes.Data;
using Tools.AutoShorts.Runtime;
using Tools.AutoShorts.Runtime.SlideShow;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Tools.AutoShorts.Setup
{
    [DisallowMultipleComponent]
    public class ShortsSetup : MockBase, IScopeConfig, IServiceFactory
    {
        [SerializeField] private AudioBackendFactory _audioBackend;
        [SerializeField] private ShortsPlayer _player;
        [SerializeField] private SlideShow _slideShow;
        [SerializeField] private ShortCreator _creator;

        [SerializeField] private InternalScopeConfig _internal;
        [SerializeField] private ShortsScope _scopePrefab;
        [SerializeField] private SceneData _servicesScene;

        [SerializeField] private DefaultCallbacksServiceFactory _defaultCallbacks;
        
        public LifetimeScope ScopePrefab => _scopePrefab;
        public ISceneAsset ServicesScene => _servicesScene;
        public IReadOnlyList<IServiceFactory> Services => GetServices();
        public IReadOnlyList<IServicesCompose> Composes => Array.Empty<IServicesCompose>();

        public override async UniTaskVoid Process()
        {
            var internalScopeLoader = new InternalScopeLoader(_internal);
            var internalScope = await internalScopeLoader.Load();
            var scopeLoaderFactory = internalScope.Container.Resolve<IScopeLoaderFactory>();
            var scopeLoader = scopeLoaderFactory.Create(this, internalScope);
            var scope = await scopeLoader.Load();

            await scope.Callbacks[CallbackStage.Construct].Run();
            await scope.Callbacks[CallbackStage.SetupComplete].Run();
        }

        private IReadOnlyList<IServiceFactory> GetServices()
        {
            return new List<IServiceFactory>()
            {
                _audioBackend,
                _defaultCallbacks,
                this
            };
        }

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.RegisterInstance(_player)
                .As<IShortsPlayer>();

            services.RegisterInstance(_slideShow)
                .As<ISlideShow>();

            services.RegisterInstance(_creator)
                .As<IShortCreator>();

            services.Register<ShortRunner>()
                .AsCallbackListener();
        }
    }
}