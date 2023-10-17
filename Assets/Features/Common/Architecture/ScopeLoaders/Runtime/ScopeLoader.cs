using System.Collections.Generic;
using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Internal.Services.Options.Runtime;
using Internal.Services.Scenes.Abstract;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using ContainerBuilder = Common.Architecture.DiContainer.Runtime.ContainerBuilder;
using ILogger = Internal.Services.Loggers.Runtime.ILogger;

namespace Common.Architecture.ScopeLoaders.Runtime
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
            foreach (var factory in _config.Callbacks)
                factory.AddCallbacks(utils.Callbacks, utils.Data);

            var tasks = new List<UniTask>();

            foreach (var factory in _config.Services)
            {
                tasks.Add(factory.Create(builder, utils));
            }

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