using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Common.DataTypes.Collections.NestedScriptableObjects.Attributes;
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
        [SerializeField] [NestedScriptableObjectField]
        private SceneData _scene;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var loadResult = await utils.SceneLoader.LoadTyped<LevelUiScheme>(_scene);
            var scheme = loadResult.Searched;

            services.Register<LevelUiController>()
                .WithParameter<ILevelUiScheme>(scheme)
                .As<ILevelUiController>()
                .AsCallbackListener();

            services.RegisterInstance(scheme.AudioOverlay);
            services.RegisterInstance(scheme.AudioVoting);
            services.RegisterInstance(scheme.AudioVoting.VotingView);
            services.RegisterInstance(scheme.ImageGallery);
        }
    }
}