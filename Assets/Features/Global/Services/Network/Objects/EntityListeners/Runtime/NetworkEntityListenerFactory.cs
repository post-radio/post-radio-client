using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.Network.Objects.EntityListeners.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Network.Objects.EntityListeners.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EntityListenerRoutes.ServiceName, menuName = EntityListenerRoutes.ServicePath)]
    public class NetworkEntityListenerFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<EntityListener>()
                .As<IEntityListener>();
        }
    }
}