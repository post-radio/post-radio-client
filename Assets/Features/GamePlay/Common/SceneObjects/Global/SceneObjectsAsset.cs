using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Common.SceneObjects.Common;
using GamePlay.Common.SceneObjects.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Common.SceneObjects.Global
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SceneObjectsRoutes.ServiceName,
        menuName = SceneObjectsRoutes.ServicePath)]
    public class SceneObjectsAsset : ScriptableObject, IServiceFactory
    {
        [SerializeField] private SceneObjectLogSettings _logSettings;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<SceneObjectLogger>()
                .WithParameter(_logSettings);
        }
    }
}