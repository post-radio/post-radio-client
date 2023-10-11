using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.Network.Handlers.SceneCollectors.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Network.Handlers.SceneCollectors.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SceneCollectorBridgeRoutes.ServiceName,
        menuName = SceneCollectorBridgeRoutes.ServicePath)]
    public class SceneCollectorBridgeFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<SceneCollectorBridge>()
                .As<ISceneCollectorBridge>();
        }
    }
}