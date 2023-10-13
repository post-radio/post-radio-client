using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Network.Players.Registry.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Network.Players.Registry.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayersRegistryRoutes.ServiceName,
        menuName = PlayersRegistryRoutes.ServicePath)]
    public class PlayersRegistryFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<PlayersList>()
                .As<IPlayersList>();
        }
    }
}