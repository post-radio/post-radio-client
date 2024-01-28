using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
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