using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Services.LevelCameras.Common;
using GamePlay.Services.LevelCameras.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Services.LevelCameras.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelCameraRoutes.MenuServiceName,
        menuName = LevelCameraRoutes.MenuServicePath)]
    public class MenuCameraFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private LevelCameraLogSettings _logSettings;
        [SerializeField] [Indent] private Camera _prefab;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var camera = Instantiate(_prefab);
            camera.name = "LevelCamera";

            services.Register<LevelCameraLogger>()
                .WithParameter(_logSettings)
                .AsSelf();

            services.Register<LevelCamera>()
                .WithParameter(camera)
                .As<ILevelCamera>()
                .AsCallbackListener();

            utils.Binder.MoveToModules(camera.gameObject);
        }
    }
}