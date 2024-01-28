using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.Cameras.Persistent.Common;
using Global.Cameras.Persistent.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Cameras.Persistent.Runtime
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
            var globalCamera = Instantiate(_prefab, new Vector3(0f, 0f, -10f), Quaternion.identity);
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