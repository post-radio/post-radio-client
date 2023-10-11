using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Common.Serialization.NestedScriptableObjects.Attributes;
using Cysharp.Threading.Tasks;
using GamePlay.Common.SceneBootstrappers.Runtime;
using GamePlay.Level.Scene.Common;
using Internal.Services.Scenes.Data;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GamePlay.Level.Scene.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelSceneRoutes.ServiceName,
        menuName = LevelSceneRoutes.ServicePath)]
    public class LevelSceneFactory : BaseLevelSceneFactory
    {
        [SerializeField] [NestedScriptableObjectField] private SceneData _scene;

        public override async UniTask Create(IServiceCollection builder, IScopeUtils utils)
        {
            var result = await utils.SceneLoader.LoadTyped<SceneBootstrapper>(_scene);

            SceneManager.SetActiveScene(result.Scene);

            var bootstrapper = result.Searched;

            bootstrapper.Build(builder, utils.Callbacks);
        }
    }
}