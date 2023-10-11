using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Network.Objects.Destroyer.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Network.Objects.Destroyer.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EntityDestroyerRoutes.ServiceName,
        menuName = EntityDestroyerRoutes.ServicePath)]
    public class NetworkEntityDestroyerFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<NetworkEntityDestroyer>()
                .As<INetworkEntityDestroyer>();
        }
    }
}