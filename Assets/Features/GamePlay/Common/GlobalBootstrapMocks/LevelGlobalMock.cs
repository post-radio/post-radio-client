using Common.Architecture.Mocks.Runtime;
using Common.Architecture.ScopeLoaders.Factory;
using Cysharp.Threading.Tasks;
using GamePlay.Config.Runtime;
using UnityEngine;
using VContainer;

namespace GamePlay.Common.GlobalBootstrapMocks
{
    [DisallowMultipleComponent]
    public class LevelGlobalMock : MockBase
    {
        [SerializeField] private LevelConfig _level;
        [SerializeField] private GlobalMock _mock;
        
        public override async UniTaskVoid Process()
        {
            var result = await _mock.BootstrapGlobal();
            await BootstrapLocal(result);
        }

        private async UniTask BootstrapLocal(MockBootstrapResult result)
        {
            var scopeLoaderFactory = result.Resolver.Resolve<IScopeLoaderFactory>();
            var scopeLoader = scopeLoaderFactory.Create(_level, result.Parent);
            var scope = await scopeLoader.Load();

            await result.RegisterLoadedScene(scope);
        }
    }
}