using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Common.Serialization.NestedScriptableObjects.Attributes;
using Cysharp.Threading.Tasks;
using GamePlay.UI.Common;
using Internal.Services.Scenes.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.UI.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelUIRoutes.ServiceName,
        menuName = LevelUIRoutes.ServicePath)]
    public class LevelUiFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [NestedScriptableObjectField] private SceneData _scene;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var loadResult = await utils.SceneLoader.LoadTyped<LevelUiView>(_scene);
            var view = loadResult.Searched;
            
            services.Register<LevelUiController>()
                .WithParameter<ILevelUiView>(view)
                .As<ILevelUiController>()
                .AsCallbackListener();
        }
    }
}