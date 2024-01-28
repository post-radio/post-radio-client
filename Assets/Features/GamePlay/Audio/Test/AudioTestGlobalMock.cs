using System.Collections.Generic;
using Common.Architecture.Mocks.Runtime;
using Common.Architecture.Scopes.Common.DefaultCallbacks;
using Common.Architecture.Scopes.Factory;
using Common.Architecture.Scopes.Runtime.Services;
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

namespace GamePlay.Audio.Test
{
    public class AudioTestGlobalMock : MockBase, IScopeConfig
    {
        [SerializeField] private TestEntityFactory _entity;
        [SerializeField] private GlobalMock _global;
        
        [SerializeField] private LevelNetworkCompose _network;
        
        [SerializeField] private LevelScope _scopePrefab;
        [SerializeField] private SceneData _servicesScene;
        [SerializeField] private AudioTest _test;
        [SerializeField] private DefaultCallbacksServiceFactory _defaultCallbacks;

        public LifetimeScope ScopePrefab => _scopePrefab;
        public ISceneAsset ServicesScene => _servicesScene;

        public IReadOnlyList<IServiceFactory> Services => new IServiceFactory[]
        {
            _entity,
            _defaultCallbacks
        };

        public IReadOnlyList<IServicesCompose> Composes => new IServicesCompose[]
        {
            _network
        };

        public override async UniTaskVoid Process()
        {
            var result = await _global.BootstrapGlobal();
            var resolver = result.Resolver;

            var connection = resolver.Resolve<IConnection>();
            await connection.Connect();

            var sessionName = "audio-test";
            
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
            
            scope.Scope.Container.Inject(_test);
        }
    }
}