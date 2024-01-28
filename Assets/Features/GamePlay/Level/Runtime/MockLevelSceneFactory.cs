using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Common.SceneBootstrappers.Runtime;
using GamePlay.Level.Routes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Level.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelSceneRoutes.MockName,
        menuName = LevelSceneRoutes.MockPath)]
    public class MockLevelSceneFactory : BaseLevelSceneFactory
    {
        public override async UniTask Create(IServiceCollection builder, IScopeUtils utils)
        {
            var bootstrapper = FindFirstObjectByType<SceneBootstrapper>();

            bootstrapper.Build(builder, utils.Callbacks);
        }
    }
}