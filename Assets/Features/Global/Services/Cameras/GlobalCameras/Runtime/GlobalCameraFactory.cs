using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.Cameras.GlobalCameras.Common;
using Global.Cameras.GlobalCameras.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Cameras.GlobalCameras.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GlobalCameraRoutes.ServiceName,
        menuName = GlobalCameraRoutes.ServicePath)]
    public class GlobalCameraFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private GlobalCameraLogSettings _logSettings;
        [SerializeField] [Indent] private GlobalCamera _prefab;


        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var globalCamera = Instantiate(_prefab);
            globalCamera.name = "Camera_Global";
            globalCamera.gameObject.SetActive(false);

            services.Register<GlobalCameraLogger>()
                .WithParameter(_logSettings);

            services.RegisterComponent(globalCamera)
                .As<IGlobalCamera>()
                .AsCallbackListener();

            utils.Binder.MoveToModules(globalCamera);
        }
    }
}