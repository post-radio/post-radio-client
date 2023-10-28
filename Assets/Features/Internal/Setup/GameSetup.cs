﻿using Common.Architecture.ScopeLoaders.Factory;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using Global.Config.Runtime;
using Internal.Scope;
using UnityEngine;
using VContainer;

namespace Internal.Setup
{
    [DisallowMultipleComponent]
    public class GameSetup : MonoBehaviour
    {
        [SerializeField] private InternalScopeConfig _internal;
        [SerializeField] private GlobalScopeConfig _global;
        
        private void Awake()
        {
            Setup().Forget();
        }

        private async UniTask Setup()
        {
            var internalScopeLoader = new InternalScopeLoader(_internal);
            var internalScope = await internalScopeLoader.Load();
            var scopeLoaderFactory = internalScope.Container.Resolve<IScopeLoaderFactory>();
            var scopeLoader = scopeLoaderFactory.Create(_global, internalScope);

            var scopeLoadResult = await scopeLoader.Load();
            
            await scopeLoadResult.Callbacks[CallbackStage.Construct].Run();
            await scopeLoadResult.Callbacks[CallbackStage.SetupComplete].Run();
        }
    }
}