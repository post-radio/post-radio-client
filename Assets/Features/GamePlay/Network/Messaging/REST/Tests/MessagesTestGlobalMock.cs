using System.Collections.Generic;
using Common.Architecture.Mocks.Runtime;
using Common.Architecture.ScopeLoaders.Factory;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Cysharp.Threading.Tasks;
using GamePlay.Network.Compose;
using GamePlay.Services.Common.Scope;
using Global.Network.Connection.Runtime;
using Global.Network.Session.Runtime.Create;
using Global.Network.Session.Runtime.Join;
using Internal.Services.Scenes.Data;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GamePlay.Network.Messaging.REST.Tests
{
    public class MessagesTestGlobalMock : MockBase, IScopeConfig
    {
        [SerializeField] private GlobalMock _global;
        [SerializeField] private LevelNetworkCompose _network;

        [SerializeField] private LevelScope _scopePrefab;
        [SerializeField] private SceneData _servicesScene;

        public LifetimeScope ScopePrefab => _scopePrefab;
        public ISceneAsset ServicesScene => _servicesScene;
        public IReadOnlyList<IServiceFactory> Services => GetFactories();
        public IReadOnlyList<ICallbacksFactory> Callbacks => GetCallbacks();
        
        protected IServiceFactory[] GetFactories()
        {
            var services = new List<IServiceFactory>()
            {
                new MessagesTestFactory()
            };
            
            services.AddRange(_network.Services);

            return services.ToArray();
        }
        
        private ICallbacksFactory[] GetCallbacks()
        {
            return new[]
            {
                new DefaultCallbacksFactory()
            };
        }
        
        public override async UniTaskVoid Process()
        {
            var result = await _global.BootstrapGlobal();
            var resolver = result.Resolver;

            var connection = resolver.Resolve<IConnection>();
            await connection.Connect();

            var sessionName = "message-test";
            
            var sessionJoin = resolver.Resolve<ISessionJoin>();
            var joinResult =  await sessionJoin.Join(sessionName);

            if (joinResult.Type == SessionJoinResultType.Fail)
            {
                var sessionCreate = resolver.Resolve<ISessionCreate>();
                await sessionCreate.Create();
            }

            var scopeLoaderFactory = resolver.Resolve<IScopeLoaderFactory>();
            var scopeLoader = scopeLoaderFactory.Create(this, result.Parent);
            var scope = await scopeLoader.Load();

            await result.RegisterLoadedScene(scope);
        }
    }
}