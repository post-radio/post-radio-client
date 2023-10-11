using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.System.LoadedHandler.Common;
using Global.System.LoadedHandler.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.System.LoadedHandler.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LoadedScenesHandlerRoutes.ServiceName,
        menuName = LoadedScenesHandlerRoutes.ServicePath)]
    public class LoadedScenesHandlerFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private LoadedScenesHandlerLogSettings _logSettings;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<LoadedScenesHandlerLogger>()
                .WithParameter(_logSettings);

            services.Register<LoadedScenesHandler>()
                .As<ILoadedScenesHandler>();
        }
    }
}