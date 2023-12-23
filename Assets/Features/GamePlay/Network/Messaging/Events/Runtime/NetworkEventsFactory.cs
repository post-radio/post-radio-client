using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Network.Messaging.Events.Common;
using GamePlay.Network.Messaging.Events.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Network.Messaging.Events.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = NetworkEventsRoutes.ServiceName, menuName = NetworkEventsRoutes.ServicePath)]
    public class NetworkEventsFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private NetworkEventsLogSettings _logSettings;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<NetworkEvents>()
                .As<INetworkEvents>()
                .AsCallbackListener();

            services.Register<NetworkEventsLogger>()
                .WithParameter(_logSettings);

            services.Register<NetworkEventsDistributor>()
                .As<INetworkEventsDistributor>();
        }
    }
}