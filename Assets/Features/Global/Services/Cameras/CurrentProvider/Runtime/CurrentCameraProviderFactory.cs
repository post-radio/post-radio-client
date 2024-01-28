using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.Cameras.CurrentProvider.Common;
using Global.Cameras.CurrentProvider.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Cameras.CurrentProvider.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = CurrentCameraRoutes.ServiceName,
        menuName = CurrentCameraRoutes.ServicePath)]
    public class CurrentCameraProviderFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private CurrentCameraLogSettings _logSettings;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<CurrentCameraLogger>()
                .WithParameter(_logSettings);

            services.Register<CurrentCameraProvider>()
                .As<ICurrentCameraProvider>()
                .AsCallbackListener();
        }
    }
}