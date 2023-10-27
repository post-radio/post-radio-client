using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Setup.Local;
using GamePlay.Player.Entity.Setup.Remote;
using GamePlay.Player.Factory.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Factory.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayerFactoryRoutes.ServiceName, menuName = PlayerFactoryRoutes.ServicePath)]
    public class PlayerFactoryServiceFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private LocalPlayerConfig _localPlayerConfig;
        [SerializeField] private RemotePlayerConfig _remotePlayerConfig;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<PlayerFactory>()
                .WithParameter(utils.Data.Scope)
                .WithParameter(_localPlayerConfig)
                .WithParameter(_remotePlayerConfig)
                .As<IPlayerFactory>();
        }
    }
}