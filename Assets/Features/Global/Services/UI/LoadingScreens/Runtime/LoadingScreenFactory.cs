using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.UI.LoadingScreens.Common;
using Global.UI.LoadingScreens.Logs;
using Internal.Services.Scenes.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.UI.LoadingScreens.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LoadingScreenRouter.ServiceName,
        menuName = LoadingScreenRouter.ServicePath)]
    public class LoadingScreenFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private LoadingScreenLogSettings _logSettings;
        [SerializeField] [Indent] private SceneData _scene;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var result = await utils.SceneLoader.LoadTyped<LoadingScreen>(_scene);

            var loadingScreen = result.Searched;

            services.Register<LoadingScreenLogger>()
                .WithParameter(_logSettings);

            services.RegisterComponent(loadingScreen)
                .As<ILoadingScreen>();
        }
    }
}