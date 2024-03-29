﻿using System;
using Common.Architecture.Scopes.Factory;
using Common.Architecture.Scopes.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using Global.UI.LoadingScreens.Runtime;
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

            scopeLoadResult.Scope.Container.Resolve<ILoadingScreen>().HideGameLoading();

            return new MockBootstrapResult(scopeLoadResult.Scope);
        }
    }
}