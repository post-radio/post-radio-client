using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.Network.EventsRegistries.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Network.EventsRegistries.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EventsRegistryRoutes.ServiceName,
        menuName = EventsRegistryRoutes.ServicePath)]
    public class EventsRegistryFactory : ScriptableObject, IServiceFactory  
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<NetworkEventsRegistry>()
                .AsCallbackListener();
        }
    }
}