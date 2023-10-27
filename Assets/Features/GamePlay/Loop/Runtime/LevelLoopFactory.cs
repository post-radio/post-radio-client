using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Loop.Common;
using GamePlay.Loop.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Loop.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelLoopRoutes.ServiceName,
        menuName = LevelLoopRoutes.ServicePath)]
    public class LevelLoopFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private LevelLoopLogSettings _logSettings;
        [SerializeField] private TransitToGameConfig _config;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<LevelLoopLogger>()
                .WithParameter(_logSettings);

            services.Register<LevelLoop>()
                .WithParameter(_config)
                .AsCallbackListener();
        }
    }
}