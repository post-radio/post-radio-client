using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Lists.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Lists.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayersListRoutes.ServiceName,
        menuName = PlayersListRoutes.ServicePath)]
    public class PlayersListFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<PlayersList>()
                .As<IPlayersList>();
        }
    }
}