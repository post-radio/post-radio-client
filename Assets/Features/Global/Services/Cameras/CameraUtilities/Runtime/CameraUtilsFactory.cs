using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.Cameras.CameraUtilities.Common;
using Global.Cameras.CameraUtilities.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Cameras.CameraUtilities.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = CameraUtilsRoutes.ServiceName,
        menuName = CameraUtilsRoutes.ServicePath)]
    public class CameraUtilsFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private CameraUtilsLogSettings _logSettings;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<CameraUtilsLogger>()
                .WithParameter(_logSettings);

            services.Register<CameraUtils>()
                .As<ICameraUtils>()
                .AsCallbackListener();
        }
    }
}