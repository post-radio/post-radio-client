using System.Collections.Generic;
using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Callbacks;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Internal.Services.Options.Runtime;
using Internal.Services.Scenes.Abstract;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using ContainerBuilder = Common.Architecture.Container.Runtime.ContainerBuilder;
using ILogger = Internal.Services.Loggers.Runtime.ILogger;

namespace Common.Architecture.Scopes.Runtime
{
    public class ScopeLoader : IScopeLoader
    {
        public ScopeLoader(
            ILogger logger,
            ISceneLoader sceneLoader,
            IOptions options,
            LifetimeScope parent,
            IScopeConfig config)
        {
            _logger = logger;
            _sceneLoader = sceneLoader;
            _options = options;
            _parent = parent;
            _config = config;
        }

        private readonly ILogger _logger;
        private readonly ISceneLoader _sceneLoader;
        private readonly IOptions _options;
        private readonly LifetimeScope _parent;
        private readonly IScopeConfig _config;

        public async UniTask<IScopeLoadResult> Load()
        {
            var sceneLoader = new ScopeSceneLoader(_sceneLoader);
            var utils = await CreateUtils(sceneLoader);
            var builder = new ContainerBuilder();

            await CreateServices(builder, utils);
            await BuildContainer(builder, utils);

            var loadResult = new ScopeLoadResult(utils.Data.Scope, utils.Callbacks, sceneLoader);

            return loadResult;
        }

        private async UniTask<IScopeUtils> CreateUtils(ISceneLoader sceneLoader)
        {
            var servicesScene = await sceneLoader.Load(_config.ServicesScene);
            var binder = new ScopeBinder(servicesScene.Scene);
            var scope = Object.Instantiate(_config.ScopePrefab);
            binder.MoveToModules(scope.gameObject);
            var scopeData = new ScopeData(scope);
            var callbacks = new ScopeCallbacks();

            var utils = new ScopeUtils(_options, sceneLoader, binder, scopeData, callbacks);

            return utils;
        }

        private async UniTask CreateServices(IServiceCollection builder, IScopeUtils utils)
        {
            var tasks = new List<UniTask>();

            var services = new List<IServiceFactory>(_config.Services);

            foreach (var compose in _config.Composes)
                services.AddRange(compose.Factories);

            foreach (var factory in services)
                tasks.Add(factory.Create(builder, utils));

            await UniTask.WhenAll(tasks);
        }

        private async UniTask BuildContainer(IDependenciesBuilder builder, IScopeUtils utils)
        {
            using (LifetimeScope.EnqueueParent(_parent))
            {
                using (LifetimeScope.Enqueue(Register))
                {
                    await UniTask.Create(async () => utils.Data.Scope.Build());
                }
            }

            builder.ResolveAllWithCallbacks(utils.Data.Scope.Container, utils.Callbacks);

            void Register(IContainerBuilder container)
            {
                builder.RegisterAll(container);
            }
        }
    }
}