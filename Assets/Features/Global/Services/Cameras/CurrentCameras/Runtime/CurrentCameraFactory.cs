using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.Cameras.CurrentCameras.Common;
using Global.Cameras.CurrentCameras.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Cameras.CurrentCameras.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = CurrentCameraRoutes.ServiceName,
        menuName = CurrentCameraRoutes.ServicePath)]
    public class CurrentCameraFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private CurrentCameraLogSettings _logSettings;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<CurrentCameraLogger>()
                .WithParameter(_logSettings);

            services.Register<CurrentCamera>()
                .As<ICurrentCamera>()
                .AsCallbackListener();
        }
    }
}