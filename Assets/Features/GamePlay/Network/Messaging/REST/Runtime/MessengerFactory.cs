using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Network.Messaging.REST.Common;
using GamePlay.Network.Messaging.REST.Logs;
using GamePlay.Network.Messaging.REST.Runtime.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Network.Messaging.REST.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = MessengerRoutes.ServiceName, menuName = MessengerRoutes.ServicePath)]
    public class MessengerFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private MessengerLogSettings _logSettings;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<MessengerLogger>()
                .WithParameter(_logSettings);
            
            services.Register<Messenger>()
                .As<IMessenger>()
                .AsCallbackListener();

            services.Register<MessageDistributor>()
                .As<IMessageDistributor>();
        }
    }
}