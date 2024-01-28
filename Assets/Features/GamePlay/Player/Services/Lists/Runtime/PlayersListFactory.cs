using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Services.Lists.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Services.Lists.Runtime
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