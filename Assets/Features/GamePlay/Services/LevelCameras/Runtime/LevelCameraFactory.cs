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
    [CreateAssetMenu(fileName = LevelCameraRoutes.ServiceName,
        menuName = LevelCameraRoutes.ServicePath)]
    public class LevelCameraFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private LevelCameraConfigAsset _config;
        [SerializeField] [Indent] private LevelCameraLogSettings _logSettings;
        [SerializeField] [Indent] private LevelCamera _prefab;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var levelCamera = Instantiate(_prefab);
            levelCamera.name = "LevelCamera";

            services.Register<LevelCameraLogger>()
                .WithParameter(_logSettings)
                .AsSelf();

            services.Register<LevelCameraConfig>()
                .WithParameter(_config)
                .As<ILevelCameraConfig>();

            services.RegisterComponent(levelCamera)
                .As<ILevelCamera>()
                .AsCallbackListener();

            utils.Binder.MoveToModules(levelCamera);
        }
    }
}