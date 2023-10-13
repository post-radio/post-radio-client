﻿using Common.Architecture.Mocks.Runtime;
using Common.Architecture.ScopeLoaders.Factory;
using Cysharp.Threading.Tasks;
using Global.Network.Connection.Runtime;
using Internal.Services.Options.Runtime;
using Internal.Services.Scenes.Abstract;
using Menu.Config.Runtime;
using UnityEngine;
using VContainer;

namespace Menu.Config.Mock
{
    [DisallowMultipleComponent]
    public class MenuGlobalMock : MockBase
    {
        [SerializeField] private MenuConfig _menu;
        [SerializeField] private GlobalMock _mock;
        
        public override async UniTaskVoid Process()
        {
            var result = await _mock.BootstrapGlobal();
            await BootstrapLocal(result);
        }

        private async UniTask BootstrapLocal(MockBootstrapResult result)
        {
            var resolver = result.Resolver;
            
            var connection = resolver.Resolve<IConnection>();
            await connection.Connect();
            
            var scopeLoaderFactory = resolver.Resolve<IScopeLoaderFactory>();
            
            var scopeLoader = scopeLoaderFactory.Create(_menu, result.Parent);
            var scope = await scopeLoader.Load();
            
            await result.RegisterLoadedScene(scope);
        }
    }
}