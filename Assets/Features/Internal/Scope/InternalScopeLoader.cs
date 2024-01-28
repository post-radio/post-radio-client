using Common.Architecture.Scopes.Factory;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Internal.Scope
{
    public class InternalScopeLoader
    {
        public InternalScopeLoader(IInternalScopeConfig config)
        {
            _config = config;
        }

        private readonly IInternalScopeConfig _config;

        public async UniTask<LifetimeScope> Load()
        {
            _config.Options.Setup();
            
            var scope = Object.Instantiate(_config.Scope);

            using (LifetimeScope.Enqueue(Register))
            {
                await UniTask.Create(async () => scope.Build());
            }

            void Register(IContainerBuilder builder)
            {
                foreach (var service in _config.Services)
                    service.Create(_config.Options, builder);

                builder.RegisterInstance(_config.Options);
                builder.Register<ScopeLoaderFactory>(Lifetime.Singleton)
                    .As<IScopeLoaderFactory>();
            }

            return scope;
        }
    }
}