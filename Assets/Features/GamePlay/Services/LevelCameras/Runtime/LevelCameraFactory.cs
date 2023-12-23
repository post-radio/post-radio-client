using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Services.LevelCameras.Common;
using GamePlay.Services.LevelCameras.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Services.LevelCameras.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelCameraRoutes.LevelServiceName,
        menuName = LevelCameraRoutes.LevelServicePath)]
    public class LevelCameraFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private LevelCameraLogSettings _logSettings;
        [SerializeField] private Camera _prefab;
        [SerializeField] private CameraMoverConfig _config;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var camera = Instantiate(_prefab);
            camera.name = "LevelCamera";

            services.Register<LevelCameraLogger>()
                .WithParameter(_logSettings)
                .AsSelf();

            services.Register<CameraMover>()
                .WithParameter(_config)
                .As<ICameraMover>()
                .AsCallbackListener();

            services.Register<LevelCamera>()
                .WithParameter(camera)
                .As<ILevelCamera>()
                .AsCallbackListener();

            services.Register<CameraBlockerListener>()
                .As<ICameraBlockListener>()
                .AsCallbackListener();

            utils.Binder.MoveToModules(camera.gameObject);
        }
    }
}