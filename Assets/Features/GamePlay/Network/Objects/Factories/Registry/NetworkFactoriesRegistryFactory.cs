using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Network.Objects.Factories.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Network.Objects.Factories.Registry
{
    [InlineEditor]
    [CreateAssetMenu(fileName = NetworkObjectFactoryRoutes.RegistryName,
        menuName = NetworkObjectFactoryRoutes.RegistryPath)]
    public class NetworkFactoriesRegistryFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<NetworkFactoriesRegistry>()
                .As<INetworkFactoriesRegistry>()
                .AsCallbackListener();
        }
    }
}