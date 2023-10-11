using System;
using Common.Architecture.ScopeLoaders.Factory;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using Internal.Scope;
using UnityEngine;
using VContainer;

namespace Common.Architecture.Mocks.Runtime
{
    [Serializable]
    public class GlobalMock
    {
        [SerializeField] private GlobalMockConfig _config;

        public async UniTask<MockBootstrapResult> BootstrapGlobal()
        {
            var internalScopeLoader = new InternalScopeLoader(_config.Internal);
            var internalScope = await internalScopeLoader.Load();
            var scopeLoaderFactory = internalScope.Container.Resolve<IScopeLoaderFactory>();
            var scopeLoader = scopeLoaderFactory.Create(_config.Global, internalScope);

            var scopeLoadResult = await scopeLoader.Load();
            
            await scopeLoadResult.Callbacks[CallbackStage.Construct].Run();
            await scopeLoadResult.Callbacks[CallbackStage.SetupComplete].Run();

            return new MockBootstrapResult(scopeLoadResult.Scope);
        }
    }
}