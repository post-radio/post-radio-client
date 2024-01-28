using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Network.Room.SceneCollectors.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Network.Room.SceneCollectors.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SceneCollectorRoutes.ServiceName,
        menuName = SceneCollectorRoutes.ServicePath)]
    public class NetworkSceneCollectorFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<NetworkSceneCollector>()
                .As<IGameSceneCollector>()
                .AsCallbackListener();
        }
    }
}